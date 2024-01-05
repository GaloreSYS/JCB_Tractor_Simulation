using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class SpawnRocksAndPile : MonoBehaviour
{
    public ArmDataJCB Armdata;

    public GameObject PrefabPileInBucket;
    public float BucketPassedValue;
    public bool Collision;
    public UnityEvent EventTriggerToSPawnRock;
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
                FF_Digger.Instance.Spawnstones();
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
                if(PrefabPileInBucket.activeSelf)
                {
                    FF_Digger.Instance.Spawnstones();
                }
                PrefabPileInBucket.SetActive(false);
                EventTriggerToSPawnRock.Invoke();
            }
        }

    }

    public void OnTriggerStay(Collider other)
    {
        GameObject go = other.gameObject;

        if (go.name == "Cube")
        {
            Collision = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject go = other.gameObject;

        if (go.name == "Cube")
        {
            Collision = false;
        }
    }
}
