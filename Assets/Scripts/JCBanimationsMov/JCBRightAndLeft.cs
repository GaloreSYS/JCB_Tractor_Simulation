using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBRig : MonoBehaviour
{
    public Animator AnimRL;

    public ArmDataJCB JCBarmdata;
    public float ValueRL;

    public bool enableDown, enableUp, CheckEngine;

    public void Start()
    {
        ValueRL = 0f;

    }


    public void FixedUpdate()
    {
        CheckEngine = JCBarmdata.CheckEngine;

        if(CheckEngine)
        {
            enableDown = JCBarmdata.enableRLdown;
            enableUp = JCBarmdata.enableRLup;

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


            AnimRL.SetFloat("RL", ValueRL);
        }
        

    }
}
