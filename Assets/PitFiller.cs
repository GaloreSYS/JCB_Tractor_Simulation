using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TinyGiantStudio.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitFiller : MonoBehaviour
{
    public bool ground;
    public FadeEffect fadeEffect;
    public bool gameover;
    public AudioClip gameOverAudio;
    public AudioClip gameOverFailedAudio;
    public AudioSource gameOverSource;
    public Modular3DText _modular3DText;
    public float percentage;
    public int fillerCount;

    private void Start()
    {
        GameManager.Instance.moduleName = "Front Bucket(TLB)";
        GameManager.Instance.StartStopWatch();
        fillerCount = GameObject.FindGameObjectsWithTag("Filler").Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Filler"))
        {
            percentage += 100 / fillerCount;
        }
    }

    public void Update()
    {
        if (!gameover)
            _modular3DText.UpdateText((percentage).ToString("F0") + " % ");
        else
        {
            _modular3DText.UpdateText("Completed");
        }

        if (percentage > 60 && !gameover)
        {
            GameOver(ModuleStatus.Completed);
        }
    }

    [Button]
    public void ForceGameOver()
    {
        GameOver(ModuleStatus.Completed);
    }
    public void GameOver(ModuleStatus moduleStatus)
    {
        GameManager.Instance.moduleStatus = moduleStatus;
        gameover = true;
        fadeEffect.fadeDuration = 7;

        if (moduleStatus == ModuleStatus.Failed)
        {
            gameOverSource.PlayOneShot(gameOverFailedAudio);
        }
        else
        {
            gameOverSource.PlayOneShot(gameOverAudio);
        }

        GameManager.Instance.StopStopWatch();
        fadeEffect.FadeOut();
        Invoke(nameof(GoToMainMenu), 8f);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Results");
    }
}