using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class SplashVideoController : MonoBehaviour
{
    private void Start()
    {
        var vp = GetComponent<VideoPlayer>();
        vp.loopPointReached += OnVideoEndReached;
    }

    private void OnVideoEndReached(VideoPlayer vp)
    {
        gameObject.SetActive(false);
    }
}
