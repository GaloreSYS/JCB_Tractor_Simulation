using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnRocksAndPile : MonoBehaviour
{
    public ArmDataJCB Armdata;

    public GameObject PrefabPileInBucket;
    public float BucketPassedValue;
    public Vector3 Position, Rotation;
    public void Update()
    {
        BucketPassedValue = Armdata.ValueRLJCBB;
    }
}
