using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBSecondarmUPandDown : MonoBehaviour
{
    public Animator AnimUD;


    public float ValueUD;

    public bool enableR, enableL;
    public ArmDataJCB armDataJCb;
    public void Start()
    {
        ValueUD = 0;

    }


    public void Update()
    {
        //for front bucket arms

       

        if (enableR == true)
        {
            if (ValueUD >= -1)
            {
                ValueUD -= Time.deltaTime;
                enableL = false;
            }
        }


        if (enableL == true)
        {
            if (ValueUD <= 1)
            {
                ValueUD += Time.deltaTime;
                enableR = false;
            }
        }


        AnimUD.SetFloat("RL", ValueUD);
    }
}
