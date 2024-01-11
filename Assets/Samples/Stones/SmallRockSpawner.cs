using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SmallRockSpawner : MonoBehaviour
{
    public float Height;
    public bool IsGrounded;
    public Ray ray;
    public MeshRenderer renda;
    public float Timer = 0f;
    
    private void Start()
    {
        Height = renda.bounds.size.y;
    }

    void Update()
    {
        
        if (Physics.Raycast(transform.position, Vector3.down, Height))
        {
            IsGrounded = true;
            Debug.Log("Grounded");
        }
        else
        {
            IsGrounded = false;
            Debug.Log("Not Grounded!");
        }


        if(IsGrounded == true)
        {
            if(Timer < 5f)
            {
                FF_Digger.Instance.AddTerrain(gameObject.transform,0.25f);
                Timer += Time.deltaTime;
            }
            else
            {
                Timer = 0f;
                FF_Digger.Instance.count--;
                Destroy(this.gameObject);
            }
            
        }
    }
}

 

