using Doozy.Editor.EditorUI;
using Doozy.Editor.EditorUI.Components;
using Doozy.Editor.EditorUI.Utils;
using Doozy.Runtime.UIElements.Extensions;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
// ReSharper disable CheckNamespace

namespace Doozy.Sandbox.AnimatedTitles.Editor
{
    [CustomPropertyDrawer(typeof(TextSettings))]
    public class TextSettingsDrawer : PropertyDrawer
    {
        #region Cache

        private static Color backgroundColor => EditorColors.Default.FieldBackground;
        private static Color borderColor => EditorColors.Default.Selection;

        #endregion

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {}

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            VisualElement drawer =
                new VisualElement()
                    .SetStyleBackgroundColor((Color)backgroundColor)
                    .SetStyleBorderWidth(1)
                    .SetStyleBorderColor((Color)borderColor)
                    .SetStyleBorderRadius(DesignUtils.k_FieldBorderRadius)
                    .SetStylePadding(DesignUtils.k_Spacing);

            SerializedProperty propertyGameObjectName = property.FindPropertyRelative(nameof(TextSettings.GameObjectName));
            SerializedProperty propertyText = property.FindPropertyRelative(nameof(TextSettings.Text));
            SerializedProperty propertyFontSize = property.FindPropertyRelative(nameof(TextSettings.FontSize));

            FluidField textFluidField =
                FluidField.Get("Text")
                    .SetElementSize(ElementSize.Small)
                    .AddFieldContent
                    (
                        DesignUtils.NewTextField(propertyText)
                            .SetStyleFlexGrow(1)
                    );

            FluidField fontSizeFluidField =
                FluidField.Get("Font Size")
                    .SetElementSize(ElementSize.Small)
                    .AddFieldContent
                    (
                        DesignUtils.NewIntegerField(propertyFontSize)
                            .SetStyleFlexGrow(1)
                    );

            drawer
                .AddChild
                (
                    DesignUtils.fieldLabel
                        .SetText(propertyGameObjectName.stringValue)
                        .SetStyleFontSize(14)
                )
                .AddSpaceBlock()
                .AddChild(textFluidField)
                .AddSpaceBlock()
                .AddChild(fontSizeFluidField)
                ;

            return drawer;
        }
    }
}
