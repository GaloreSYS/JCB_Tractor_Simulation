using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class TLB_Engine_TST : MonoBehaviour
{
    public WheelCollider FL, FR, RL, RR;
    public Transform FLT, FRT, RLT, RRT;


    public float EngineRPM;
    public float MaxEngineRPM = 2200;
    public float MinEngineRPM = 1000;
    public float EngineTorque = 467;
    public float BrakeTorque = 2000;
    public float MaxSteerAngle = 30;
    public float AppliedTorque;

    public AnimationCurve TorqueCurve;

    public int CurrentGear;

    public float[] GearRatios;
    public float[] GearSpeeds;
    public float EffectiveGearRatio;
    public float FinalDriveRatio;

    public float CurrentSpeed;
    public float MaxSpeed;
    Rigidbody rb;

    public float GasInput, BrakeInput, SteerInput;

    [SerializeField] float _acc, _torque;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CurrentGear = 0;
        CurrentSpeed = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        EffectiveGearRatio = GearRatios[CurrentGear] * FinalDriveRatio;

        GasInput = Input.GetAxis("Vertical");

        SteerInput = Input.GetAxis("Horizontal");

        CalculateRPM();
        GearUp();
        GearDown();

    }
    private void FixedUpdate()
    {

        CurrentSpeed = rb.velocity.magnitude * 3.6f;


        if (CurrentGear > 0)
        {
            ApplyTorque();
        }

        
        ApplyBrake();
        ApplySteering();

        UpdateWheels(FL, FLT);
        UpdateWheels(FR, FRT);
        UpdateWheels(RL, RLT);
        UpdateWheels(RR, RRT);
    }
    public void CalculateRPM()
    {
        //  EngineRPM = MinEngineRPM + ((FL.rpm) * GearRatios[CurrentGear] * FinalDriveRatio);
        // EngineRPM = (int)(Mathf.Abs((FL.rpm * GearRatios[CurrentGear+1]) * (GasInput) * MinEngineRPM));
        EngineRPM = FL.rpm * EffectiveGearRatio;
       // EngineRPM = Mathf.Clamp(EngineRPM, 0, MaxEngineRPM);
       
    }
    public void ApplyTorque()
    {
        #region OldCode
        //  AppliedTorque = EffectiveGearRatio * EngineTorque;

        //  //New Torque
        ////  AppliedTorque = TorqueCurve.Evaluate(EngineRPM / (float)MaxEngineRPM) * EngineTorque;
        //   _acc = (GasInput * GasInput + (EngineRPM < 1000 ? .05f : 0));
        //   _torque = _acc  * AppliedTorque;
        //  //EndNewTorque
        //  if (GasInput > 0 && CurrentSpeed <= MaxSpeed)
        //  {
        //      FL.motorTorque = GasInput * AppliedTorque;
        //      FR.motorTorque = GasInput * AppliedTorque;
        //      RR.motorTorque = GasInput * AppliedTorque;
        //      RL.motorTorque = GasInput * AppliedTorque;
        //  }
        //  else if (GasInput == 0 && GasInput! > 0 && CurrentSpeed <= MaxSpeed)
        //  {
        //      FL.brakeTorque = BrakeTorque / 8;
        //      FR.brakeTorque = BrakeTorque / 8;
        //      RL.brakeTorque = BrakeTorque / 8;
        //      RR.brakeTorque = BrakeTorque / 8;
        //  }
        #endregion
        if (GasInput>0 && CurrentSpeed < GearSpeeds[CurrentGear])
        {
            FL.motorTorque = GasInput * MaxEngineRPM * 2;
            FR.motorTorque = GasInput * MaxEngineRPM * 2;
            RR.motorTorque = GasInput * MaxEngineRPM * 2;
            RL.motorTorque = GasInput * MaxEngineRPM * 2;
        }
        else if (GasInput == 0 && GasInput! > 0 && CurrentSpeed <= GearSpeeds[CurrentGear])
        {
            FL.brakeTorque = BrakeTorque / 8;
            FR.brakeTorque = BrakeTorque / 8;
            RL.brakeTorque = BrakeTorque / 8;
            RR.brakeTorque = BrakeTorque / 8;
        }

    }
    public void ApplyBrake()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FL.brakeTorque = BrakeTorque;
            FR.brakeTorque = BrakeTorque;
            RL.brakeTorque = BrakeTorque;
            RR.brakeTorque = BrakeTorque;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            FL.brakeTorque = 0;
            FR.brakeTorque = 0;
            RL.brakeTorque = 0;
            RR.brakeTorque = 0;
        }
    }
    public void ApplySteering()
    {
        FL.steerAngle = SteerInput * MaxSteerAngle;
        FR.steerAngle = SteerInput * MaxSteerAngle;
    }
    public void UpdateWheels(WheelCollider WC,Transform WT)
    {
        Quaternion q;
        Vector3 Pos;
        WC.GetWorldPose(out Pos, out q);
        WT.transform.position = Pos;
        WT.transform.rotation = q;
    }
    public void GearUp()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            if (CurrentGear <= GearRatios.Length)
            {
                CurrentGear = CurrentGear + 1;
            }
        }
       
    }
    public void GearDown()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            if (CurrentGear <= GearRatios.Length)
            {
                CurrentGear = CurrentGear - 1;
            }
        }
        
    }
}
