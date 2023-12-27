using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Tractor_Engine_New : MonoBehaviour
{
    public float MotorTorque;
    public float BrakeTorque;
    public float MaxSteerAngle;
    public float MaxSpeed;
    public float CurrentSpeed;

    public float GasInput, BrakeInput, SteerInput;

    public WheelCollider FL, FR, RL, RR;
    public Transform FLT, FRT, RLT, RRT;
    Rigidbody rb;

    public float MaxRPM;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GasInput = Input.GetAxis("Vertical");

        SteerInput = Input.GetAxis("Horizontal");

    }
    private void FixedUpdate()
    {
        CurrentSpeed = rb.velocity.magnitude * 3.6f;

        ApplySteering();
        ApplyTorque();
        ApplyBrake();

        UpdateWheelPose(FL, FLT);
        UpdateWheelPose(FR, FRT);
        UpdateWheelPose(RL, RLT);
        UpdateWheelPose(RR, RRT);
    }
    public void ApplyTorque()
    {
        if (GasInput > 0 && CurrentSpeed <= MaxSpeed)
        {
            FL.motorTorque = GasInput * MotorTorque;
            FR.motorTorque = GasInput * MotorTorque;
            RR.motorTorque = GasInput * MotorTorque;
            RL.motorTorque = GasInput * MotorTorque;
        }
        else if (GasInput == 0 && GasInput! > 0 && CurrentSpeed <= MaxSpeed)
        {
            FL.brakeTorque = BrakeTorque / 8;
            FR.brakeTorque = BrakeTorque / 8;
            RL.brakeTorque = BrakeTorque / 8;
            RR.brakeTorque = BrakeTorque / 8;
        }
    }
    public void AcceleratePedal()
    {
        if (CurrentSpeed <= MaxSpeed)
        {
            FL.motorTorque = MotorTorque;
            FR.motorTorque = MotorTorque;
            RR.motorTorque = MotorTorque;
            RL.motorTorque = MotorTorque;
        }
    }
    public void StopVehicle()
    {

        FL.brakeTorque = BrakeTorque / 2;
        FR.brakeTorque = BrakeTorque / 2;
        RL.brakeTorque = BrakeTorque / 2;
        RR.brakeTorque = BrakeTorque / 2;


    }
    public void BrakePedal()
    {
        FL.brakeTorque = BrakeTorque;
        FR.brakeTorque = BrakeTorque;
        RL.brakeTorque = BrakeTorque;
        RR.brakeTorque = BrakeTorque;
    }
    public void ZeroBrake()
    {
        FL.brakeTorque = 0;
        FR.brakeTorque = 0;
        RL.brakeTorque = 0;
        RR.brakeTorque = 0;
    }
    public void ApplyBrake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FL.brakeTorque = BrakeTorque;
            FR.brakeTorque = BrakeTorque;
            RL.brakeTorque = BrakeTorque;
            RR.brakeTorque = BrakeTorque;
        }
    }
    public void ApplySteering()
    {
        FL.steerAngle = SteerInput * MaxSteerAngle;
        FR.steerAngle = SteerInput * MaxSteerAngle;
    }
    public void UpdateWheelPose(WheelCollider wc, Transform WT)
    {
        Quaternion q;
        Vector3 Pos;
        wc.GetWorldPose(out Pos, out q);
        WT.transform.position = Pos;
        WT.transform.rotation = q;

    }



}