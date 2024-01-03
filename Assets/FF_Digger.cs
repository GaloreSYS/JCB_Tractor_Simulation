using System;
using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;


public class FF_Digger : MonoBehaviour
{
    [Header("Async parameters")]
    [Tooltip("Enable to edit the terrain asynchronously and avoid impacting the frame rate too much.")]
    public bool editAsynchronously = true;

    [Header("Modification parameters")] public BrushType brush = BrushType.Sphere;
    public ActionType action = ActionType.Dig;
    [Range(0, 7)] public int textureIndex;
    [Range(0.5f, 10f)] public float size = 4f;
    [Range(0f, 1f)] public float opacity = 0.5f;

    private DiggerMasterRuntime diggerMasterRuntime;

    public bool canDig;
    public ParticleSystem dust;

    [FormerlySerializedAs("cubde")] public Transform diggerObject;

    public Rigidbody tlb;
    public GameObject stonePrefab;
    public Transform stonePos;
    private void Start()
    {
        diggerMasterRuntime = FindObjectOfType<DiggerMasterRuntime>();
        if (!diggerMasterRuntime)
        {
            enabled = false;
            Debug.LogWarning(
                "DiggerRuntimeUsageExample component requires DiggerMasterRuntime component to be setup in the scene. DiggerRuntimeUsageExample will be disabled.");
        }
    }

    void SpawnRock()
    {
    // var s=     Instantiate(stonePrefab, stonePos.position, stonePos.rotation);
    // float size = 5;
    // s.transform.localScale = new Vector3(size,size,size);
    }
    private void Update()
    {
        if(!canDig)
        {
          //  tlb.constraints = RigidbodyConstraints.None;
            dust.gameObject.SetActive(false); 
            return;
        }
        tlb.constraints = RigidbodyConstraints.FreezeAll;
        dust.gameObject.SetActive(true); 
                if (editAsynchronously)
                {
                    diggerMasterRuntime.ModifyAsyncBuffured(diggerObject.position, brush, action, textureIndex, opacity,
                        size);
                }
                else
                {
                    diggerMasterRuntime.Modify(diggerObject.position, brush, action, textureIndex, opacity, size);
                }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Digger")
        {
            canDig = true;
            InvokeRepeating(nameof(SpawnRock),1,0.1f);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Digger")
        {
            canDig = false;
            CancelInvoke(nameof(SpawnRock));
        }
    }
}
