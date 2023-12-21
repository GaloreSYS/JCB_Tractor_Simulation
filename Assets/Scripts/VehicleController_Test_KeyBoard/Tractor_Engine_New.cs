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
        rb=GetComponent<Rigidbody>();
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
        if(GasInput==0)
        {
            FL.brakeTorque = 2500;
            FR.brakeTorque = 2500;
            RL.brakeTorque = 2500;
            RR.brakeTorque = 2500;
        }
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
        }
        
    }
    public void ApplyBrake()
    {
        if(Input.GetKey(KeyCode.Space)) 
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
