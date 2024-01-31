// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections.Generic;
using System.Linq;
using Doozy.Editor.EditorUI;
using Doozy.Editor.EditorUI.Components;
using Doozy.Editor.EditorUI.Components.Internal;
using Doozy.Editor.EditorUI.ScriptableObjects.Colors;
using Doozy.Editor.EditorUI.Utils;
using Doozy.Runtime.UIElements.Extensions;
using TMPro;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
// ReSharper disable CheckNamespace

namespace Doozy.Sandbox.AnimatedTitles.Editor
{
    [CustomEditor(typeof(AnimatedTitlesController), true)]
    public class AnimatedTitlesControllerEditor : UnityEditor.Editor
    {
        private static IEnumerable<Texture2D> componentIconTextures => EditorSpriteSheets.EditorUI.Icons.Unity;
        private static Color accentColor => EditorColors.EditorUI.Amber;
        private static EditorSelectableColorInfo selectableAccentColor => EditorSelectableColors.EditorUI.Amber;

        private AnimatedTitlesController castedTarget => (AnimatedTitlesController)target;

        private VisualElement root { get; set; }
        private FluidComponentHeader componentHeader { get; set; }

        private FluidField infoLabelFluidField { get; set; }

        private FluidButton loadFirstButton { get; set; }
        private FluidButton loadPreviousButton { get; set; }
        private FluidButton showHideButton { get; set; }
        private FluidButton continuousPlayButton { get; set; }
        private FluidButton stopContinuousPlayButton { get; set; }
        private FluidButton loadNextButton { get; set; }
        private FluidButton loadLastButton { get; set; }

        private FluidToggleSwitch useRandomTitlesSwitch { get; set; }

        private PropertyField titleSettingsPropertyField { get; set; }
        private PropertyField subtitleSettingsPropertyField { get; set; }
        private PropertyField captionSettingsPropertyField { get; set; }
        private ObjectField infoLabelObjectField { get; set; }

        private SerializedProperty propertyPrefabs { get; set; }
        private SerializedProperty propertyTitleSettings { get; set; }
        private SerializedProperty propertySubtitleSettings { get; set; }
        private SerializedProperty propertyCaptionSettings { get; set; }
        private SerializedProperty propertyInfoLabel { get; set; }
        private SerializedProperty propertyUseRandomTitles { get; set; }
        private SerializedProperty propertyOnFinished { get; set; }

        private FluidButton applySettingsToPrefabTitlesButton { get; set; }

        private void OnEnable()
        {
            castedTarget.CreateInfoLabel();
        }

        public override VisualElement CreateInspectorGUI()
        {
            InitializeEditor();
            Compose();
            return root;
        }

        private void OnDestroy()
        {
            componentHeader?.Recycle();
        }

        private void FindProperties()
        {
            propertyPrefabs = serializedObject.FindProperty(nameof(AnimatedTitlesController.Prefabs));
            propertyTitleSettings = serializedObject.FindProperty(nameof(AnimatedTitlesController.TitleSettings));
            propertySubtitleSettings = serializedObject.FindProperty(nameof(AnimatedTitlesController.SubtitleSettings));
            propertyCaptionSettings = serializedObject.FindProperty(nameof(AnimatedTitlesController.CaptionSettings));
            propertyInfoLabel = serializedObject.FindProperty(nameof(AnimatedTitlesController.InfoLabel));
            propertyUseRandomTitles = serializedObject.FindProperty(nameof(AnimatedTitlesController.UseRandomTitles));
            propertyOnFinished = serializedObject.FindProperty(nameof(AnimatedTitlesController.OnFinished));
        }

