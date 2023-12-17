using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBBucketAnim : MonoBehaviour
{
    public Animator AnimBucket;
    public float ValueBucket, OutBucket;
    public bool enableDown, enableUp;

    public ArmDataJCB JCbarmdata;
    public void Start()
    {
        ValueBucket = 0;
    }


    public void Update()
    {
        enableDown = JCbarmdata.enableBUdown; 
        enableUp = JCbarmdata.enableBUup; 

        if (enableDown == true)
        {
            if(ValueBucket >= -1)
            {
                ValueBucket -= Time.deltaTime;
                enableUp = false;
            }
        }

        if(enableUp == true)
        {
            if (ValueBucket <= 1)
            {
                ValueBucket += Time.deltaTime;
                enableDown = false;
            }
        }

        AnimBucket.SetFloat("UD", ValueBucket);
    }
}
