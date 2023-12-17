using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JCBArmsControll : MonoBehaviour
{

    public ArmDataJCB ArmData;

    public enum TouchControll
    {
        UP,
        DOWN,
        LEFT,
        RIGHT,

        
        EnabRLBdown,
        EnableRLBup,
        EnableRLdown,
        EnableRLup,
        EnableupJCB,
        EnabledownJCB,
        EnableUpJCBB,
        EnableDownJCBB,
      
        LeftLegUP,
        LeftLegDown,
        RightLegUp,
        RightLegDown

    }

    public TouchControll _TouchCOntrolls;
    public void ArmUpId()
    {
        ArmData.enableup = true;
    }

    public void ArmDownID()
    {
        ArmData.enabledown = true;
    }
    public void Reset()
    {
        ArmData.enabledown = false;
        ArmData.enableup = false;
    }
    public void enableTheTrigger()
    {
        if (_TouchCOntrolls == TouchControll.UP)
        {
            ArmData.enableup = true;
        }

        if (_TouchCOntrolls == TouchControll.DOWN)
        {
            ArmData.enabledown = true;
        }


        if (_TouchCOntrolls == TouchControll.LEFT)
        {
            ArmData.enableBUup = true;
        }

        if (_TouchCOntrolls == TouchControll.RIGHT)
        {
            ArmData.enableBUdown = true;
        }


        //back side

        if (_TouchCOntrolls == TouchControll.EnableRLBup)
        {
            ArmData.enableRLBup = true;
        }

        if (_TouchCOntrolls == TouchControll.EnabRLBdown)
        {
            ArmData.enableRLBdown = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLup)
        {
            ArmData.enableRLup = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLdown)
        {
            ArmData.enableRLdown = true;
        }

        //Leftovers back side

        if (_TouchCOntrolls == TouchControll.EnableupJCB)
        {
            ArmData.enableupJCB = true;
        }

        if (_TouchCOntrolls == TouchControll.EnabledownJCB)
        {
            ArmData.enabledownJCB = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableUpJCBB)
        {
            ArmData.enableupJCBB = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableDownJCBB)
        {
            ArmData.enabledownJCBB = true;
        }

        //BackLegs

        if (_TouchCOntrolls == TouchControll.LeftLegUP)
        {
            ArmData.EnableLeftLeg = true;
        }

        if (_TouchCOntrolls == TouchControll.RightLegUp)
        {
            ArmData.EnableRightLeg = true;
        }

    }



    public void exitthetrigger()
    {
        if (_TouchCOntrolls == TouchControll.UP)
        {
            ArmData.enableup = false;
        }

        if (_TouchCOntrolls == TouchControll.DOWN)
        {
            ArmData.enabledown = false;
        }


        if (_TouchCOntrolls == TouchControll.LEFT)
        {
            ArmData.enableBUup = false;
        }

        if (_TouchCOntrolls == TouchControll.RIGHT)
        {
            ArmData.enableBUdown = false;
        }


        //back side

        if (_TouchCOntrolls == TouchControll.EnableRLBup)
        {
            ArmData.enableRLBup = false;
        }

        if (_TouchCOntrolls == TouchControll.EnabRLBdown)
        {
            ArmData.enableRLBdown = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLup)
        {
            ArmData.enableRLup = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLdown)
        {
            ArmData.enableRLdown = false;
        }


        //Leftovers back side

        if (_TouchCOntrolls == TouchControll.EnableupJCB)
        {
            ArmData.enableupJCB = false;
        }

        if (_TouchCOntrolls == TouchControll.EnabledownJCB)
        {
            ArmData.enabledownJCB = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableUpJCBB)
        {
            ArmData.enableupJCBB = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableDownJCBB)
        {
            ArmData.enabledownJCBB = false;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.name);

        if(_TouchCOntrolls == TouchControll.UP)
        {
            ArmData.enableup = true;
        }

        if (_TouchCOntrolls == TouchControll.DOWN)
        {
            ArmData.enabledown = true;
        }


        if (_TouchCOntrolls == TouchControll.LEFT)
        {
            ArmData.enableBUup = true;
        }

        if (_TouchCOntrolls == TouchControll.RIGHT)
        {
            ArmData.enableBUdown  = true;
        }


        //back side

        if (_TouchCOntrolls == TouchControll.EnableRLBup)
        {
            ArmData.enableRLBup = true;
        }

        if (_TouchCOntrolls == TouchControll.EnabRLBdown)
        {
            ArmData.enableRLBdown = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLup)
        {
            ArmData.enableRLup = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLdown)
        {
            ArmData.enableRLdown = true;
        }

        //Leftovers back side

        if (_TouchCOntrolls == TouchControll.EnableupJCB)
        {
            ArmData.enableupJCB = true;
        }

        if (_TouchCOntrolls == TouchControll.EnabledownJCB)
        {
            ArmData.enabledownJCB = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableUpJCBB)
        {
            ArmData.enableupJCBB = true;
        }


        if (_TouchCOntrolls == TouchControll.EnableDownJCBB)
        {
            ArmData.enabledownJCBB = true;
        }

        //BackLegs

        if (_TouchCOntrolls == TouchControll.LeftLegUP)
        {
            ArmData.EnableLeftLeg = true;
        }

        if (_TouchCOntrolls == TouchControll.LeftLegDown)
        {
            ArmData.DisableLeftLeg = true;
        }


        if (_TouchCOntrolls == TouchControll.RightLegUp)
        {
            ArmData.EnableRightLeg = true;
        }


        if (_TouchCOntrolls == TouchControll.RightLegDown)
        {
            ArmData.DisableRightLeg = true;
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (_TouchCOntrolls == TouchControll.UP)
        {
            ArmData.enableup = false;
        }

        if (_TouchCOntrolls == TouchControll.DOWN)
        {
            ArmData.enabledown = false;
        }


        if (_TouchCOntrolls == TouchControll.LEFT)
        {
            ArmData.enableBUup = false;
        }

        if (_TouchCOntrolls == TouchControll.RIGHT)
        {
            ArmData.enableBUdown = false;
        }


        //back side

        if (_TouchCOntrolls == TouchControll.EnableRLBup)
        {
            ArmData.enableRLBup = false;
        }

        if (_TouchCOntrolls == TouchControll.EnabRLBdown)
        {
            ArmData.enableRLBdown = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLup)
        {
            ArmData.enableRLup = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableRLdown)
        {
            ArmData.enableRLdown = false;
        }


        //Leftovers back side

        if (_TouchCOntrolls == TouchControll.EnableupJCB)
        {
            ArmData.enableupJCB = false;
        }

        if (_TouchCOntrolls == TouchControll.EnabledownJCB)
        {
            ArmData.enabledownJCB = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableUpJCBB)
        {
            ArmData.enableupJCBB = false;
        }


        if (_TouchCOntrolls == TouchControll.EnableDownJCBB)
        {
            ArmData.enabledownJCBB = false;
        }

        //BackLegs

        if (_TouchCOntrolls == TouchControll.LeftLegUP)
        {
            ArmData.EnableLeftLeg = false;
        }

        if (_TouchCOntrolls == TouchControll.LeftLegDown)
        {
            ArmData.DisableLeftLeg = false;
        }


        if (_TouchCOntrolls == TouchControll.RightLegUp)
        {
            ArmData.EnableRightLeg = false;
        }


        if (_TouchCOntrolls == TouchControll.RightLegDown)
        {
            ArmData.DisableRightLeg = false;
        }
    }
}
