// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections.Generic;
using System.Linq;
using Doozy.Runtime.Common.Extensions;
using TMPro;
using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable CheckNamespace

namespace Doozy.Sandbox.AnimatedTitles
{
    public static class AnimatedTitleUtils
    {
        public const string k_Title = "Title";
        public const string k_Subtitle = "Subtitle";
        public const string k_Caption = "Caption";

        public static GameObject SetRandomTitle(GameObject target)
        {
            TMP_Text[] texts = target.GetComponentsInChildren<TMP_Text>();

            bool hasCaption = texts.Any(t => t.name.Contains(k_Caption));
            bool hasSubtitle = texts.Any(t => t.name.Contains(k_Subtitle));
            bool hasTitle = texts.Any(t => !t.name.Contains(k_Subtitle) & t.name.Contains(k_Title));

            int titleCount = texts.Count(t => !t.name.Contains(k_Subtitle) & t.name.Contains(k_Title));

            Data data;
            if (hasCaption)
            {
                data = titleSubtitleAndCaption.GetRandomItem();
            }
            else if (hasSubtitle)
            {
                data = titleAndSubtitle.GetRandomItem();
            }
            else
            {
                data = titleCount == 1 ? titles.GetRandomItem() : titleAndSubtitle.GetRandomItem();
            }

            int updatedTitles = 0;
            foreach (TMP_Text t in texts)
            {
                if (t.name.Contains(k_Caption))
                {
                    data.SetCaption(t);
                    continue;
                }

                if (t.name.Contains(k_Subtitle))
                {
                    data.SetSubtitle(t);
                    continue;
                }

                if (t.name.Contains(k_Title))
                {
                    if (updatedTitles == 0)
                    {
                        data.SetTitle(t);
                        updatedTitles++;
                    }
                    else
                    {
                        data.SetSubtitle(t);
                    }
                    continue;
                }

                Debug.Log($"Check the '{target.name}' prefab for a typo in titles GameObject names");
                t.text = "Check GameObject name for typo!";
            }

            return target;
        }

        public static RectTransform ResizeTarget(RectTransform target, int padding)
        {
            Vector3 localScale = target.localScale;
            float scaleX = localScale.x;
            float scaleY = localScale.y;

            int widthPadding = padding * 2;
            int heightPadding = padding * 2;

            Vector2 parentSizeDelta = target.parent.GetComponent<RectTransform>().sizeDelta;
            Vector2 targetSizeDelta = target.sizeDelta;

            int targetWidth = (int)parentSizeDelta.x - widthPadding;
            int targetHeight = (int)parentSizeDelta.y - heightPadding;

            bool itemIsSmallerThanParent =
                targetSizeDelta.x <= parentSizeDelta.x &
                targetSizeDelta.y <= parentSizeDelta.y;

            if (itemIsSmallerThanParent)
                return target;

            scaleX = targetWidth * scaleX / targetSizeDelta.x;
            scaleY = targetHeight * scaleY / targetSizeDelta.y;

            float newScale = Mathf.Min(scaleX, scaleY);
            target.localScale = new Vector3(newScale, newScale, 1f);

            return target;
        }

        public static RectTransform ResizeTarget(RectTransform target, int padding, Vector2 toSize)
        {
            Vector3 localScale = target.localScale;
            float scaleX = localScale.x;
            float scaleY = localScale.y;

            int widthPadding = padding * 2;
            int heightPadding = padding * 2;

            Vector2 targetSizeDelta = target.sizeDelta;

            int targetWidth = (int)toSize.x - widthPadding;
            int targetHeight = (int)toSize.y - heightPadding;

            bool itemIsSmallerThanTargetSize =
                targetSizeDelta.x <= toSize.x &
                targetSizeDelta.y <= toSize.y;

            if (itemIsSmallerThanTargetSize)
                return target;

            scaleX = targetWidth * scaleX / targetSizeDelta.x;
            scaleY = targetHeight * scaleY / targetSizeDelta.y;

            float newScale = Mathf.Min(scaleX, scaleY);
            target.localScale = new Vector3(newScale, newScale, 1f);

            return target;
        }

        public static List<Data> titles => AllTitles.Where(d => d.hasTitle & !d.hasSubtitle & !d.hasCaption).ToList();
        public static List<Data> titleAndSubtitle => AllTitles.Where(d => d.hasTitle & d.hasSubtitle & !d.hasCaption).ToList();
        public static List<Data> titleSubtitleAndCaption => AllTitles.Where(d => d.hasTitle & d.hasSubtitle & d.hasCaption).ToList();

