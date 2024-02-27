using System;
using System.Collections;
using System.Collections.Generic;
using TinyGiantStudio.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JCBForkLift : MonoBehaviour
{
    public FadeEffect fadeEffect;
    public bool gameover;
    public AudioClip gameOverAudio;
    public AudioClip gameOverFailedAudio;
    public AudioSource gameOverSource;



    public GameObject pickUpItem;

    // Start is called before the first frame update
    void Start()
    {
        pickUpItem.SetActive(false);
        GameManager.Instance.moduleName = "ForkLift(TLB)";
        GameManager.Instance.StartStopWatch();
    }

    public bool pickedUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickItem"))
        {
            pickedUp = true;
            other.gameObject.SetActive(false);
            pickUpItem.SetActive(true);
        }

        if (other.gameObject.CompareTag("DropArea"))
        {
            if (pickedUp)
            {
                pickUpItem.SetActive(false);
                other.gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().material = pickUpItem.gameObject
                    .transform.GetChild(0).GetComponent<MeshRenderer>().materials[0];
                GameOver(ModuleStatus.Completed);
            }
        }
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


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PickItem"))
        {
            pickedUp = false;
        }
    }
}