using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace BlitzBasicLanguageSupport
{
    // Keywords (If, Function, End, etc.)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Keyword")]
    [Name("BlitzBasicKeywordFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicKeywordFormat : ClassificationFormatDefinition
    {
        public BlitzBasicKeywordFormat()
        {
            this.DisplayName = "BlitzBasic Keyword";
            this.ForegroundColor = Color.FromRgb(86, 156, 214); // Blue
        }
    }

    // Types (Int, Float, String, Object)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Type")]
    [Name("BlitzBasicTypeFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicTypeFormat : ClassificationFormatDefinition
    {
        public BlitzBasicTypeFormat()
        {
            this.DisplayName = "BlitzBasic Type";
            this.ForegroundColor = Color.FromRgb(78, 201, 176); // Teal
        }
    }

    // Comments (; ...)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Comment")]
    [Name("BlitzBasicCommentFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicCommentFormat : ClassificationFormatDefinition
    {
        public BlitzBasicCommentFormat()
        {
            this.DisplayName = "BlitzBasic Comment";
            this.ForegroundColor = Color.FromRgb(87, 166, 74); // Green
        }
    }

    // Numbers (123, 3.14)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Number")]
    [Name("BlitzBasicNumberFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicNumberFormat : ClassificationFormatDefinition
    {
        public BlitzBasicNumberFormat()
        {
            this.DisplayName = "BlitzBasic Number";
            this.ForegroundColor = Color.FromRgb(181, 206, 168); // Light green
        }
    }

    // Strings ("Hello")
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "String")]
    [Name("BlitzBasicStringFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicStringFormat : ClassificationFormatDefinition
    {
        public BlitzBasicStringFormat()
        {
            this.DisplayName = "BlitzBasic String";
            this.ForegroundColor = Color.FromRgb(214, 157, 133); // Brownish red
        }
    }

    // Functions (user-defined calls)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Function")]
    [Name("BlitzBasicFunctionFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicFunctionFormat : ClassificationFormatDefinition
    {
        public BlitzBasicFunctionFormat()
        {
            this.DisplayName = "BlitzBasic Function";
            this.ForegroundColor = Color.FromRgb(220, 220, 170); // Gold
        }
    }

    // Built-in commands (Print, Graphics, LoadImage)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "BuiltIn")]
    [Name("BlitzBasicBuiltInFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicBuiltInFormat : ClassificationFormatDefinition
    {
        public BlitzBasicBuiltInFormat()
        {
            this.DisplayName = "BlitzBasic Built-In";
            this.ForegroundColor = Color.FromRgb(220, 220, 170); // Gold, same as functions
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Blitz3DBuiltIn")]
    [Name("BlitzBasicBlitz3DBuiltInFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicBlitz3DFunctionFormat : ClassificationFormatDefinition
    {
        public BlitzBasicBlitz3DFunctionFormat()
        {
            this.DisplayName = "BlitzBasic Blitz3D Built-In";
            this.ForegroundColor = Color.FromRgb(197, 134, 192); // Purple
        }
    }

    // Preprocessor / Compiler directives
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Preprocessor")]
    [Name("BlitzBasicPreprocessorFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicPreprocessorFormat : ClassificationFormatDefinition
    {
        public BlitzBasicPreprocessorFormat()
        {
            this.DisplayName = "BlitzBasic Preprocessor";
            this.ForegroundColor = Color.FromRgb(128, 128, 128); // Gray
        }
    }

    // Labels (MainLoop:)
    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = "Label")]
    [Name("BlitzBasicLabelFormat")]
    [UserVisible(true)]
    internal sealed class BlitzBasicLabelFormat : ClassificationFormatDefinition
    {
        public BlitzBasicLabelFormat()
        {
            this.DisplayName = "BlitzBasic Label";
            this.ForegroundColor = Color.FromRgb(200, 200, 200); // Light gray
        }
    }
}
