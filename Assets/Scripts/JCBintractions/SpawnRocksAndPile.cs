using TinyGiantStudio.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SpawnRocksAndPile : MonoBehaviour
{
    public static SpawnRocksAndPile Instance;
    public ArmDataJCB Armdata;


    public float BucketPassedValue;
    public bool Collision;
    public UnityEvent EventTriggerToSPawnRock;
    public GameObject[] g;
    public Modular3DText _modular3DText;

    public AudioClip gameOverAudio;
    public AudioSource gameOverSource;
    
    private void Awake()
    {
        Instance = this;
        GetComponent<MeshRenderer>().enabled = false;
        g = GameObject.FindGameObjectsWithTag("DigItem");
    }

    public bool ground;
    public FadeEffect fadeEffect;

    public void Start()
    {
        Collision = false;
    }

    public bool gameover;

    public void Update()
    {
        if (!gameover)
            _modular3DText.UpdateText((percentage*1.5).ToString("F0") + " % ");
        else
        {
            _modular3DText.UpdateText("Completed");
        }

        if (percentage > 60 && !gameover)
        {
           GameOver();
        }

        BucketPassedValue = Armdata.ValueRLJCBB;
    }

    public void GameOver()
    {
        gameover = true;

        fadeEffect.fadeDuration = 7;
        gameOverSource.PlayOneShot(gameOverAudio);
        fadeEffect.FadeOut();
        Invoke(nameof(GoToMainMenu),8f);
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Results");
    }
    public AudioClip hitGround;
    public int digged;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Person"))
        {
            other.gameObject.SetActive(false);
            GameManager.Instance.AwarenessFailed();
        }
        if (other.name == "Terrain")
        {
            if (!FfDigger.Instance.canDig)
            {
                ground = true;
                GetComponent<AudioSource>().PlayOneShot(hitGround);
            }
        }

        if (!other.CompareTag("DigItem")) return;

        digged++;
        var n = g.Length;
        Debug.Log(100f / n);
        percentage = (100f / n) * digged;
        Debug.Log(percentage);
        other.gameObject.SetActive(false);
    }

    [FormerlySerializedAs("p")] public float percentage;

    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);

        GameObject go = other.gameObject;

        if (go.name == "Cube")
        {
            Collision = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.name == "Terrain")
        {
            ground = false;
        }

        var go = other.gameObject;

        if (go.name == "Cube")
        {
            Collision = false;
        }
    }
}