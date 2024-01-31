// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Doozy.Runtime.Common.Extensions;
using Doozy.Runtime.UIManager;
using Doozy.Runtime.UIManager.Containers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

#if INPUT_SYSTEM_PACKAGE
using UnityEngine.InputSystem;
// ReSharper disable CheckNamespace
#endif

namespace Doozy.Sandbox.AnimatedTitles
{
    public class AnimatedTitlesController : MonoBehaviour
    {
        public const string k_Title = "Title";
        public const string k_Subtitle = "Subtitle";
        public const string k_Caption = "Caption";

        private const int TITLE_FONT_SIZE = 80;
        private const int SUBTITLE_FONT_SIZE = 60;
        private const int CAPTION_FONT_SIZE = 40;

        public List<GameObject> Prefabs;
        public bool UseRandomTitles = true;

        /// <summary> Invoked when unloading the last prefab in the Prefabs list </summary>
        public UnityEvent OnFinished = new UnityEvent();

        public TextSettings TitleSettings = new TextSettings(k_Title, k_Title, TITLE_FONT_SIZE);
        public TextSettings SubtitleSettings = new TextSettings(k_Subtitle, k_Subtitle, SUBTITLE_FONT_SIZE);
        public TextSettings CaptionSettings = new TextSettings(k_Caption, k_Caption, CAPTION_FONT_SIZE);

        public TMP_Text InfoLabel;

        private Coroutine playAllCoroutine { get; set; }

        private UIContainer currentTarget { get; set; }
        private GameObject loadedPrefab { get; set; }

        #if INPUT_SYSTEM_PACKAGE
        private InputAction m_Space;
        private InputAction m_LeftArrow;
        private InputAction m_RightArrow;
        private InputAction m_UpArrow;
        private InputAction m_DownArrow;
        #endif

        private static bool canRun => Application.isPlaying;

        private void Reset()
        {
            CreateInfoLabel();
        }

        private void Awake()
        {
            if (!canRun) return;

            #if INPUT_SYSTEM_PACKAGE
            m_Space = new InputAction("Space", InputActionType.Button, "<Keyboard>/space");
            m_LeftArrow = new InputAction("LeftArrow", InputActionType.Button, "<Keyboard>/leftArrow");
            m_RightArrow = new InputAction("RightArrow", InputActionType.Button, "<Keyboard>/rightArrow");
            m_UpArrow = new InputAction("UpArrow", InputActionType.Button, "<Keyboard>/upArrow");
            m_DownArrow = new InputAction("DownArrow", InputActionType.Button, "<Keyboard>/downArrow");

            m_Space.performed += ctx => ReloadPrefab(true);     //Space -> Reload prefab
            m_LeftArrow.performed += ctx => LoadPrevious(true); //Left Arrow -> Load previous prefab
            m_RightArrow.performed += ctx => LoadNext(true);    //Right Arrow -> Load next prefab
            m_UpArrow.performed += ctx => PlayOrStop();         //Up Arrow -> Play/Stop
            m_DownArrow.performed += ctx => ShowHide();         //Down Arrow -> Show/Hide
            #endif
        }

        private void OnEnable()
        {
            if (!canRun) return;

            #if INPUT_SYSTEM_PACKAGE
            m_Space.Enable();
            m_LeftArrow.Enable();
            m_RightArrow.Enable();
            m_UpArrow.Enable();
            m_DownArrow.Enable();
            #endif

            if (loadedPrefab != null) return;
            // if (InfoLabel == null) return;
            // InfoLabel.text =
            //     "[Space] show/hide the loaded prefab" +
            //     "\n [Left Arrow] load previous prefab" +
            //     "\n [Right Arrow] load next prefab" +
            //     "\n [Up Arrow] reload prefab";
        }

        private void OnDisable()
        {
            if (!canRun) return;
            StopContinuousPlay();
              #if INPUT_SYSTEM_PACKAGE
            m_Space.Dispose();
            m_LeftArrow.Dispose();
            m_RightArrow.Dispose();
            m_UpArrow.Dispose();
            #endif
        }

        public void ShowHide()
        {
            if (!canRun) return;
            StopContinuousPlay();

            if (currentTarget == null)
            {
                LoadNext(false);
                currentTarget.InstantHide();
                currentTarget.Show();
                return;
            }

            switch (currentTarget.visibilityState)
            {
                case VisibilityState.Visible:
                    currentTarget.Hide();
                    break;
                case VisibilityState.Hidden:
                    currentTarget.Show();
                    break;
            }
        }

