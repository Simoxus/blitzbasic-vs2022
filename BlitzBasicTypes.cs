using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace BlitzBasicLanguageSupport
{
    internal static class BlitzBasicClassificationDefinitions
    {
        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Keyword")]
        internal static ClassificationTypeDefinition KeywordType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Comment")]
        internal static ClassificationTypeDefinition CommentType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Type")]
        internal static ClassificationTypeDefinition TypeType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Number")]
        internal static ClassificationTypeDefinition NumberType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("String")]
        internal static ClassificationTypeDefinition StringType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Function")]
        internal static ClassificationTypeDefinition FunctionType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("BuiltIn")]
        internal static ClassificationTypeDefinition BuiltInType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Blitz3DBuiltIn")]
        internal static ClassificationTypeDefinition Blitz3D_BuiltInType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Preprocessor")]
        internal static ClassificationTypeDefinition PreprocessorType = null;

        [Export(typeof(ClassificationTypeDefinition))]
        [Name("Label")]
        internal static ClassificationTypeDefinition LabelType = null;
    }
}
