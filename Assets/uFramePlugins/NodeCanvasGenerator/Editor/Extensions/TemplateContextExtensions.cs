using System;
using System.CodeDom;
using System.Linq;
using Invert.Core.GraphDesigner;

namespace NodeCanvasGenerator.Extensions
{
    public static class TemplateContextExtensions
    {
        public static void AddCustomAttribute(this TemplateContext ctx, Type attributeType, object[] attributeArgs)
        {
            var codeAttributeArguments = attributeArgs.Select(x => new CodeAttributeArgument(new CodePrimitiveExpression(x))).ToArray();
            ctx.CurrentDeclaration.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference(attributeType), codeAttributeArguments));
        }
    }
}