using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace BlitzBasicLanguageSupport
{
    [Export(typeof(IClassifierProvider))]
    [ContentType("BlitzBasic")]
    internal class BlitzBasicClassifierProvider : IClassifierProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry { get; set; }

        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            return textBuffer.Properties.GetOrCreateSingletonProperty(
                () => new BlitzBasicClassifier(ClassificationRegistry));
        }
    }

    internal class BlitzBasicClassifier : IClassifier
    {
        private readonly Dictionary<IClassificationType, List<Regex>> _classificationRules;

        internal BlitzBasicClassifier(IClassificationTypeRegistryService registry)
        {
            // Fetch VS classification types
            var keywordType = registry.GetClassificationType("Keyword");
            var typeType = registry.GetClassificationType("Type");
            var commentType = registry.GetClassificationType("Comment");
            var numberType = registry.GetClassificationType("Number");
            var stringType = registry.GetClassificationType("String");
            var functionType = registry.GetClassificationType("Function");
            var builtinType = registry.GetClassificationType("BuiltIn");
            var blitz3DBuiltInType = registry.GetClassificationType("Blitz3DBuiltIn");
            var preprocType = registry.GetClassificationType("Preprocessor");
            var labelType = registry.GetClassificationType("Label");

            // Rules for each category
            _classificationRules = new Dictionary<IClassificationType, List<Regex>>
            {
                [keywordType] = new List<Regex>
                {
                    new Regex(@"\b(Function|End Function|Return|If|Then|Else|End|End If|For|To|Next|Type|End Type|Dim|While|Wend|Repeat|Until|Select|Case|Default|Const|Local|Global)\b", RegexOptions.IgnoreCase)
                },
                [typeType] = new List<Regex>
                {
                    new Regex(@"\b(Int|Float|String|Object|Bool)\b", RegexOptions.IgnoreCase)
                },
                [commentType] = new List<Regex>
                {
                    // new Regex(@"(;|;~).*")
                    new Regex(@";.*", RegexOptions.Compiled)
                },
                [numberType] = new List<Regex>
                {
                    new Regex(@"\b\d+(\.\d+)?\b")
                },
                [stringType] = new List<Regex>
                {
                    new Regex("\".*?\"")
                },
                [functionType] = new List<Regex>
                {
                    new Regex(@"\b[A-Za-z_]\w*(?=\s*\()") // looks like myFunc()
                },
                [builtinType] = new List<Regex>
                {
                    new Regex(@"\b(Print|Input|Graphics|Cls|LoadImage|DrawImage|Flip|End)\b", RegexOptions.IgnoreCase)
                },
                [blitz3DBuiltInType] = new List<Regex>
                {
                    new Regex(@"\b(AddAnimSeq|AddMesh|AddTriangle|AddVertex|AlignToVector|AmbientLight|Animate|AnimateMD2|Animating|AnimLength|AnimSeq|AnimTime|AntiAlias|BrushAlpha|BrushBlend|BrushColor|BrushFX|BrushShininess|BrushTexture|BSPAmbientLight|BSPLighting|CameraClsColor|CameraClsMode|CameraFogColor|CameraFogMode|CameraFogRange|CameraPick|CameraProject|CameraProjMode|CameraRange|CameraViewport|CameraZoom|CaptureWorld|ClearCollisions|ClearSurface|ClearTextureFilters|ClearWorld|CollisionEntity|CollisionNX|CollisionNY|CollisionNZ|Collisions|CollisionSurface|CollisionTime|CollisionTriangle|CollisionX|CollisionY|CollisionZ|CopyEntity|CopyMesh|CountChildren|CountCollisions|CountGfxModes3D|CountSurfaces|CountTriangles|CountVertices|CreateBrush|CreateCamera|CreateCone|CreateCube|CreateCylinder|CreateLight|CreateListener|CreateMesh|CreateMirror|CreatePivot|CreatePlane|CreateSphere|CreateSprite|CreateSurface|CreateTerrain|CreateTexture|DeltaPitch|DeltaYaw|Dither|EmitSound|EntityAlpha|EntityAutoFade|EntityBlend|EntityBox|EntityClass|EntityCollided|EntityColor|EntityDistance|EntityFX|EntityInView|EntityName|EntityOrder|EntityParent|EntityPick|EntityPickMode|EntityPitch|EntityRadius|EntityRoll|EntityShininess|EntityTexture|EntityType|EntityVisible|EntityX|EntityY|EntityYaw|EntityZ|ExtractAnimSeq|FindChild|FindSurface|FitMesh|FlipMesh|FreeBrush|FreeEntity|FreeTexture|GetBrushTexture|GetChild|GetEntityBrush|GetEntityType|GetMatElement|GetParent|GetSurface|GetSurfaceBrush|GfxDriver3D|GfxDriverCaps3D|GfxMode3D|GfxMode3DExists|Graphics3D|HandleSprite|HideEntity|HWMultiTex|HWTexUnits|LightColor|LightConeAngles|LightMesh|LightRange|LinePick|Load3DSound|LoadAnimMesh|LoadAnimSeq|LoadAnimTexture|LoadBrush|LoadBSP|LoaderMatrix|LoadMD2|LoadMesh|LoadSprite|LoadTerrain|LoadTexture|MD2Animating|MD2AnimLength|MD2AnimTime|MeshDepth|MeshesIntersect|MeshHeight|MeshWidth|ModifyTerrain|MoveEntity|NameEntity|PaintEntity|PaintMesh|PaintSurface|PickedEntity|PickedNX|PickedNY|PickedNZ|PickedSurface|PickedTime|PickedTriangle|PickedX|PickedY|PickedZ|PointEntity|PositionEntity|PositionMesh|PositionTexture|ProjectedX|ProjectedY|ProjectedZ|RenderWorld|ResetEntity|RotateEntity|RotateMesh|RotateSprite|RotateTexture|ScaleEntity|ScaleMesh|ScaleSprite|ScaleTexture|SetAnimKey|SetAnimTime|SetCubeFace|SetCubeMode|ShowEntity|SpriteViewMode|TerrainDetail|TerrainHeight|TerrainShading|TerrainSize|TerrainX|TerrainY|TerrainZ|TextureBlend|TextureBuffer|TextureCoords|TextureFilter|TextureHeight|TextureName|TextureWidth|TFormedX|TFormedY|TFormedZ|TFormNormal|TFormPoint|TFormVector|TranslateEntity|TriangleVertex|TrisRendered|TurnEntity|UpdateNormals|UpdateWorld|VectorPitch|VectorYaw|VertexAlpha|VertexBlue|VertexColor|VertexCoords|VertexGreen|VertexNormal|VertexNX|VertexNY|VertexNZ|VertexRed|VertexTexCoords|VertexU|VertexV|VertexW|VertexX|VertexY|VertexZ|WBuffer|Windowed3D|Wireframe)\b", RegexOptions.IgnoreCase)
                },
                [preprocType] = new List<Regex>
                {
                    new Regex(@"\b(AppTitle|Strict|Extern|EndExtern)\b", RegexOptions.IgnoreCase)
                },
                [labelType] = new List<Regex>
                {
                    new Regex(@"^\s*[A-Za-z_]\w*:\s*$", RegexOptions.Multiline) // e.g. MainLoop:
                }
            };
        }

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            var classifications = new List<ClassificationSpan>();
            string text = span.GetText();

            foreach (var kvp in _classificationRules)
            {
                var classification = kvp.Key;
                foreach (var regex in kvp.Value)
                {
                    foreach (Match match in regex.Matches(text))
                    {
                        classifications.Add(new ClassificationSpan(
                            new SnapshotSpan(span.Snapshot, span.Start + match.Index, match.Length),
                            classification));
                    }
                }
            }

            return classifications;
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
    }
}