        public void ReloadPrefab(bool stopContinuousPlay)
        {
            if (!canRun) return;
            if (stopContinuousPlay) StopContinuousPlay();
            if (loadedPrefab == null)
            {
                LoadFirst(false);
                return;
            }
            LoadPrefab(Prefabs.IndexOf(loadedPrefab));
        }

        public void LoadNext(bool stopContinuousPlay)
        {
            if (!canRun) return;
            if (stopContinuousPlay) StopContinuousPlay();
            if (loadedPrefab == null)
            {
                LoadPrefab(0);
                return;
            }
            int index = Prefabs.IndexOf(loadedPrefab);
            LoadPrefab(index == Prefabs.Count - 1 ? 0 : index + 1);
        }

        public void LoadPrevious(bool stopContinuousPlay)
        {
            if (!canRun) return;
            if (stopContinuousPlay) StopContinuousPlay();
            if (loadedPrefab == null)
            {
                LoadPrefab(Prefabs.Count - 1);
                return;
            }
            int index = Prefabs.IndexOf(loadedPrefab);
            LoadPrefab(index == 0 ? Prefabs.Count - 1 : index - 1);
        }

        public void LoadFirst(bool stopContinuousPlay)
        {
            if (!canRun) return;
            if (stopContinuousPlay) StopContinuousPlay();
            LoadPrefab(0);
        }

        public void LoadLast(bool stopContinuousPlay)
        {
            if (!canRun) return;

            if (stopContinuousPlay) StopContinuousPlay();
            LoadPrefab(Prefabs.Count - 1);
        }

        public void PlayOrStop()
        {
            if (!canRun) return;
            if (playAllCoroutine == null)
            {
                PlayAll();
                return;
            }
            StopContinuousPlay();
        }

        public void PlayAll()
        {
            if (!canRun) return;
            StopContinuousPlay();
            continuousPlay = true;
            playAllCoroutine = StartCoroutine(ContinuousPlay());
        }

        public void StopContinuousPlay()
        {
            if (!canRun) return;
            if (playAllCoroutine == null) return;
            continuousPlay = false;
            StopCoroutine(playAllCoroutine);
            playAllCoroutine = null;
        }

        private bool continuousPlay { get; set; }
        private IEnumerator ContinuousPlay()
        {
            bool skipLoadNext = loadedPrefab != null;
            while (continuousPlay)
            {
                if (!skipLoadNext)
                {
                    if (loadedPrefab == Prefabs.Last())
                    {
                        OnFinished?.Invoke();
                        yield return null;
                        yield return null;
                    }

                    LoadNext(false);
                }

                skipLoadNext = false;
                currentTarget.OnStartBehaviour = ContainerBehaviour.Disabled;
                currentTarget.InstantHide();
                currentTarget.Show();
                yield return new WaitForSecondsRealtime(currentTarget.totalDurationForShow);
                yield return new WaitForSecondsRealtime(1);
                currentTarget.Hide();
                yield return new WaitForSecondsRealtime(currentTarget.totalDurationForHide);
            }

            playAllCoroutine = null;
        }

        private void LoadPrefab(int index)
        {
            if (loadedPrefab != null) loadedPrefab = null;
            if (currentTarget != null) Destroy(currentTarget.gameObject);
            loadedPrefab = Prefabs[index];
            currentTarget = InstantiatePrefab(loadedPrefab).GetComponent<UIContainer>();
            if (InfoLabel != null) InfoLabel.text = currentTarget.name.Replace("(Clone)", "");
            if (UseRandomTitles) SetRandomTitle(currentTarget.gameObject);
        }

        private GameObject InstantiatePrefab(GameObject prefab)
        {
            GameObject go = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            go.transform.SetParent(transform, false);
            go.transform.localScale = Vector3.one;
            return go;
        }

        public void CreateInfoLabel()
        {
            if (InfoLabel != null) return;
            TextMeshProUGUI label = new GameObject("Info Label", typeof(RectTransform)).AddComponent<TextMeshProUGUI>();
            label.color = Color.gray;
            label.text = "Loaded Prefab Name";
            label.fontSize = 36;
            label.alignment = TextAlignmentOptions.Center;
            label.verticalAlignment = VerticalAlignmentOptions.Middle;

            label.transform.SetParent(transform.parent, true);

            RectTransform r = label.GetComponent<RectTransform>();
            r.ResetAnchoredPosition3D();
            r.ResetLocalScaleToOne();
            r.pivot = new Vector2(0.5f, 0f);
            r.anchorMin = Vector2.zero;
            r.anchorMax = new Vector2(1f, 0f);
            r.sizeDelta = new Vector2(0, 256);

            InfoLabel = label;
        }

        private static GameObject SetRandomTitle(GameObject target) =>
            AnimatedTitleUtils.SetRandomTitle(target);
    }
}
