using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRockPrefabs : MonoBehaviour
{
   public GameObject RockPrefab, RockPrefab1, RockPrefab2, SpawnPlace1, SpawnPlace2, SpawnPlace3;
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
        if (go.name == "bu0420020")
        {
            Debug.Log("SpawnRock");
            if(ArmDataBB.ValueRLJCBB <= -0.43f)
            {
                Instantiate(RockPrefab, SpawnPlace1.transform.position, Quaternion.identity);
                Instantiate(RockPrefab, SpawnPlace2.transform.position, Quaternion.identity);
                Instantiate(RockPrefab, SpawnPlace3.transform.position, Quaternion.identity);
            }
        }
    }

  

}
