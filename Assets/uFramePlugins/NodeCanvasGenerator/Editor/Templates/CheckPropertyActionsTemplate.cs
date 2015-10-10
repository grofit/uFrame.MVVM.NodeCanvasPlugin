using System.CodeDom;
using Invert.Core;
using Invert.Core.GraphDesigner;
using Invert.uFrame.MVVM;
using NodeCanvas.Framework;
using NodeCanvasGenerator.Extensions;
using ParadoxNotion.Design;
using uFrame.Graphs;
using uFrame.MVVM;
using UnityEngine;

namespace NodeCanvasGenerator.Templates
{
    [TemplateClass(TemplateLocation.DesignerFile)]
    public class CheckPropertyActionsTemplate : IClassTemplate<PropertiesChildItem>
    {
        public TemplateContext<PropertiesChildItem> Ctx { get; set; }

        public string OutputPath
        {
            get { return Path2.Combine(Ctx.Data.Graph.Name, "NodeCanvasActions"); }
        }

        public bool CanGenerate
        {
            get { return Ctx.Data.Node is ElementNode && Ctx.Data.RelatedTypeName == "Boolean"; }
        }

        private void SetupClass()
        {
            Ctx.CurrentDeclaration.IsPartial = false;

            Ctx.CurrentDeclaration.Name = string.Format("{0}Check{1}Action", Ctx.Data.Node.Name.AsViewModel(), Ctx.Data.Name);

            Ctx.AddAttribute(typeof(CategoryAttribute), string.Format("\"ViewModels/{0}\"", Ctx.Data.Node.Name.AsViewModel()));
            Ctx.AddAttribute(typeof(NameAttribute), string.Format("\"Check {0}\"", Ctx.Data.Name));
            Ctx.AddAttribute(typeof(RequireComponent), "typeof(ViewBase)");

            var codeType = new CodeTypeOfExpression("ViewBase");
            Ctx.CurrentDeclaration.CustomAttributes.Add(new CodeAttributeDeclaration("AgentType", new CodeAttributeArgument(codeType)));
            Ctx.SetBaseType(typeof(ConditionTask));
        }

        private void SetupNamespaceDependencies()
        {
            Ctx.TryAddNamespace("NodeCanvas.Framework");
            Ctx.TryAddNamespace("ParadoxNotion.Design");
            Ctx.TryAddNamespace("uFrame.MVVM");

            if (Ctx.Data.Type != null) { Ctx.TryAddNamespace(Ctx.Data.Type.Namespace); }
        }

        private void SetupMembers()
        {
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
                Ctx._("return \"{0}'s {1}\"", Ctx.Data.Node.Name.AsViewModel(), Ctx.Data.Name);
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

            Ctx._("return _viewModel.{0}", Ctx.Data.Name);
            return true;
        }
    }
}