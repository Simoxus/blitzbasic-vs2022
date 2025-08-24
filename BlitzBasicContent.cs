using Microsoft.VisualStudio.Utilities;
using System.ComponentModel.Composition;

namespace BlitzBasicLanguageSupport
{
    internal static class BlitzBasicContent
    {
        [Export]
        [Name("BlitzBasic")]
        [BaseDefinition("code")]
        internal static ContentTypeDefinition BlitzBasicContentTypeDefinition;

        [Export]
        [FileExtension(".bb")]
        [ContentType("BlitzBasic")]
        internal static FileExtensionToContentTypeDefinition BlitzBasicFileExtensionDefinition;
    }
}
