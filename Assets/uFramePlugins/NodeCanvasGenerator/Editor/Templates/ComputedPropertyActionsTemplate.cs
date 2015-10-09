using System.CodeDom;
using Invert.Core.GraphDesigner;
using Invert.uFrame.MVVM;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using uFrame.Graphs;

namespace NodeCanvasGenerator.Templates
{
    [TemplateClass(TemplateLocation.DesignerFile)]
    public class ComputedPropertyActionsTemplate : IClassTemplate<ComputedPropertyNode>
    {
        public TemplateContext<ComputedPropertyNode> Ctx { get; set; }

        public string OutputPath
        {
            get { return Path2.Combine(Ctx.Data.Graph.Name, "NodeCanvasActions"); }
        }

        public bool CanGenerate
        {
            get { return ComputedNode.Container() is ElementNode; }
        }

        private ComputedPropertyNode ComputedNode
        {
            get { return Ctx.Data.Node as ComputedPropertyNode; }
        }

        private string ContainerName
        {
            get { return ComputedNode.Container().Name;  }
        }

        private void SetupClass()
        {
            Ctx.CurrentDeclaration.IsPartial = false;

            Ctx.CurrentDeclaration.Name = string.Format("{0}Get{1}Action", Ctx.Data.Node.Name.AsViewModel(), Ctx.Data.Name);

            Ctx.AddAttribute(typeof(CategoryAttribute), string.Format("\"ViewModels/{0}\"", ContainerName.AsViewModel()));
            Ctx.AddAttribute(typeof(NameAttribute), string.Format("\"Get {0}\"", Ctx.Data.Name));

            var codeType = new CodeTypeOfExpression("ViewBase");
            Ctx.CurrentDeclaration.CustomAttributes.Add(new CodeAttributeDeclaration("AgentType", new CodeAttributeArgument(codeType)));

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
            var valueField = Ctx.CurrentDeclaration._public_(Ctx.ProcessType(typeof(BBParameter<_ITEMTYPE_>)), "CurrentValue");
            valueField.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(typeof(BlackboardOnlyAttribute)), new CodeAttributeArgument[] { }));

            Ctx.CurrentDeclaration._private_(ContainerName.AsViewModel(), "_viewModel");
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
                Ctx._("return \"Get {0} From {1}\"", Ctx.Data.Name, ContainerName.AsViewModel());
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
            ifViewModelIsEmpty.TrueStatements._("_viewModel = _view.ViewModelObject as {0}", ContainerName.AsViewModel());

            Ctx._("CurrentValue.value = _viewModel.{0}", Ctx.Data.Name);
            Ctx._("EndAction(true)");
        }
    }
}