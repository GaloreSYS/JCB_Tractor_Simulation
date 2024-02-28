using System;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.SceneManagement;


public class ConvyerBelt2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] bool startConv, a;
    [SerializeField] Rigidbody[] HeyRiggidBody;
    [SerializeField] ParentConstraint[] HeyConstraint;
    [SerializeField] Animator anime;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
             GameManager.Instance.moduleName = "Loader(Tractor)";
          
            GameManager.Instance.StartStopWatch();
        }
        startConv = false;
        for (int i = 0; i < HeyRiggidBody.Length; i++)
        {
            HeyRiggidBody[i].isKinematic = true;
        }

        for (int i = 0; i < HeyConstraint.Length; i++)
        {
            HeyConstraint[i].constraintActive = true;
        }
    }

    public void ConveyerMethod()
    {
        Vector3 position = rb.position;
        rb.position += Vector3.back * Speed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }

    private void Update()
    {
        dumper();
        if (startConv == true)
        {
            ConveyerMethod();
            for (int i = 0; i < HeyRiggidBody.Length; i++)
            {
                HeyRiggidBody[i].isKinematic = false;
            }

            for (int i = 0; i < HeyConstraint.Length; i++)
            {
                HeyConstraint[i].constraintActive = false;
            }
        }
    }


    public void dumper()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Dump();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            DumpReset();
        }
    }

    public void Dump()
    {
        anime.SetBool("UpLoader", true);
        Invoke("Tractor", 1.5f);
        if (inDropArea)
        {
            GameOver(ModuleStatus.Completed);
        }
        else
        {
            GameOver(ModuleStatus.Failed);
        }
    }
    public FadeEffect fadeEffect;
    public bool gameover;
    public AudioClip gameOverAudio;
    public AudioClip gameOverFailedAudio;
    public AudioSource gameOverSource;
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
    public void DumpReset()
    {
        anime.SetBool("UpLoader", false);
        startConv = false;
    }

    public void Tractor()
    {
        startConv = true;
    }

    public bool inDropArea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DropArea"))
        {
            inDropArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("DropArea"))
        {
            inDropArea = false;
        }
    }
}