        private void InitializeEditor()
        {
            FindProperties();

            root = new VisualElement();

            componentHeader =
                FluidComponentHeader.Get()
                    .SetElementSize(ElementSize.Large)
                    .SetAccentColor(accentColor)
                    .SetComponentNameText("Animated Titles")
                    .SetComponentTypeText("Controller")
                    .SetIcon(componentIconTextures.ToList());

            InitializeControls();

            useRandomTitlesSwitch = FluidToggleSwitch.Get("Use Random Titles").BindToProperty(propertyUseRandomTitles).SetToggleAccentColor(selectableAccentColor);

            InitializePrefabs();
            InitializeCleanTitlesButton();

            titleSettingsPropertyField = DesignUtils.NewPropertyField(propertyTitleSettings);
            subtitleSettingsPropertyField = DesignUtils.NewPropertyField(propertySubtitleSettings);
            captionSettingsPropertyField = DesignUtils.NewPropertyField(propertyCaptionSettings);

            infoLabelObjectField = DesignUtils.NewObjectField(propertyInfoLabel, typeof(TMP_Text)).SetStyleFlexGrow(1);
            infoLabelFluidField = FluidField.Get("Info Label").AddFieldContent(infoLabelObjectField);
        }

        private static IEnumerable<Texture2D> loadFirstIcon => EditorSpriteSheets.EditorUI.Icons.FirstFrame;
        private static IEnumerable<Texture2D> previousIcon => EditorSpriteSheets.EditorUI.Arrows.ChevronLeft;
        private static IEnumerable<Texture2D> showHideIcon => EditorSpriteSheets.EditorUI.Icons.VisibilityChanged;
        private static IEnumerable<Texture2D> nextIcon => EditorSpriteSheets.EditorUI.Arrows.ChevronRight;
        private static IEnumerable<Texture2D> loadLastIcon => EditorSpriteSheets.EditorUI.Icons.LastFrame;

        private static IEnumerable<Texture2D> stopIcon => EditorSpriteSheets.EditorUI.Icons.Stop;
        private static IEnumerable<Texture2D> playIcon => EditorSpriteSheets.EditorUI.Icons.Play;

        private void InitializeControls()
        {

            FluidButton Button(IEnumerable<Texture2D> icon) =>
                FluidButton.Get()
                    .SetIcon(icon)
                    .SetButtonStyle(ButtonStyle.Contained)
                    .SetElementSize(ElementSize.Small)
                    .SetAccentColor(selectableAccentColor);


            loadFirstButton = Button(loadFirstIcon).SetTooltip("First").SetOnClick(() => castedTarget.LoadFirst(true));
            loadPreviousButton = Button(previousIcon).SetTooltip("Previous").SetOnClick(() => castedTarget.LoadPrevious(true));
            showHideButton = Button(showHideIcon).SetLabelText("Show / Hide").SetElementSize(ElementSize.Normal).SetOnClick(() => castedTarget.ShowHide());
            loadNextButton = Button(nextIcon).SetTooltip("Next").SetOnClick(() => castedTarget.LoadNext(true));
            loadLastButton = Button(loadLastIcon).SetTooltip("Last").SetOnClick(() => castedTarget.LoadLast(true));

            continuousPlayButton = Button(playIcon).SetLabelText("Continuous Play").SetOnClick(() => castedTarget.PlayAll());
            stopContinuousPlayButton = Button(stopIcon).SetLabelText("Stop").SetOnClick(() => castedTarget.StopContinuousPlay());
        }

        private void InitializeCleanTitlesButton()
        {

            applySettingsToPrefabTitlesButton =
                FluidButton.Get("Apply Settings to Prefab Titles")
                    .SetButtonStyle(ButtonStyle.Contained)
                    .SetElementSize(ElementSize.Normal)
                    .SetIcon(EditorSpriteSheets.EditorUI.Icons.MagicWand)
                    .SetOnClick(() =>
                    {
                        const string title = AnimatedTitlesController.k_Title;
                        const string subtitle = AnimatedTitlesController.k_Subtitle;
                        const string caption = AnimatedTitlesController.k_Caption;

                        int numberOfTitles = 0;
                        int numberOfSubtitles = 0;
                        int numberOfCaptions = 0;
                        foreach (GameObject prefab in castedTarget.Prefabs)
                        {
                            TMP_Text[] texts = prefab.GetComponentsInChildren<TMP_Text>();
                            foreach (TMP_Text t in texts)
                            {
                                if (t.name.Contains(subtitle))
                                {
                                    t.text = castedTarget.SubtitleSettings.Text;
                                    t.fontSize = castedTarget.SubtitleSettings.FontSize;
                                    numberOfSubtitles++;
                                }
                                else if (t.name.Contains(title))
                                {
                                    t.text = castedTarget.TitleSettings.Text;
                                    t.fontSize = castedTarget.TitleSettings.FontSize;
                                    numberOfTitles++;
                                }
                                else if (t.name.Contains(caption))
                                {
                                    t.text = castedTarget.CaptionSettings.Text;
                                    t.fontSize = castedTarget.CaptionSettings.FontSize;
                                    numberOfCaptions++;
                                }
                                else
                                {
                                    Debug.Log($"Check the '{prefab.name}' prefab for a typo in titles GameObject names");
                                    t.text = "Check GameObject Name";
                                }

                            }
                            EditorUtility.SetDirty(prefab);
                            AssetDatabase.SaveAssetIfDirty(prefab);
                        }

                        Debug.Log($"Cleaned {castedTarget.Prefabs.Count} titles. Found {numberOfTitles} titles, {numberOfSubtitles} subtitles and {numberOfCaptions} captions.");
                    });
        }

