using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCsecArmUD : MonoBehaviour
{
    public Animator AnimRL;


    public float ValueRL;

    public bool enableDown, enableUp, CheckEngine;
    public ArmDataJCB armDataJCb;

    public void Start()
    {
        ValueRL = 1.0f;

    }


    public void FixedUpdate()
    {
        CheckEngine = armDataJCb.CheckEngine;
        if(CheckEngine == true)
        {
            enableDown = armDataJCb.enabledownJCB;
            enableUp = armDataJCb.enableupJCB;

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


            AnimRL.SetFloat("SideRL", ValueRL);
        }
    }
        //for front bucket arms
        
}
