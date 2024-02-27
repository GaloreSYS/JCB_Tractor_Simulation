using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class ConvyerBelt2 : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] bool startConv,a;
    [SerializeField] Rigidbody[] HeyRiggidBody;
    [SerializeField] ParentConstraint[] HeyConstraint;
    [SerializeField] Animator anime;
    
    private void Start()
    {
        startConv = false;
        for (int i = 0; i < HeyRiggidBody.Length; i++)
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
        dumper();
        if (startConv == true)
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


    public void dumper()
    {


        if(Input.GetKeyDown(KeyCode.H)) {

            anime.SetBool("UpLoader",true);
            Invoke("tractor", 1.5f);
        
        }

        if (Input.GetKeyDown(KeyCode.J))
        {

            anime.SetBool("UpLoader", false);
         

        }



    }
    
    public void tractor()
    {

        startConv = true;
    }
}