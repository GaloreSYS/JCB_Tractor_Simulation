using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBSecondarmUPandDown : MonoBehaviour
{
    public Animator AnimUD;


    public float ValueUD;

    public bool enableR, enableL, CheckEngine;
    public ArmDataJCB armDataJCb;
    public void Start()
    {
        ValueUD = 0;
    }


    public void FixedUpdate()
    {
        CheckEngine = armDataJCb.CheckEngine;
        //for front bucket arms
        if (!JCBStandsLeftAndRight.Instance.LeftSupportOn || !JCBStandsLeftAndRight.Instance.RightSupportOn)
        {
            Debug.Log("NOT ALLOWED");
            return;
        }

       if(CheckEngine == true)
        {
            if (enableR == true && !SpawnRocksAndPile.Instance.ground)
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
}