        private FluidListView prefabsListView { get; set; }

        private void InitializePrefabs()
        {

            prefabsListView = DesignUtils.NewObjectListView(propertyPrefabs, "Prefabs", "Animated titles prefabs used by this controller", typeof(GameObject));
            prefabsListView
                .AddToolbarElement(DesignUtils.flexibleSpace)
                .AddToolbarElement
                (
                    FluidListView.Buttons.clearButton
                        .SetOnClick(() =>
                            {
                                propertyPrefabs.ClearArray();
                                propertyPrefabs.serializedObject.ApplyModifiedProperties();
                            }
                        ));
        }

        private void Compose()
        {
            root
                .AddChild(componentHeader)
                .AddChild(DesignUtils.spaceBlock)
                .AddChild
                (
                    DesignUtils.row
                        .SetStyleAlignItems(Align.Center)
                        .AddChild(loadFirstButton)
                        .AddChild(DesignUtils.spaceBlock)
                        .AddChild(loadPreviousButton)
                        .AddChild(DesignUtils.spaceBlock)
                        .AddChild(showHideButton)
                        .AddChild(DesignUtils.spaceBlock)
                        .AddChild(loadNextButton)
                        .AddChild(DesignUtils.spaceBlock)
                        .AddChild(loadLastButton)
                        .AddChild(DesignUtils.flexibleSpace)
                        .AddChild(DesignUtils.spaceBlock4X)
                        .AddChild(continuousPlayButton)
                        .AddChild(DesignUtils.spaceBlock)
                        .AddChild(stopContinuousPlayButton)
                        .AddChild(DesignUtils.spaceBlock)
                )
                .AddChild(DesignUtils.spaceBlock2X)
                .AddChild(useRandomTitlesSwitch)
                .AddChild(DesignUtils.spaceBlock)
                .AddChild(infoLabelFluidField)
                .AddChild(DesignUtils.spaceBlock2X)
                .AddChild(prefabsListView)
                .AddChild(DesignUtils.spaceBlock2X)
                .AddChild
                (
                    FluidField.Get("Prefab Tools for Animated Titles")
                        .AddFieldContent
                        (
                            DesignUtils.column
                                .AddChild(DesignUtils.spaceBlock)
                                .AddChild
                                (
                                    DesignUtils.row
                                        .AddChild(titleSettingsPropertyField)
                                        .AddChild(DesignUtils.spaceBlock)
                                        .AddChild(subtitleSettingsPropertyField)
                                        .AddChild(DesignUtils.spaceBlock)
                                        .AddChild(captionSettingsPropertyField)
                                )
                                .AddChild(DesignUtils.spaceBlock2X)
                                .AddChild
                                (
                                    DesignUtils.row
                                        .AddChild(DesignUtils.flexibleSpace)
                                        .AddChild(applySettingsToPrefabTitlesButton)
                                        .AddChild(DesignUtils.flexibleSpace)
                                )
                                .AddChild(DesignUtils.spaceBlock2X)
                        )
                )
                .AddChild(DesignUtils.spaceBlock2X)
                .AddChild(DesignUtils.NewPropertyField(propertyOnFinished))
                .AddChild(DesignUtils.endOfLineBlock)
                ;
        }
    }
}
