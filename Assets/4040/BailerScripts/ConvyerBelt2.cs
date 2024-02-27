using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ConvyerBelt2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] bool startConv;
    [SerializeField] Rigidbody[] HeyRiggidBody;
    [SerializeField] PositionConstraint[] HeyConstraint;
    private void Start()
    {
        startConv = false;
        for(int i= 0; i <HeyRiggidBody.Length; i++)
        {
            HeyRiggidBody[i].isKinematic = true;
        }

        for (int i = 0; i < HeyConstraint.Length; i++)
        {
            HeyConstraint[i].constraintActive = true;
        }
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
            for (int i = 0; i < HeyRiggidBody.Length; i++)
            {
                HeyRiggidBody[i].isKinematic = false;
            }

            for (int i = 0; i < HeyConstraint.Length; i++)
            {
                HeyConstraint[i].constraintActive = false;
            }
        }
    }
}