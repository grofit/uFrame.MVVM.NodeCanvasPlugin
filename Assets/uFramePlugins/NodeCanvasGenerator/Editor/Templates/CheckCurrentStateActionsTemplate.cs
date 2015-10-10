using System.CodeDom;
using Invert.Core;
using Invert.Core.GraphDesigner;
using Invert.StateMachine;
using Invert.uFrame.MVVM;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using uFrame.Graphs;

namespace NodeCanvasGenerator.Templates
{
    [TemplateClass(TemplateLocation.DesignerFile)]
    public class CheckStateActionsTemplate : IClassTemplate<PropertiesChildItem>
    {
        public TemplateContext<PropertiesChildItem> Ctx { get; set; }

        public string OutputPath
        {
            get { return Path2.Combine(Ctx.Data.Graph.Name, "NodeCanvasActions"); }
        }

        public bool CanGenerate
        {
            get
            {
                var isElementNode = Ctx.Data.Node is ElementNode;
                var isAStateMachine = Ctx.Data.RelatedTypeNode != null && Ctx.Data.RelatedTypeNode is StateMachineNode;
                return isElementNode && isAStateMachine;
            }
        }

        private void SetupClass()
        {
            Ctx.CurrentDeclaration.IsPartial = false;
            Ctx.CurrentDeclaration.Name = string.Format("{0}Check{1}CurrentStateAction", Ctx.Data.Node.Name.AsViewModel(), Ctx.Data.Name);

            Ctx.AddAttribute(typeof(CategoryAttribute), string.Format("\"ViewModels/{0}\"", Ctx.Data.Node.Name.AsViewModel()));
            Ctx.AddAttribute(typeof(NameAttribute), string.Format("\"Check {0}s State\"", Ctx.Data.Name));

            var codeType = new CodeTypeOfExpression("ViewBase");
            Ctx.CurrentDeclaration.CustomAttributes.Add(new CodeAttributeDeclaration("AgentType", new CodeAttributeArgument(codeType)));

            Ctx.SetBaseType(typeof(ConditionTask));
        }

        private void SetupNamespaceDependencies()
        {
            Ctx.TryAddNamespace("NodeCanvas.Framework");
            Ctx.TryAddNamespace("ParadoxNotion.Design");
            Ctx.TryAddNamespace("uFrame.MVVM");
            Ctx.TryAddNamespace("Invert.StateMachine");
        }

        private void SetupMembers()
        {
            var valueField = Ctx.CurrentDeclaration._public_("BBParameter<String>", "CurrentStateName");
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
                Ctx._("return \"{0}s Current State Is \" + CurrentStateName", Ctx.Data.Name);
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
        protected bool OnCheck()
        {
            var ifViewBoundStatement = Ctx._if("_view.IsBound");
            ifViewBoundStatement.FalseStatements._("return false");
            var ifViewModelIsEmpty = ifViewBoundStatement.TrueStatements._if("_viewModel == null");
            ifViewModelIsEmpty.TrueStatements._("_viewModel = _view.ViewModelObject as {0}", Ctx.Data.Node.Name.AsViewModel());

            Ctx._("return _viewModel.{0}.Name.ToLower() == CurrentStateName.value.ToLower()", Ctx.Data.Name);
            return false;
        }
    }
}