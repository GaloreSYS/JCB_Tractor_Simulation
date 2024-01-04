using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRocksAndPile : MonoBehaviour
{
    public ArmDataJCB Armdata;

    public GameObject PrefabPileInBucket;
    public float BucketPassedValue;
    public bool Collision;

    public void Start()
    {
        PrefabPileInBucket.SetActive(false);
        Collision = false;
    }
    public void Update()
    {
        BucketPassedValue = Armdata.ValueRLJCBB;
        if(Collision == true)
        {
            if (BucketPassedValue < -0.5)
            {
                PrefabPileInBucket.SetActive(true);
            }
            else
            {
                PrefabPileInBucket.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Not Colliding with rock");
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
