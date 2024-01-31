using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptablepasser : MonoBehaviour
{
    public int s,b;
    public ArmDataJCB gearspeed;
   public void speedselect(int value)
    {
        s = value;
    }
    public void frontback(int value)
    {
        b= value;
    }
    public void FixedUpdate()
    {
        //gearspeed.gearValue = s;
        //gearspeed.frontandbackdecider = b;
    }
}
