using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBbackBucket : MonoBehaviour
{
    public Animator AnimRL;


    public float ValueRL;

    public bool enableDown, enableUp;
    public ArmDataJCB ArmDataJCb;
    public void Awake()
    {
        ValueRL = -1f;
    }


    public void Update()
    {
        
        //for front bucket arms
        enableDown = ArmDataJCb.enabledownJCBB;
        enableUp = ArmDataJCb.enableupJCBB;

        if (enableDown == true && !SpawnRocksAndPile.Instance.ground)
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

        ArmDataJCb.ValueRLJCBB = ValueRL;
        AnimRL.SetFloat("BBuck", ValueRL);
    }
    
    
}
