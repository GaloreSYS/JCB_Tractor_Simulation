using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class SmallRockSpawner : MonoBehaviour
{
    
    [FormerlySerializedAs("IsGrounded")] public bool isGrounded;
    public Ray ray;
    [FormerlySerializedAs("renda")] public MeshRenderer meshRenderer;
    [FormerlySerializedAs("Timer")] public float timer;

    private void Update()
    {
        if (isGrounded != true) return;
        
        if(timer < 2f)
        {
            FfDigger.Instance.AddTerrain(gameObject.transform,0.5f);
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            FfDigger.Instance.spawnedStoneCount--;
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionStay(Collision other)
    {
        Debug.Log("I have landed on here"+other.gameObject.name+other.gameObject.tag,other.gameObject);
        if(other.gameObject.name=="Terrain")
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }
}

 

