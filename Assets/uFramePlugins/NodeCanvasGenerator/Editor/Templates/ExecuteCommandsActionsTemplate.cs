using System.CodeDom;
using Invert.Core.GraphDesigner;
using Invert.uFrame.MVVM;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using uFrame.Graphs;

namespace NodeCanvasGenerator.Templates
{
    [TemplateClass(TemplateLocation.DesignerFile, ClassNameFormat = "Execute{0}Action")]
    public class ExecuteCommandsActionsTemplate : IClassTemplate<CommandsChildItem>
    {
        public TemplateContext<CommandsChildItem> Ctx { get; set; }

        public string OutputPath
        {
            get { return Path2.Combine(Ctx.Data.Graph.Name, "NodeCanvasActions"); }
        }

        public bool CanGenerate
        {
            get { return Ctx.Data.Node is ElementNode; }
        }

        private void SetupClass()
        {
            Ctx.CurrentDeclaration.IsPartial = false;

            Ctx.AddAttribute(typeof(CategoryAttribute), string.Format("\"ViewModels/{0}\"", Ctx.Data.Node.Name.AsViewModel()));
            Ctx.AddAttribute(typeof(NameAttribute), string.Format("\"Execute {0}\"", Ctx.Data.Name));

            Ctx.SetBaseType(typeof(ActionTask));
        }

        private void SetupNamespaceDependencies()
        {
            Ctx.TryAddNamespace("NodeCanvas.Framework");
            Ctx.TryAddNamespace("ParadoxNotion.Design");
            Ctx.TryAddNamespace("uFrame.MVVM");
        }

        private void SetupMembers()
        {
            Ctx.CurrentDeclaration._private_(Ctx.Data.Node.Name.AsViewModel(), "_viewModel");
            Ctx.CurrentDeclaration._private_("ViewBase", "_view");

            if (!string.IsNullOrEmpty(Ctx.Data.RelatedType))
            {
                var argumentField = Ctx.CurrentDeclaration._public_(string.Format("BBParameter<{0}>", Ctx.Data.RelatedType), "CommandArgument");
                argumentField.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(RequiredFieldAttribute)), new CodeAttributeArgument[] { }));
            }
        }

        public void TemplateSetup()
        {
            SetupNamespaceDependencies();
            SetupClass();
            SetupMembers();
        }

        [GenerateProperty]
        protected string info
        {
            get
            {
                Ctx.CurrentProperty.Attributes = MemberAttributes.Override | MemberAttributes.Family;
                Ctx._("return \"Execute {0} On {1}\"", Ctx.Data.Name, Ctx.Data.Node.Name.AsViewModel());
                return null;
            }
        }

        [GenerateMethod, AsOverride]
        protected string OnInit()
        {
            Ctx._("_view = agent.GetComponent<ViewBase>()");
            Ctx._("return base.OnInit()");
            return null;
        }
        
        [GenerateMethod, AsOverride]
        protected void OnExecute()
        {
            var ifViewBoundStatement = Ctx._if("_view.IsBound");
            ifViewBoundStatement.FalseStatements._("EndAction(false); return");
            var ifViewModelIsEmpty = ifViewBoundStatement.TrueStatements._if("_viewModel == null");
            Ctx.PushStatements(ifViewModelIsEmpty.TrueStatements);
            Ctx._("_viewModel = _view.ViewModelObject as {0}", Ctx.Data.Node.Name.AsViewModel());
            Ctx.PopStatements();

            if (!string.IsNullOrEmpty(Ctx.Data.RelatedType))
            {
                Ctx._("_viewModel.{0}.OnNext(new {0}Command {{ Sender = _viewModel, Argument = CommandArgument.value }})", Ctx.Data.Name);
            }
            else
            {
                Ctx._("_viewModel.{0}.OnNext(new {0}Command {{ Sender = _viewModel }})", Ctx.Data.Name);
            }
            Ctx._("EndAction(true)");
        }
    }
}