// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using UnityEditor;
// ReSharper disable All
namespace Doozy.Editor.UIManager.UIMenu
{
    public static class UIMenuContextMenu
    {
        private const int MENU_ITEM_PRIORITY = 7;
        private const string MENU_PATH = "GameObject/Doozy/UIMenu";

        public static class Components
        {
            private const string TYPE_NAME = "Components";
            private const string TYPE_MENU_PATH = MENU_PATH + "/" + TYPE_NAME + "/";

            public static class ButtonBasic
            {
                private const string CATEGORY_NAME = "Button Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Flex Button", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexButton(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexButton");

                [MenuItem(CATEGORY_MENU_PATH + "Flex Icon Button", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexIconButton(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexIconButton");

                [MenuItem(CATEGORY_MENU_PATH + "Icon Button", false, MENU_ITEM_PRIORITY)]
                public static void CreateIconButton(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "IconButton");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Button", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleButton(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleButton");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Icon Button", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleIconButton(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleIconButton");
            }

            public static class ButtonDirection
            {
                private const string CATEGORY_NAME = "Button Direction";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Arrow Down", false, MENU_ITEM_PRIORITY)]
                public static void CreateArrowDown(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ArrowDown");

                [MenuItem(CATEGORY_MENU_PATH + "Arrow Left", false, MENU_ITEM_PRIORITY)]
                public static void CreateArrowLeft(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ArrowLeft");

                [MenuItem(CATEGORY_MENU_PATH + "Arrow Right", false, MENU_ITEM_PRIORITY)]
                public static void CreateArrowRight(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ArrowRight");

                [MenuItem(CATEGORY_MENU_PATH + "Arrow Up", false, MENU_ITEM_PRIORITY)]
                public static void CreateArrowUp(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ArrowUp");

                [MenuItem(CATEGORY_MENU_PATH + "Chevron Down", false, MENU_ITEM_PRIORITY)]
                public static void CreateChevronDown(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ChevronDown");

                [MenuItem(CATEGORY_MENU_PATH + "Chevron Left", false, MENU_ITEM_PRIORITY)]
                public static void CreateChevronLeft(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ChevronLeft");

                [MenuItem(CATEGORY_MENU_PATH + "Chevron Right", false, MENU_ITEM_PRIORITY)]
                public static void CreateChevronRight(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ChevronRight");

                [MenuItem(CATEGORY_MENU_PATH + "Chevron Up", false, MENU_ITEM_PRIORITY)]
                public static void CreateChevronUp(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ChevronUp");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Arrow Down", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleArrowDown(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleArrowDown");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Arrow Left", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleArrowLeft(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleArrowLeft");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Arrow Right", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleArrowRight(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleArrowRight");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Arrow Up", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleArrowUp(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleArrowUp");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Chevron Down", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleChevronDown(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleChevronDown");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Chevron Left", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleChevronLeft(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleChevronLeft");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Chevron Right", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleChevronRight(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleChevronRight");

                [MenuItem(CATEGORY_MENU_PATH + "Circle Chevron Up", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleChevronUp(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleChevronUp");
            }

            public static class ButtonGeneral
            {
                private const string CATEGORY_NAME = "Button General";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "AddToCart", false, MENU_ITEM_PRIORITY)]
                public static void CreateAddToCart(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "AddToCart");

                [MenuItem(CATEGORY_MENU_PATH + "AddToCart Bag", false, MENU_ITEM_PRIORITY)]
                public static void CreateAddToCartBag(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "AddToCartBag");

                [MenuItem(CATEGORY_MENU_PATH + "AddToFavorites", false, MENU_ITEM_PRIORITY)]
                public static void CreateAddToFavorites(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "AddToFavorites");

                [MenuItem(CATEGORY_MENU_PATH + "Calendar", false, MENU_ITEM_PRIORITY)]
                public static void CreateCalendar(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Calendar");

                [MenuItem(CATEGORY_MENU_PATH + "Calendar Days", false, MENU_ITEM_PRIORITY)]
                public static void CreateCalendarDays(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CalendarDays");

                [MenuItem(CATEGORY_MENU_PATH + "Camera", false, MENU_ITEM_PRIORITY)]
                public static void CreateCamera(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Camera");

                [MenuItem(CATEGORY_MENU_PATH + "Close XMark", false, MENU_ITEM_PRIORITY)]
                public static void CreateCloseXMark(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CloseXMark");

                [MenuItem(CATEGORY_MENU_PATH + "Gamepad", false, MENU_ITEM_PRIORITY)]
                public static void CreateGamepad(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Gamepad");

                [MenuItem(CATEGORY_MENU_PATH + "Gift", false, MENU_ITEM_PRIORITY)]
                public static void CreateGift(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Gift");

                [MenuItem(CATEGORY_MENU_PATH + "Globe", false, MENU_ITEM_PRIORITY)]
                public static void CreateGlobe(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Globe");

                [MenuItem(CATEGORY_MENU_PATH + "Id Badge", false, MENU_ITEM_PRIORITY)]
                public static void CreateIdBadge(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "IdBadge");

                [MenuItem(CATEGORY_MENU_PATH + "Key", false, MENU_ITEM_PRIORITY)]
                public static void CreateKey(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Key");

                [MenuItem(CATEGORY_MENU_PATH + "Language", false, MENU_ITEM_PRIORITY)]
                public static void CreateLanguage(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Language");

                [MenuItem(CATEGORY_MENU_PATH + "Map", false, MENU_ITEM_PRIORITY)]
                public static void CreateMap(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Map");

                [MenuItem(CATEGORY_MENU_PATH + "Minus", false, MENU_ITEM_PRIORITY)]
                public static void CreateMinus(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Minus");

                [MenuItem(CATEGORY_MENU_PATH + "Plus", false, MENU_ITEM_PRIORITY)]
                public static void CreatePlus(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Plus");

                [MenuItem(CATEGORY_MENU_PATH + "Redo", false, MENU_ITEM_PRIORITY)]
                public static void CreateRedo(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Redo");

                [MenuItem(CATEGORY_MENU_PATH + "Refresh", false, MENU_ITEM_PRIORITY)]
                public static void CreateRefresh(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Refresh");

                [MenuItem(CATEGORY_MENU_PATH + "Reply", false, MENU_ITEM_PRIORITY)]
                public static void CreateReply(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Reply");

                [MenuItem(CATEGORY_MENU_PATH + "ReportBug", false, MENU_ITEM_PRIORITY)]
                public static void CreateReportBug(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ReportBug");

                [MenuItem(CATEGORY_MENU_PATH + "Search", false, MENU_ITEM_PRIORITY)]
                public static void CreateSearch(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Search");

                [MenuItem(CATEGORY_MENU_PATH + "SendEmail", false, MENU_ITEM_PRIORITY)]
                public static void CreateSendEmail(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SendEmail");

                [MenuItem(CATEGORY_MENU_PATH + "Share", false, MENU_ITEM_PRIORITY)]
                public static void CreateShare(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Share");

                [MenuItem(CATEGORY_MENU_PATH + "Share Nodes", false, MENU_ITEM_PRIORITY)]
                public static void CreateShareNodes(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ShareNodes");

                [MenuItem(CATEGORY_MENU_PATH + "Star", false, MENU_ITEM_PRIORITY)]
                public static void CreateStar(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Star");

                [MenuItem(CATEGORY_MENU_PATH + "Tag", false, MENU_ITEM_PRIORITY)]
                public static void CreateTag(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Tag");

                [MenuItem(CATEGORY_MENU_PATH + "Undo", false, MENU_ITEM_PRIORITY)]
                public static void CreateUndo(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Undo");

                [MenuItem(CATEGORY_MENU_PATH + "User", false, MENU_ITEM_PRIORITY)]
                public static void CreateUser(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "User");

                [MenuItem(CATEGORY_MENU_PATH + "Users", false, MENU_ITEM_PRIORITY)]
                public static void CreateUsers(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Users");
            }

            public static class ButtonMedia
            {
                private const string CATEGORY_NAME = "Button Media";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Backward", false, MENU_ITEM_PRIORITY)]
                public static void CreateBackward(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Backward");

                [MenuItem(CATEGORY_MENU_PATH + "Backward Step", false, MENU_ITEM_PRIORITY)]
                public static void CreateBackwardStep(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "BackwardStep");

                [MenuItem(CATEGORY_MENU_PATH + "Forward", false, MENU_ITEM_PRIORITY)]
                public static void CreateForward(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Forward");

                [MenuItem(CATEGORY_MENU_PATH + "Forward Step", false, MENU_ITEM_PRIORITY)]
                public static void CreateForwardStep(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "ForwardStep");

                [MenuItem(CATEGORY_MENU_PATH + "Pause", false, MENU_ITEM_PRIORITY)]
                public static void CreatePause(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Pause");

                [MenuItem(CATEGORY_MENU_PATH + "Play", false, MENU_ITEM_PRIORITY)]
                public static void CreatePlay(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Play");

                [MenuItem(CATEGORY_MENU_PATH + "PlayPause", false, MENU_ITEM_PRIORITY)]
                public static void CreatePlayPause(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "PlayPause");

                [MenuItem(CATEGORY_MENU_PATH + "Repeat", false, MENU_ITEM_PRIORITY)]
                public static void CreateRepeat(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Repeat");

                [MenuItem(CATEGORY_MENU_PATH + "Stop", false, MENU_ITEM_PRIORITY)]
                public static void CreateStop(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Stop");
            }

            public static class ProgressorBasic
            {
                private const string CATEGORY_NAME = "Progressor Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Simple Progress Bar", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleProgressBar(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleProgressBar");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Progress Text", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleProgressText(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleProgressText");
            }

            public static class ScrollbarBasic
            {
                private const string CATEGORY_NAME = "Scrollbar Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Simple Scrollbar", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleScrollbar(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleScrollbar");
            }

            public static class SliderBasic
            {
                private const string CATEGORY_NAME = "Slider Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Simple Slider", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleSlider(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleSlider");
            }

            public static class StepperBasic
            {
                private const string CATEGORY_NAME = "Stepper Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Counter Stepper H", false, MENU_ITEM_PRIORITY)]
                public static void CreateCounterStepperH(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CounterStepperH");

                [MenuItem(CATEGORY_MENU_PATH + "Counter Stepper V", false, MENU_ITEM_PRIORITY)]
                public static void CreateCounterStepperV(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CounterStepperV");

                [MenuItem(CATEGORY_MENU_PATH + "Flex Stepper H", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexStepperH(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexStepperH");

                [MenuItem(CATEGORY_MENU_PATH + "Flex Stepper V", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexStepperV(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexStepperV");

                [MenuItem(CATEGORY_MENU_PATH + "Quanity Stepper H", false, MENU_ITEM_PRIORITY)]
                public static void CreateQuanityStepperH(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "QuanityStepperH");

                [MenuItem(CATEGORY_MENU_PATH + "Quantity Stepper V", false, MENU_ITEM_PRIORITY)]
                public static void CreateQuantityStepperV(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "QuantityStepperV");

                [MenuItem(CATEGORY_MENU_PATH + "Round Stepper H", false, MENU_ITEM_PRIORITY)]
                public static void CreateRoundStepperH(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "RoundStepperH");

                [MenuItem(CATEGORY_MENU_PATH + "Round Stepper V", false, MENU_ITEM_PRIORITY)]
                public static void CreateRoundStepperV(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "RoundStepperV");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Stepper H", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleStepperH(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleStepperH");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Stepper V", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleStepperV(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleStepperV");

                [MenuItem(CATEGORY_MENU_PATH + "Slider Stepper H", false, MENU_ITEM_PRIORITY)]
                public static void CreateSliderStepperH(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SliderStepperH");

                [MenuItem(CATEGORY_MENU_PATH + "Slider Stepper V", false, MENU_ITEM_PRIORITY)]
                public static void CreateSliderStepperV(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SliderStepperV");
            }

            public static class TabBasic
            {
                private const string CATEGORY_NAME = "Tab Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Flex Icon Tab", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexIconTab(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexIconTab");

                [MenuItem(CATEGORY_MENU_PATH + "Flex Tab", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexTab(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexTab");

                [MenuItem(CATEGORY_MENU_PATH + "Icon Tab", false, MENU_ITEM_PRIORITY)]
                public static void CreateIconTab(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "IconTab");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Icon Tab", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleIconTab(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleIconTab");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Tab", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleTab(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleTab");
            }

            public static class ToggleCheckbox
            {
                private const string CATEGORY_NAME = "Toggle Checkbox";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Checkbox", false, MENU_ITEM_PRIORITY)]
                public static void CreateCheckbox(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Checkbox");

                [MenuItem(CATEGORY_MENU_PATH + "Flex Checkbox", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexCheckbox(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexCheckbox");
            }

            public static class ToggleIcon
            {
                private const string CATEGORY_NAME = "Toggle Icon";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Icon Toggle", false, MENU_ITEM_PRIORITY)]
                public static void CreateIconToggle(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "IconToggle");
            }

            public static class ToggleRadio
            {
                private const string CATEGORY_NAME = "Toggle Radio";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Flex Radio", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexRadio(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexRadio");

                [MenuItem(CATEGORY_MENU_PATH + "Radio", false, MENU_ITEM_PRIORITY)]
                public static void CreateRadio(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Radio");
            }

            public static class ToggleSwitch
            {
                private const string CATEGORY_NAME = "Toggle Switch";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Flex Switch", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlexSwitch(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlexSwitch");

                [MenuItem(CATEGORY_MENU_PATH + "Switch", false, MENU_ITEM_PRIORITY)]
                public static void CreateSwitch(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Switch");
            }
        }

        public static class Containers
        {
            private const string TYPE_NAME = "Containers";
            private const string TYPE_MENU_PATH = MENU_PATH + "/" + TYPE_NAME + "/";

            public static class ContainerBasic
            {
                private const string CATEGORY_NAME = "Container Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Simple Container", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleContainer(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleContainer");
            }

            public static class TabLayout
            {
                private const string CATEGORY_NAME = "Tab Layout";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Bottom Expanded", false, MENU_ITEM_PRIORITY)]
                public static void CreateBottomExpanded(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "BottomExpanded");

                [MenuItem(CATEGORY_MENU_PATH + "Bottom Left", false, MENU_ITEM_PRIORITY)]
                public static void CreateBottomLeft(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "BottomLeft");

                [MenuItem(CATEGORY_MENU_PATH + "Bottom Right", false, MENU_ITEM_PRIORITY)]
                public static void CreateBottomRight(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "BottomRight");

                [MenuItem(CATEGORY_MENU_PATH + "Left Bottom", false, MENU_ITEM_PRIORITY)]
                public static void CreateLeftBottom(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "LeftBottom");

                [MenuItem(CATEGORY_MENU_PATH + "Left Expanded", false, MENU_ITEM_PRIORITY)]
                public static void CreateLeftExpanded(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "LeftExpanded");

                [MenuItem(CATEGORY_MENU_PATH + "Left Top", false, MENU_ITEM_PRIORITY)]
                public static void CreateLeftTop(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "LeftTop");

                [MenuItem(CATEGORY_MENU_PATH + "Right Bottom", false, MENU_ITEM_PRIORITY)]
                public static void CreateRightBottom(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "RightBottom");

                [MenuItem(CATEGORY_MENU_PATH + "Right Expanded", false, MENU_ITEM_PRIORITY)]
                public static void CreateRightExpanded(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "RightExpanded");

                [MenuItem(CATEGORY_MENU_PATH + "Right Top", false, MENU_ITEM_PRIORITY)]
                public static void CreateRightTop(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "RightTop");

                [MenuItem(CATEGORY_MENU_PATH + "Top Expanded", false, MENU_ITEM_PRIORITY)]
                public static void CreateTopExpanded(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "TopExpanded");

                [MenuItem(CATEGORY_MENU_PATH + "Top Left", false, MENU_ITEM_PRIORITY)]
                public static void CreateTopLeft(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "TopLeft");

                [MenuItem(CATEGORY_MENU_PATH + "Top Right", false, MENU_ITEM_PRIORITY)]
                public static void CreateTopRight(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "TopRight");
            }

            public static class ViewBasic
            {
                private const string CATEGORY_NAME = "View Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Simple View", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleView(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleView");
            }
        }

        public static class Content
        {
            private const string TYPE_NAME = "Content";
            private const string TYPE_MENU_PATH = MENU_PATH + "/" + TYPE_NAME + "/";

            public static class Basic
            {
                private const string CATEGORY_NAME = "Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Dark Overlay", false, MENU_ITEM_PRIORITY)]
                public static void CreateDarkOverlay(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "DarkOverlay");

                [MenuItem(CATEGORY_MENU_PATH + "Light Overlay", false, MENU_ITEM_PRIORITY)]
                public static void CreateLightOverlay(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "LightOverlay");

                [MenuItem(CATEGORY_MENU_PATH + "Simple Card", false, MENU_ITEM_PRIORITY)]
                public static void CreateSimpleCard(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SimpleCard");
            }

            public static class ProductCard
            {
                private const string CATEGORY_NAME = "Product Card";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Card 001", false, MENU_ITEM_PRIORITY)]
                public static void CreateCard001(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Card001");

                [MenuItem(CATEGORY_MENU_PATH + "Card 002", false, MENU_ITEM_PRIORITY)]
                public static void CreateCard002(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Card002");

                [MenuItem(CATEGORY_MENU_PATH + "Card 003", false, MENU_ITEM_PRIORITY)]
                public static void CreateCard003(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Card003");

                [MenuItem(CATEGORY_MENU_PATH + "Card 004", false, MENU_ITEM_PRIORITY)]
                public static void CreateCard004(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Card004");

                [MenuItem(CATEGORY_MENU_PATH + "Card 005", false, MENU_ITEM_PRIORITY)]
                public static void CreateCard005(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Card005");
            }

            public static class SpinnerBasic
            {
                private const string CATEGORY_NAME = "Spinner Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Circle Spinner", false, MENU_ITEM_PRIORITY)]
                public static void CreateCircleSpinner(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "CircleSpinner");

                [MenuItem(CATEGORY_MENU_PATH + "Rim Circle Spinner", false, MENU_ITEM_PRIORITY)]
                public static void CreateRimCircleSpinner(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "RimCircleSpinner");

                [MenuItem(CATEGORY_MENU_PATH + "Square Spinner", false, MENU_ITEM_PRIORITY)]
                public static void CreateSquareSpinner(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "SquareSpinner");
            }
        }

        public static class Layouts
        {
            private const string TYPE_NAME = "Layouts";
            private const string TYPE_MENU_PATH = MENU_PATH + "/" + TYPE_NAME + "/";

            public static class Basic
            {
                private const string CATEGORY_NAME = "Basic";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Grid", false, MENU_ITEM_PRIORITY)]
                public static void CreateGrid(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Grid");

                [MenuItem(CATEGORY_MENU_PATH + "Horizontal", false, MENU_ITEM_PRIORITY)]
                public static void CreateHorizontal(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Horizontal");

                [MenuItem(CATEGORY_MENU_PATH + "Radial", false, MENU_ITEM_PRIORITY)]
                public static void CreateRadial(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Radial");

                [MenuItem(CATEGORY_MENU_PATH + "Vertical", false, MENU_ITEM_PRIORITY)]
                public static void CreateVertical(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "Vertical");
            }
        }

        public static class Scripts
        {
            private const string TYPE_NAME = "Scripts";
            private const string TYPE_MENU_PATH = MENU_PATH + "/" + TYPE_NAME + "/";

            public static class Controller
            {
                private const string CATEGORY_NAME = "Controller";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "Flow Controller", false, MENU_ITEM_PRIORITY)]
                public static void CreateFlowController(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "FlowController");
            }
        }

        public static class AnimatedTitles
        {
            private const string TYPE_NAME = "Animated Titles";
            private const string TYPE_MENU_PATH = MENU_PATH + "/" + TYPE_NAME + "/";

            public static class Minimalist1
            {
                private const string CATEGORY_NAME = "Minimalist 1";
                private const string CATEGORY_MENU_PATH = TYPE_MENU_PATH + CATEGORY_NAME + "/";

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 001", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title001(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title001");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 002", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title002(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title002");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 003", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title003(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title003");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 004", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title004(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title004");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 005", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title005(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title005");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 006", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title006(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title006");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 007", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title007(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title007");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 008", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title008(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title008");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 009", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title009(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title009");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 010", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title010(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title010");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 011", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title011(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title011");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 012", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title012(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title012");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 013", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title013(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title013");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 014", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title014(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title014");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 015", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title015(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title015");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 016", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title016(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title016");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 017", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title017(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title017");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 018", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title018(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title018");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 019", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title019(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title019");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 020", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title020(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title020");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 021", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title021(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title021");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 022", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title022(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title022");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 023", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title023(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title023");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 024", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title024(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title024");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 025", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title025(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title025");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 026", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title026(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title026");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 027", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title027(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title027");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 028", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title028(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title028");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 029", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title029(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title029");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 030", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title030(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title030");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 031", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title031(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title031");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 032", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title032(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title032");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 033", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title033(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title033");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 034", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title034(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title034");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 035", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title035(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title035");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 036", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title036(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title036");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 037", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title037(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title037");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 038", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title038(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title038");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 039", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title039(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title039");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 040", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title040(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title040");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 041", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title041(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title041");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 042", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title042(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title042");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 043", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title043(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title043");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 044", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title044(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title044");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 045", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title045(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title045");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 046", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title046(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title046");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 047", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title047(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title047");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 048", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title048(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title048");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 049", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title049(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title049");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 050", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title050(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title050");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 051", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title051(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title051");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 052", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title052(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title052");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 053", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title053(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title053");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 054", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title054(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title054");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 055", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title055(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title055");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 056", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title056(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title056");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 057", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title057(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title057");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 058", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title058(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title058");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 059", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title059(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title059");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 060", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title060(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title060");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 061", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title061(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title061");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 062", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title062(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title062");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 063", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title063(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title063");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 064", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title064(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title064");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 065", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title065(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title065");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 066", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title066(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title066");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 067", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title067(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title067");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 068", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title068(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title068");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 069", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title069(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title069");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 070", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title070(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title070");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 071", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title071(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title071");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 072", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title072(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title072");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 073", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title073(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title073");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 074", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title074(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title074");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 075", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title075(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title075");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 076", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title076(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title076");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 077", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title077(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title077");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 078", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title078(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title078");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 079", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title079(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title079");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 080", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title080(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title080");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 081", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title081(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title081");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 082", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title082(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title082");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 083", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title083(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title083");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 084", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title084(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title084");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 085", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title085(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title085");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 086", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title086(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title086");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 087", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title087(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title087");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 088", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title088(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title088");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 089", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title089(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title089");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 090", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title090(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title090");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 091", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title091(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title091");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 092", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title092(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title092");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 093", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title093(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title093");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 094", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title094(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title094");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 095", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title095(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title095");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 096", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title096(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title096");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 097", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title097(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title097");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 098", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title098(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title098");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 099", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title099(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title099");

                [MenuItem(CATEGORY_MENU_PATH + "M1 Title 100", false, MENU_ITEM_PRIORITY)]
                public static void CreateM1Title100(MenuCommand command) => UIMenuUtils.AddToScene(TYPE_NAME, CATEGORY_NAME, "M1Title100");
            }
        }        
    }
}

