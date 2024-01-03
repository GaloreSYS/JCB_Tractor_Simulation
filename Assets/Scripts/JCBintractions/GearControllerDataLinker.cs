using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using fourtyfourty.gearController;


public class GearControllerDataLinker : MonoBehaviour
{
    [Header("Put scriptable Controller here")]
    public ArmDataJCB ControllData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ControllData.enableupJCBB = true;
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            ControllData.enableupJCBB = false;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            ControllData.enabledownJCBB = true;
        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            ControllData.enabledownJCBB = false;
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            ControllData.enabledownJCB = true;
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            ControllData.enabledownJCB = false;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            ControllData.enableupJCB = true;
        }

        if (Input.GetKeyUp(KeyCode.U))
        {
            ControllData.enableupJCB = false;
        }
        
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            ControllData.enableRLdown = true;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            ControllData.enableRLdown = false;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            ControllData.enableRLup = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            ControllData.enableRLup = false;
        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            ControllData.enableRLBup = true;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            ControllData.enableRLBup = false;
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ControllData.enableRLBdown = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            ControllData.enableRLBdown = false;
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            ControllData.EnableRightLeg = true;
            ControllData.EnableLeftLeg = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            ControllData.EnableRightLeg = false;
            ControllData.EnableLeftLeg = false;
        }
    }

    public void FrontAArm(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;


        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.enableup = false;
                ControllData.enabledown = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.enableup = true;
                ControllData.enabledown = false;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.enabledown = true;
                ControllData.enableup = false;
                break;
        }
    }

    public void FrontBucket(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;
        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.enableBUup = false;
                ControllData.enableBUdown = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.enableBUdown = false;
                ControllData.enableBUup = true;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.enableBUdown = true;
                ControllData.enableBUup = false;
                break;
        }
    }


    public void BackArmUpAndDown(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;

        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.enableRLBdown = false;
                ControllData.enableRLBup = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.enableRLBdown = false;
                ControllData.enableRLBup = true;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.enableRLBdown = true;
                ControllData.enableRLBup = false;
                break;
        }
    }


    public void BackArmLeftAndRight(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;

        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.enableRLdown = false;
                ControllData.enableRLup = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.enableRLdown = false;
                ControllData.enableRLup = true;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.enableRLdown = true;
                ControllData.enableRLup = false;
                break;
        }
    }

    public void BackSecondArm(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;

        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.enabledownJCB = false;
                ControllData.enableupJCB = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.enabledownJCB = false;
                ControllData.enableupJCB = true;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.enabledownJCB = true;
                ControllData.enableupJCB = false;
                break;
        }
    }

    public void BackBucket(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;

        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.enabledownJCBB = false;
                ControllData.enableupJCBB = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.enabledownJCBB = false;
                ControllData.enableupJCBB = true;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.enabledownJCBB = true;
                ControllData.enableupJCBB = false;
                break;
        }
    }

    public void JCB_Left_leg(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;

        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.EnableLeftLeg = false;
                ControllData.DisableLeftLeg = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.EnableLeftLeg = true;
                ControllData.DisableLeftLeg = false;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.EnableLeftLeg = false;
                ControllData.DisableLeftLeg = true;
                break;
        }
    }

    public void JCB_Right_leg(int value)
    {
        var state = (GearControllerStateExtension.GearState)value;

        switch (state)
        {
            case GearControllerStateExtension.GearState.Neutral:

                ControllData.EnableRightLeg = false;
                ControllData.DisableLeftLeg = false;
                break;

            case GearControllerStateExtension.GearState.OnEnable:
                ControllData.EnableRightLeg = true;
                ControllData.DisableLeftLeg = false;
                break;

            case GearControllerStateExtension.GearState.OnDisable:
                ControllData.EnableRightLeg = false;
                ControllData.DisableLeftLeg = true;
                break;
        }
    }


    public void GEAR(int value)
    {
        ControllData.gearValue = value;
    }
}