        private static readonly List<Data> AllTitles = new List<Data>
        {
            //Titles
            new Data("Amazing Design"),
            new Data("Amazing Lower Thirds"),
            new Data("Amazing Titles Pack"),
            new Data("Animated Lower Thirds"),
            new Data("Animated Titles"),
            new Data("Animated Typography"),
            new Data("Awesome Design"),
            new Data("Awesome Lower Thirds"),
            new Data("Awesome Titles Pack"),
            new Data("Change Animations"),
            new Data("Change Colors"),
            new Data("Change Font Size"),
            new Data("Change Fonts"),
            new Data("Clean Design"),
            new Data("Clean Titles Pack"),
            new Data("Cool Lower Thirds"),
            new Data("Cool Titles Pack"),
            new Data("Cool Typography Pack"),
            new Data("Creative Design"),
            new Data("Creative Lower Thirds"),
            new Data("Creative Titles Pack"),
            new Data("Customizable Lower Thirds"),
            new Data("Customizable Titles Pack"),
            new Data("Customize Everything"),
            new Data("Dynamic Lower Thirds"),
            new Data("Dynamic Titles Pack"),
            new Data("Easy to Use"),
            new Data("Flexible Design"),
            new Data("Flexible Lower Thirds"),
            new Data("Flexible Titles Pack"),
            new Data("Lower Thirds"),
            new Data("Minimalist Design"),
            new Data("Minimalist Lower Thirds"),
            new Data("Minimalist Typography"),
            new Data("Modern Design"),
            new Data("Modern Lower Thirds"),
            new Data("Modern Titles Pack"),
            new Data("Original Design"),
            new Data("Original Lower Thirds"),
            new Data("Original Titles Pack"),
            new Data("Professional Design"),
            new Data("Professional Lower Thirds"),
            new Data("Professional Titles Pack"),
            new Data("Animations"),
            new Data("Responsive Design"),
            new Data("Responsive Titles"),
            new Data("Responsive Typography"),
            new Data("Unique Titles Pack"),
            new Data("Unique Typography Pack"),
            new Data("Use any font"),

            //Titles & Subtitles
            new Data("Amazing", "Animated Titles"),
            new Data("Amazing", "Lower Thirds"),
            new Data("Amazing", "Animations"),
            new Data("Amazing", "Titles Pack"),
            new Data("Amazing", "Typography Pack"),
            new Data("Awesome", "Animated Titles"),
            new Data("Awesome", "Lower Thirds"),
            new Data("Awesome", "Animations"),
            new Data("Awesome", "Titles Pack"),
            new Data("Awesome", "Typography Pack"),
            new Data("Clean", "Animated Titles"),
            new Data("Clean", "Lower Thirds"),
            new Data("Clean", "Animations"),
            new Data("Clean", "Titles Pack"),
            new Data("Clean", "Typography Pack"),
            new Data("Cool", "Animated Titles"),
            new Data("Cool", "Lower Thirds"),
            new Data("Cool", "Animations"),
            new Data("Cool", "Titles Pack"),
            new Data("Cool", "Typography Pack"),
            new Data("Creative", "Animated Titles"),
            new Data("Creative", "Lower Thirds"),
            new Data("Creative", "Animations"),
            new Data("Creative", "Titles Pack"),
            new Data("Creative", "Typography Pack"),
            new Data("Customizable", "Animated Titles"),
            new Data("Customizable", "Lower Thirds"),
            new Data("Customizable", "Animations"),
            new Data("Customizable", "Titles Pack"),
            new Data("Customizable", "Typography Pack"),
            new Data("Dynamic", "Animated Titles"),
            new Data("Dynamic", "Lower Thirds"),
            new Data("Dynamic", "Animations"),
            new Data("Dynamic", "Titles Pack"),
            new Data("Dynamic", "Typography Pack"),
            new Data("Easy To Use", "Animated Titles"),
            new Data("Easy To Use", "Lower Thirds"),
            new Data("Easy To Use", "Animations"),
            new Data("Easy To Use", "Titles Pack"),
            new Data("Easy To Use", "Typography Pack"),
            new Data("Flexible", "Animated Titles"),
            new Data("Flexible", "Lower Thirds"),
            new Data("Flexible", "Animations"),
            new Data("Flexible", "Titles Pack"),
            new Data("Flexible", "Typography Pack"),
            new Data("Minimalist", "Animated Titles"),
            new Data("Minimalist", "Lower Thirds"),
            new Data("Minimalist", "Animations"),
            new Data("Minimalist", "Titles Pack"),
            new Data("Minimalist", "Typography Pack"),
            new Data("Modern", "Animated Titles"),
            new Data("Modern", "Lower Thirds"),
            new Data("Modern", "Animations"),
            new Data("Modern", "Titles Pack"),
            new Data("Modern", "Typography Pack"),
            new Data("Original", "Animated Titles"),
            new Data("Original", "Lower Thirds"),
            new Data("Original", "Animations"),
            new Data("Original", "Titles Pack"),
            new Data("Original", "Typography Pack"),
            new Data("Professional", "Animated Titles"),
            new Data("Professional", "Lower Thirds"),
            new Data("Professional", "Animations"),
            new Data("Professional", "Titles Pack"),
            new Data("Professional", "Typography Pack"),
            new Data("Ready To Use", "Animated Titles"),
            new Data("Ready To Use", "Lower Thirds"),
            new Data("Ready To Use", "Animations"),
            new Data("Ready To Use", "Titles Pack"),
            new Data("Ready To Use", "Typography Pack"),
            new Data("Responsive", "Animated Titles"),
            new Data("Responsive", "Lower Thirds"),
            new Data("Responsive", "Titles Pack"),
            new Data("Responsive", "Typography Pack"),
            new Data("Smooth", "Animated Titles"),
            new Data("Smooth", "Lower Thirds"),
            new Data("Smooth", "Animations"),
            new Data("Smooth", "Titles Pack"),
            new Data("Smooth", "Typography Pack"),
            new Data("Trendy", "Animated Titles"),
            new Data("Trendy", "Lower Thirds"),
            new Data("Trendy", "Animations"),
            new Data("Trendy", "Titles Pack"),
            new Data("Trendy", "Typography Pack"),
            new Data("Unique", "Animated Titles"),
            new Data("Unique", "Lower Thirds"),
            new Data("Unique", "Animations"),
            new Data("Unique", "Titles Pack"),
            new Data("Unique", "Typography Pack"),

            //Titles & Subtitles & Captions
            new Data("Amazing", "Animated Titles", "Minimalist"),
            new Data("Amazing", "Lower Thirds", "Minimalist"),
            new Data("Amazing", "Animations", "Minimalist"),
            new Data("Amazing", "Titles Pack", "Minimalist"),
            new Data("Amazing", "Typography Pack", "Minimalist"),
            new Data("Awesome", "Animated Titles", "Minimalist"),
            new Data("Awesome", "Lower Thirds", "Minimalist"),
            new Data("Awesome", "Animations", "Minimalist"),
            new Data("Awesome", "Titles Pack", "Minimalist"),
            new Data("Awesome", "Typography Pack", "Minimalist"),
            new Data("Clean", "Animated Titles", "Minimalist"),
            new Data("Clean", "Lower Thirds", "Minimalist"),
            new Data("Clean", "Animations", "Minimalist"),
            new Data("Clean", "Titles Pack", "Minimalist"),
            new Data("Clean", "Typography Pack", "Minimalist"),
            new Data("Cool", "Animated Titles", "Minimalist"),
            new Data("Cool", "Lower Thirds", "Minimalist"),
            new Data("Cool", "Animations", "Minimalist"),
            new Data("Cool", "Titles Pack", "Minimalist"),
            new Data("Cool", "Typography Pack", "Minimalist"),
            new Data("Creative", "Animated Titles", "Minimalist"),
            new Data("Creative", "Lower Thirds", "Minimalist"),
            new Data("Creative", "Animations", "Minimalist"),
            new Data("Creative", "Titles Pack", "Minimalist"),
            new Data("Creative", "Typography Pack", "Minimalist"),
            new Data("Customizable", "Animated Titles", "Minimalist"),
            new Data("Customizable", "Lower Thirds", "Minimalist"),
            new Data("Customizable", "Animations", "Minimalist"),
            new Data("Customizable", "Titles Pack", "Minimalist"),
            new Data("Customizable", "Typography Pack", "Minimalist"),
            new Data("Dynamic", "Animated Titles", "Minimalist"),
            new Data("Dynamic", "Lower Thirds", "Minimalist"),
            new Data("Dynamic", "Animations", "Minimalist"),
            new Data("Dynamic", "Titles Pack", "Minimalist"),
            new Data("Dynamic", "Typography Pack", "Minimalist"),
            new Data("Easy To Use", "Animated Titles", "Minimalist"),
            new Data("Easy To Use", "Lower Thirds", "Minimalist"),
            new Data("Easy To Use", "Animations", "Minimalist"),
            new Data("Easy To Use", "Titles Pack", "Minimalist"),
            new Data("Easy To Use", "Typography Pack", "Minimalist"),
            new Data("Flexible", "Animated Titles", "Minimalist"),
            new Data("Flexible", "Lower Thirds", "Minimalist"),
            new Data("Flexible", "Animations", "Minimalist"),
            new Data("Flexible", "Titles Pack", "Minimalist"),
            new Data("Flexible", "Typography Pack", "Minimalist"),
            new Data("Minimalist", "Animated Titles", "Minimalist"),
            new Data("Minimalist", "Lower Thirds", "Minimalist"),
            new Data("Minimalist", "Animations", "Minimalist"),
            new Data("Minimalist", "Titles Pack", "Minimalist"),
            new Data("Minimalist", "Typography Pack", "Minimalist"),
            new Data("Modern", "Animated Titles", "Minimalist"),
            new Data("Modern", "Lower Thirds", "Minimalist"),
            new Data("Modern", "Animations", "Minimalist"),
            new Data("Modern", "Titles Pack", "Minimalist"),
            new Data("Modern", "Typography Pack", "Minimalist"),
            new Data("Original", "Animated Titles", "Minimalist"),
            new Data("Original", "Lower Thirds", "Minimalist"),
            new Data("Original", "Animations", "Minimalist"),
            new Data("Original", "Titles Pack", "Minimalist"),
            new Data("Original", "Typography Pack", "Minimalist"),
            new Data("Professional", "Animated Titles", "Minimalist"),
            new Data("Professional", "Lower Thirds", "Minimalist"),
            new Data("Professional", "Animations", "Minimalist"),
            new Data("Professional", "Titles Pack", "Minimalist"),
            new Data("Professional", "Typography Pack", "Minimalist"),
            new Data("Ready To Use", "Animated Titles", "Minimalist"),
            new Data("Ready To Use", "Lower Thirds", "Minimalist"),
            new Data("Ready To Use", "Animations", "Minimalist"),
            new Data("Ready To Use", "Titles Pack", "Minimalist"),
            new Data("Ready To Use", "Typography Pack", "Minimalist"),
            new Data("Responsive", "Animated Titles", "Minimalist"),
            new Data("Responsive", "Lower Thirds", "Minimalist"),
            new Data("Responsive", "Titles Pack", "Minimalist"),
            new Data("Responsive", "Typography Pack", "Minimalist"),
            new Data("Smooth", "Animated Titles", "Minimalist"),
            new Data("Smooth", "Lower Thirds", "Minimalist"),
            new Data("Smooth", "Animations", "Minimalist"),
            new Data("Smooth", "Titles Pack", "Minimalist"),
            new Data("Smooth", "Typography Pack", "Minimalist"),
            new Data("Trendy", "Animated Titles", "Minimalist"),
            new Data("Trendy", "Lower Thirds", "Minimalist"),
            new Data("Trendy", "Animations", "Minimalist"),
            new Data("Trendy", "Titles Pack", "Minimalist"),
            new Data("Trendy", "Typography Pack", "Minimalist"),
            new Data("Unique", "Animated Titles", "Minimalist"),
            new Data("Unique", "Lower Thirds", "Minimalist"),
            new Data("Unique", "Animations", "Minimalist"),
            new Data("Unique", "Titles Pack", "Minimalist"),
            new Data("Unique", "Typography Pack", "Minimalist"),
        };


        public readonly struct Data
        {
            public string title { get; }
            public string subtitle { get; }
            public string caption { get; }

            public bool hasTitle => !title.IsNullOrEmpty();
            public bool hasSubtitle => !subtitle.IsNullOrEmpty();
            public bool hasCaption => !caption.IsNullOrEmpty();

            public Data(string title) : this(title, string.Empty, string.Empty)
            {
            }

            public Data(string title, string subtitle) : this(title, subtitle, string.Empty)
            {
            }

            public Data(string title, string subtitle, string caption)
            {
                this.title = title;
                this.subtitle = subtitle;
                this.caption = caption;
            }

            public Data SetTitle(TMP_Text target)
            {
                target.text = title;
                return this;
            }

            public Data SetSubtitle(TMP_Text target)
            {
                target.text = subtitle;
                return this;
            }

            public Data SetCaption(TMP_Text target)
            {
                target.text = caption;
                return this;
            }
        }
    }

}
