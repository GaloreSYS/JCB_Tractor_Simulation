using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBackArmUpAndDown : MonoBehaviour
{
    public Animator AnimRL;


    public float ValueRL;

    public bool enableDown, enableUp;
    public ArmDataJCB Bucketarm;

    public void Start()
    {
        ValueRL = -1;
    }


    public void Update()
    {
        enableDown = Bucketarm.enableRLBdown;
        enableUp = Bucketarm.enableRLBup;

        //for front bucket arms
        if (enableDown == true)
        {
            if (ValueRL >= -1)
            {
                ValueRL -= Time.deltaTime;
                enableUp = false;
            }
        }


        if (enableUp == true)
        {
            if (ValueRL <= 1)
            {
                ValueRL += Time.deltaTime;
                enableDown = false;
            }
        }


        AnimRL.SetFloat("RLBack", ValueRL);
    }
}
