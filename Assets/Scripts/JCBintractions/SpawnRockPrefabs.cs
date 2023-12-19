using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockPrefabs : MonoBehaviour
{
   public GameObject RockPrefab, SpawnPlace;
    public Transform BucketRotation;
    public Vector3 V3;

    public ArmDataJCB ArmDataBB;
    public void Update()
    {
        V3.x = BucketRotation.rotation.x;
        V3.y = BucketRotation.rotation.y;
        V3.z = BucketRotation.rotation.z;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        Debug.Log("SpawnRock");
        if (go.name == "ColliderRock")
        {
            Debug.Log("SpawnRock");
            if(ArmDataBB.ValueRLJCBB <= -0.53f)
            {
                Instantiate(RockPrefab, SpawnPlace.transform.position, Quaternion.identity);
            }
        }
    }

  

}
