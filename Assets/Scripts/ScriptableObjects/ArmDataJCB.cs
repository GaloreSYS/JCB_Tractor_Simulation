using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JCBARMSVALUE", menuName = "Vehicle/JCBArmData")]
public class ArmDataJCB : ScriptableObject
{
    [Header("Master - Checks Engien is on or not..")]
    public bool CheckEngine;

    [Header("JCBanimation")]
    public float valuearms;
    public bool enabledown, enableup;

    [Header("JCBBucketAnimation")]
    public float valuebucket;
    public bool enableBUdown, enableBUup;

    [Header("JCBackArmUpAndDown")]
    public float valueRLback;
    public bool enableRLBdown, enableRLBup;

    [Header("JCBRightAndLeft")]
    public float ValuerightandleftRL;
    public bool enableRLdown, enableRLup;

    [Header("JCsecArmUD")]
    public float ValueRLJCUD;
    public bool enabledownJCB, enableupJCB;

    [Header("JCBbackBucket")]
    public float ValueRLJCBB;
    public bool enableupJCBB,enabledownJCBB;

    [Header("JCB_Left_Leg")]
    public float ValueRLJCBRLB;
    public bool EnableLeftLeg, DisableLeftLeg;

    [Header("JCB_Right_Leg")]
    public float valueRL;
    public bool EnableRightLeg, DisableRightLeg;

    public int gearValue;


    [Header("JCB_ForkLift")]
    public float valueFork;
    public bool ForkLiftUp, ForkLiftDown;

    [Header("This Variable for Tractor Sim.")]
    [Header("Tractor PlowHandel")]
    public float valueTractor;
    public bool TractorPlowUP,TractorPlowDown;
}
