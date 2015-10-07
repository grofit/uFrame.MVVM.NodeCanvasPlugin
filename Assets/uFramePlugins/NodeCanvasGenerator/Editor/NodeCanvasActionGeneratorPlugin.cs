using Invert.Core.GraphDesigner;
using Invert.IOC;
using Invert.uFrame.MVVM;
using NodeCanvasGenerator.Templates;

namespace NodeCanvasGenerator.Editor
{
    public class NodeCanvasGeneratorPlugin : DiagramPlugin
    {
        public override decimal LoadPriority
        {
            get { return 10; }
        }
        
        public override void Initialize(UFrameContainer container)
        {
            // Grab a reference to the main framework graphs plugin
            var framework = container.Resolve<uFrameMVVM>();

            //Framework.ElementsGraphRoot.AddCodeTemplate<BackupData>();
            // Register the code template
            RegisteredTemplateGeneratorsFactory.RegisterTemplate<PropertiesChildItem, SetPropertyActionsTemplate>();
            RegisteredTemplateGeneratorsFactory.RegisterTemplate<PropertiesChildItem, GetPropertyActionsTemplate>();
            RegisteredTemplateGeneratorsFactory.RegisterTemplate<PropertiesChildItem, CheckPropertyActionsTemplate>();
            RegisteredTemplateGeneratorsFactory.RegisterTemplate<CommandsChildItem, ExecuteCommandsActionsTemplate>();

            framework.ComputedProperty.AddCodeTemplate<ComputedPropertyActionsTemplate>();
            framework.ComputedProperty.AddCodeTemplate<CheckComputedPropertyActionsTemplate>();
        }
    }
}
