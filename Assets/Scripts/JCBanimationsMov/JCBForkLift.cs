using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBForkLift : MonoBehaviour
{
    public ArmDataJCB ArmDatajvb;
    public Animator anim;
    public float ValueForks;
    public bool ForkUp, ForkDown, CheckEngine;
    // Start is called before the first frame update
    void Start()
    {
        anim.SetFloat("ForkLift", 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckEngine = ArmDatajvb.CheckEngine;

        if(CheckEngine == true)
        {
            ArmDatajvb.valueFork = ValueForks;
            ForkUp = ArmDatajvb.ForkLiftUp;
            ForkDown = ArmDatajvb.ForkLiftDown;
            //for front bucket arms
            if (ForkUp == true)
            {
                if (ValueForks >= -1)
                {
                    ValueForks -= Time.deltaTime;
                    ForkDown = false;
                }
            }


            if (ForkDown == true)
            {
                if (ValueForks <= 1)
                {
                    ValueForks += Time.deltaTime;
                    ForkUp = false;
                }
            }


            anim.SetFloat("ForkLift", ValueForks);
        }
    }
}
