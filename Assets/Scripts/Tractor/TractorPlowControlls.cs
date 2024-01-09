using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorPlowControlls : MonoBehaviour
{
    public Animator AnimTractorController;
    public ArmDataJCB Tractor;
    public bool EnableDown, EnableUp;
    public float ValueTractor;

    private void Start()
    {
        ValueTractor = 0;
    }
    public void Update()
    {

        EnableDown = Tractor.TractorPlowDown;
        EnableUp = Tractor.TractorPlowUP;



        if (EnableDown == true)
        {
            if (ValueTractor >= -1)
            {
                ValueTractor -= Time.deltaTime * Tractor.TractorPlow;
                EnableUp = false;
            }
        }


        if (EnableUp == true)
        {
            if (ValueTractor <= 1)
            {
                ValueTractor += Time.deltaTime * Tractor.TractorPlow;
                EnableDown = false;
            }
        }

            Tractor.valueTractor = ValueTractor;
        AnimTractorController.SetFloat("TP", ValueTractor);
    }
}
