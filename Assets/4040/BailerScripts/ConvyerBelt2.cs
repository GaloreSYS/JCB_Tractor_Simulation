using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvyerBelt2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] bool startConv;

    private void Start()
    {
        startConv = false;
    }
    public void ConveyerMethod()
    {
        Vector3 position = rb.position;
        rb.position += Vector3.back * Speed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }
    private void Update()
    {
        if(startConv == true)
        {
            ConveyerMethod();
        }
    }
}