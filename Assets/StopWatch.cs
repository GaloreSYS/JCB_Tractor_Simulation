using System;
using UnityEngine;

public class StopWatch
{
    private float startTime;
    private bool running;

    public void Start()
    {
        startTime = Time.time;
        running = true;
    }

    public void Stop()
    {
        running = false;
    }

    public float ElapsedSeconds
    {
        get { return running ? Time.time - startTime : 0; }
    }

    public string ElapsedTimeFormatted
    {
        get
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(ElapsedSeconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds);
        }
    }
}

