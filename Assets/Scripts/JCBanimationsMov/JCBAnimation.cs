using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBAnimation : MonoBehaviour
{
    public Animator AnimArms;


    public float ValueArms;

    public bool enableDown, enableUp;

    public ArmDataJCB JCBArmData;

    public void Start()
    {
        ValueArms = 0;
    }


    public void Update()
    {

        JCBArmData.valuearms = ValueArms;
        enableDown = JCBArmData.enabledown;
        enableUp = JCBArmData.enableup;
        //for front bucket arms
        if(enableDown == true)
        {
            if (ValueArms >= -1)
            {
                ValueArms -= Time.deltaTime;
                enableUp = false;
            }
        }


        if (enableUp == true)
        {
            if (ValueArms <= 1)
            {
                ValueArms += Time.deltaTime;
                enableDown = false;
            }
        }


        AnimArms.SetFloat("ForUp", ValueArms);

    }
}
