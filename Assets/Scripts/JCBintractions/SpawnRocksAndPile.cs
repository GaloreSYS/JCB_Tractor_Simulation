using System;
using System.Collections;
using System.Collections.Generic;
using TinyGiantStudio.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpawnRocksAndPile : MonoBehaviour
{
    public static SpawnRocksAndPile Instance;
    public ArmDataJCB Armdata;

    public GameObject PrefabPileInBucket;
    public float BucketPassedValue;
    public bool Collision;
    public UnityEvent EventTriggerToSPawnRock;
    public GameObject[] g ;
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
        PrefabPileInBucket.SetActive(false);
        Collision = false;
    }

    private bool gameover;
    public void Update()
    {
        if(!gameover)
        _modular3DText.UpdateText(p + " % ");
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
        if (Collision == true)
        {
            if (BucketPassedValue < -0.5)
            {
//                FF_Digger.Instance.Spawnstones();
                PrefabPileInBucket.SetActive(true);
            }
            else
            {
                PrefabPileInBucket.SetActive(false);
            }
        }
        else
        {
            if (BucketPassedValue > 0)
            {
                if (PrefabPileInBucket.activeSelf)
                {
//                    FF_Digger.Instance.Spawnstones();
                }

                PrefabPileInBucket.SetActive(false);
                EventTriggerToSPawnRock.Invoke();
            }
        }
    }

    public AudioClip hitGorund;
    public int Digged;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.name == "Terrain")
        {
            if (!FF_Digger.Instance.canDig)
            {
                ground = true;
                GetComponent<AudioSource>().PlayOneShot(hitGorund);
            }
        }

        if (other.CompareTag("DigItem"))
        {
            Digged++;
            int n = g.Length;
            Debug.Log(100f/n);
             p = ( 100f/n) * Digged;
            Debug.Log(p);
           
                    other.gameObject.SetActive(false);
        }
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

        GameObject go = other.gameObject;

        if (go.name == "Cube")
        {
            Collision = false;
        }
    }
}