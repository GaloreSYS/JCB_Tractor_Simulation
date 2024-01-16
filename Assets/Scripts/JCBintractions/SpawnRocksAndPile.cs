using TinyGiantStudio.Text;
using UnityEngine;
using UnityEngine.Events;

public class SpawnRocksAndPile : MonoBehaviour
{
    public static SpawnRocksAndPile Instance;
    public ArmDataJCB Armdata;


    public float BucketPassedValue;
    public bool Collision;
    public UnityEvent EventTriggerToSPawnRock;
    public GameObject[] g;
    public Modular3DText _modular3DText;

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

    private bool gameover;

    public void Update()
    {
        if (!gameover)
            _modular3DText.UpdateText(p.ToString("F0") + " % ");
        else
        {
            _modular3DText.UpdateText("Successfully Completed");
        }

        if (p > 90 && !gameover)
        {
            gameover = true;

            fadeEffect.fadeDuration = 10;
            fadeEffect.FadeOut();
        }

        BucketPassedValue = Armdata.ValueRLJCBB;
        if (Collision )
        {
        }
        else
        {
        }
    }

    public AudioClip hitGround;
    public int digged;

    private void OnTriggerEnter(Collider other)
    {
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
        p = (100f / n) * digged;
        Debug.Log(p);
        other.gameObject.SetActive(false);
    }

    public float p;

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