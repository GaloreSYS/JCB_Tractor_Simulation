using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        Instance = this;
    }

    public bool ground;

    public void Start()
    {
        PrefabPileInBucket.SetActive(false);
        Collision = false;
    }

    public void Update()
    {
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
    }

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