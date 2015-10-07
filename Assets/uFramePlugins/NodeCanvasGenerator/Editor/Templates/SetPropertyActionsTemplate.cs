using System.CodeDom;
using Invert.Core.GraphDesigner;
using Invert.uFrame.MVVM;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using uFrame.Graphs;

namespace NodeCanvasGenerator.Templates
{
    [TemplateClass(TemplateLocation.DesignerFile, ClassNameFormat = "Set{0}Action")]
    public class SetPropertyActionsTemplate : IClassTemplate<PropertiesChildItem>
    {
        public TemplateContext<PropertiesChildItem> Ctx { get; set; }

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
            Ctx.AddAttribute(typeof(NameAttribute), string.Format("\"Set {0}\"", Ctx.Data.Name));

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
            var valueField = Ctx.CurrentDeclaration._public_(Ctx.ProcessType(typeof(BBParameter<_ITEMTYPE_>)), "NewValue");
            valueField.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(RequiredFieldAttribute)), new CodeAttributeArgument[] { }));

            Ctx.CurrentDeclaration._private_(Ctx.Data.Node.Name.AsViewModel(), "_viewModel");
            Ctx.CurrentDeclaration._private_("ViewBase", "_view");
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
                Ctx._("return \"Set {0} On {1}\"", Ctx.Data.Name, Ctx.Data.Node.Name.AsViewModel());
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
            ifViewModelIsEmpty.TrueStatements._("_viewModel = _view.ViewModelObject as {0}", Ctx.Data.Node.Name.AsViewModel());

            Ctx._("_viewModel.{0} = NewValue.value", Ctx.Data.Name);
            Ctx._("EndAction(true)");
        }
    }
}