// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.CourseSelectionTractor id) => GetViews(nameof(UIViewId.CourseSelectionTractor), id.ToString());
        public static void Show(UIViewId.CourseSelectionTractor id, bool instant = false) => Show(nameof(UIViewId.CourseSelectionTractor), id.ToString(), instant);
        public static void Hide(UIViewId.CourseSelectionTractor id, bool instant = false) => Hide(nameof(UIViewId.CourseSelectionTractor), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.OnBoarding id) => GetViews(nameof(UIViewId.OnBoarding), id.ToString());
        public static void Show(UIViewId.OnBoarding id, bool instant = false) => Show(nameof(UIViewId.OnBoarding), id.ToString(), instant);
        public static void Hide(UIViewId.OnBoarding id, bool instant = false) => Hide(nameof(UIViewId.OnBoarding), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum CourseSelectionTractor
        {
            CourseSelectionTractor
        }

        public enum OnBoarding
        {
            CourseSelectionTLB,
            CourseSelectionTractor,
            LoadingScreen,
            Login,
            Splash,
            VehicleSelection
        }    
    }
}
