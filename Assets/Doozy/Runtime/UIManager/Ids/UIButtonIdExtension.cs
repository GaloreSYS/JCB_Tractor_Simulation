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
namespace Doozy.Runtime.UIManager.Components
{
    public partial class UIButton
    {
        public static IEnumerable<UIButton> GetButtons(UIButtonId.CourseTLB id) => GetButtons(nameof(UIButtonId.CourseTLB), id.ToString());
        public static bool SelectButton(UIButtonId.CourseTLB id) => SelectButton(nameof(UIButtonId.CourseTLB), id.ToString());

        public static IEnumerable<UIButton> GetButtons(UIButtonId.CourseTractor id) => GetButtons(nameof(UIButtonId.CourseTractor), id.ToString());
        public static bool SelectButton(UIButtonId.CourseTractor id) => SelectButton(nameof(UIButtonId.CourseTractor), id.ToString());

        public static IEnumerable<UIButton> GetButtons(UIButtonId.OnBoarding id) => GetButtons(nameof(UIButtonId.OnBoarding), id.ToString());
        public static bool SelectButton(UIButtonId.OnBoarding id) => SelectButton(nameof(UIButtonId.OnBoarding), id.ToString());
        public static IEnumerable<UIButton> GetButtons(UIButtonId.VehicleSelection id) => GetButtons(nameof(UIButtonId.VehicleSelection), id.ToString());
        public static bool SelectButton(UIButtonId.VehicleSelection id) => SelectButton(nameof(UIButtonId.VehicleSelection), id.ToString());
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIButtonId
    {
        public enum CourseTLB
        {
            Back,
            Digging
        }

        public enum CourseTractor
        {
            Back,
            Plowing
        }

        public enum OnBoarding
        {
            Back,
            BackVehicle,
            Continue,
            TLBButton,
            TractorButton
        }
        public enum VehicleSelection
        {
            Back,
            TLB,
            Tractor
        }    
    }
}
