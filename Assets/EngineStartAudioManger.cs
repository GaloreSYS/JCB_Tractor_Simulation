using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineStartAudioManger : MonoBehaviour
{
    public static EngineStartAudioManger Instance;
    public AudioClip engineStartingClip;
    public AudioClip engineIdleStateClip;

    private AudioSource audioSource;

    public bool isOn;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& !isOn)
        {
            PlayAudio1();
            isOn = true;
        }

       
        if (!audioSource.isPlaying && audioSource.clip == engineStartingClip)
        {
            PlayAudio2();
        }
    }

  public  void PlayAudio1()
    {
        audioSource.clip = engineStartingClip;
        audioSource.loop=false;
        audioSource.Play();
    }

   public void PlayAudio2()
    {
        audioSource.clip = engineIdleStateClip;
        audioSource.loop=true;
        audioSource.Play();
        
    }
   
   public void StopAudio()
   {
       isOn = false;
       audioSource.Stop();
        
   }
}
