using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Vehicle.Engine;
using UnityEngine.SceneManagement;
using Manus.Interaction;

public class VehicleMovements : EngineManager
{
    public float MotorForce, SteerAngle, BreakeForce;
    public float MaxSteerAngle = 30;
    public WheelCollider FR_LeftWheel, FR_RightWheel, BK_LeftWheel, BK_RightWheel, plowWheelColider;
    public Transform FrontRightWheel, FrontLeftWheel, RearRightWheel, RearLeftWheel, plowWheel;
    public Rigidbody VehicleRB;
    public Text SpeedText;
    public Text RPMText;
    private float engineMaxSpeed;
    public static VehicleMovements instance;
    private float _throttleSpeed;
    public Transform SterringXPosition;
    public Transform Plow;

    public TurnableObject ShuttleGear;
    public TurnableObject ParkingBreak;
    public TurnableObject DiffLock;
    public TurnableObject HandThrottle;
    public TurnableObject CreeperSpeed;
    public TurnableObject TransmissionMainShiftLever;
    public TurnableObject TransmissionRangeShiftLever;
    public TurnableObject PTOEngageLever;
    public TurnableObject PTOSpeedLever;
    public TurnableObject IgnitionKey;

    public Button _exit;
    public Image IgnitionIndicator;
    private Color32 off = new Color32(218, 11, 0, 255);
    private Color32 on = new Color32(26, 219, 0, 255);
    private Color32 standBy = new Color32(218, 182, 0, 255);

    private float rotValue;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        engineMaxSpeed = MaxSpeed;
        _exit.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
           
        });

        ShuttleGear.onValueChanged += ReflectShuttleLever;
        ParkingBreak.onValueChanged += ParkingBrakeTriggered;
        //DiffLock.onValueChanged += TriggeredDiffLock;
        HandThrottle.onValueChanged += HandThrottleTriggered;
        CreeperSpeed.onValueChanged += CreeperSpeedTriggered;
        TransmissionMainShiftLever.onValueChanged += ReflectGearChange;
        TransmissionRangeShiftLever.onValueChanged += ReflectRangeShift;
        PTOEngageLever.onValueChanged += ReflectPTOEngage;
        PTOSpeedLever.onValueChanged += ReflectPTOSpeed;
        IgnitionKey.onValueChanged += ReflectIgnition;
        IgnitionKey.onGrabEnd += ResetIgnitionKeyPos;
    }

    private void OnDestroy()
    {
        ShuttleGear.onValueChanged -= ReflectShuttleLever;
        ParkingBreak.onValueChanged -= ParkingBrakeTriggered;
        //DiffLock.onValueChanged -= TriggeredDiffLock;
        HandThrottle.onValueChanged -= HandThrottleTriggered;
        CreeperSpeed.onValueChanged -= CreeperSpeedTriggered;
        TransmissionMainShiftLever.onValueChanged -= ReflectGearChange;
        TransmissionRangeShiftLever.onValueChanged -= ReflectRangeShift;
        PTOEngageLever.onValueChanged -= ReflectPTOEngage;
        PTOSpeedLever.onValueChanged -= ReflectPTOSpeed;
        IgnitionKey.onValueChanged -= ReflectIgnition;
        IgnitionKey.onGrabEnd -= ResetIgnitionKeyPos;
    }

    void FixedUpdate()
    {
        UpdateEachWheelMoves();
        SpeedText.text = ((int)(VehicleRB.velocity.magnitude * 3.6)).ToString();
        RPMText.text = (Mathf.Abs((int)BK_LeftWheel.rpm) / 100).ToString();

        HorizontalWheelMove(SterringXPosition.localRotation.x);
    }

    public void Accelerate(int axis)
    {
        if(!IsPBrake&&!IsPTOEngaged&& accelerationTypes==AccelerationTypes.NormalSpeed && CurrentEngineState==EngineState.ON && currentGear != MoveDirection.Neutral)
            VerticalWheelMove(currentGear==MoveDirection.Front?1:-1);
    }

    public void StayPut()
    {
        VerticalWheelMove(0);
    }

    public void HandThrottleAccelerate(float speed)
    {
        speed /= 4;
        if (!IsPBrake && CurrentEngineState == EngineState.ON)
        {
            if(speed <= 1)
                StayPut();

            else if (currentGear == MoveDirection.Front)
                HandThrottleWheelMove(1,1000*speed);
            else if (currentGear == MoveDirection.Back)
                HandThrottleWheelMove(-1, 1000 * speed);
        }
    }

    public void ApplyBreak()
    {
        BK_LeftWheel.brakeTorque = BreakeForce;
        BK_RightWheel.brakeTorque = BreakeForce;
        if (driveMode == DrivingMode.FourWheelDrive)
        {
            FR_LeftWheel.brakeTorque = BreakeForce;
            FR_RightWheel.brakeTorque = BreakeForce;
        }
    }

    public void ReleaseBreak()
    {
        BK_LeftWheel.brakeTorque = 0;
        BK_RightWheel.brakeTorque = 0;
        FR_LeftWheel.brakeTorque = 0;
        FR_RightWheel.brakeTorque = 0;
    }

    private void UpdateEachWheelMoves()
    {
        ReflectWheelMoves(FR_RightWheel, FrontRightWheel);
        ReflectWheelMoves(FR_LeftWheel, FrontLeftWheel);
        ReflectWheelMoves(BK_RightWheel, RearRightWheel);
        ReflectWheelMoves(BK_LeftWheel, RearLeftWheel);
        ReflectPlowWheelMoves(plowWheelColider, plowWheel);
    }

    private void VerticalWheelMove(float vertInput)
    {
        BK_LeftWheel.motorTorque = vertInput * MotorForce;
        BK_RightWheel.motorTorque = vertInput * MotorForce;
        if (driveMode == DrivingMode.FourWheelDrive)
        {
            FR_LeftWheel.motorTorque = vertInput * MotorForce;
            FR_RightWheel.motorTorque = vertInput * MotorForce;
        }
        if (IsDiffLock)
            ReflectDiffLock();
    }
    private void HandThrottleWheelMove(float vertInput, float MotorForce)
    {
        BK_LeftWheel.motorTorque = vertInput * MotorForce;
        BK_RightWheel.motorTorque = vertInput * MotorForce;
        if (driveMode == DrivingMode.FourWheelDrive)
        {
            FR_LeftWheel.motorTorque = vertInput * MotorForce;
            FR_RightWheel.motorTorque = vertInput * MotorForce;
        }
        if (IsDiffLock)
            ReflectDiffLock();
    }

    public void HorizontalWheelMove(float horiInput)
    {
        FR_LeftWheel.steerAngle = -horiInput * 18 ;
        FR_RightWheel.steerAngle = -horiInput * 18 ;
    }

    private void ReflectWheelMoves(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        collider.GetWorldPose(out pos, out rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }
    private void ReflectPlowWheelMoves(WheelCollider collider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        collider.GetWorldPose(out pos, out rot);
        //wheelTransform.position = pos;
        wheelTransform.rotation = rot;
    }

    private void ReflectShuttleLever(TurnableObject turnableObject)
    {
        if (turnableObject.value <= -9)
            SwitchShuttleLever(MoveDirection.Back);
        else if (turnableObject.value >= 9)
            SwitchShuttleLever(MoveDirection.Front);
        else if(turnableObject.value >-9&&turnableObject.value<9)
            SwitchShuttleLever(MoveDirection.Neutral);
    }

    private void ReflectInteractingBrake()
    {
        if (IsPBrake)
        {
            BK_LeftWheel.brakeTorque = parkingBrake;
            BK_RightWheel.brakeTorque = parkingBrake;
            if (driveMode == DrivingMode.FourWheelDrive)
            {
                FR_LeftWheel.brakeTorque = parkingBrake;
                FR_RightWheel.brakeTorque = parkingBrake;
            }
        }
        else
            ReleaseBreak();
    }

    public void ParkingBrakeTriggered(TurnableObject turnableObject)//for lever interaction
    {
        if (turnableObject.value > 140)
        {
            ReleasingParkingBrake();
            ReflectInteractingBrake();
        }
        else if (turnableObject.value < 135)
        {
            InteractParkingBrake();
            ReflectInteractingBrake();
        }

    }

    private void ReflectCreeperSpeed()
    {
        if (IsCreeperSpeed)
        {
            engineMaxSpeed = creeperSpeed;
            accelerationTypes = AccelerationTypes.CreeperSpeed;
        }
        else
        {
            engineMaxSpeed = MaxSpeed;
            accelerationTypes = AccelerationTypes.NormalSpeed;
        }
    }

    public void CreeperSpeedTriggered(TurnableObject turnableObject)//for lever interaction
    {
        InteractCreeperSpeed();
        ReflectCreeperSpeed();
    }

    private void ReflectHandThrottle()
    {
        HandThrottleAccelerate(_throttleSpeed);
    }

    public void HandThrottleTriggered(TurnableObject turnableObject)
    {
        _throttleSpeed = turnableObject.value;
        InteractHandThrottler();
        ReflectHandThrottle();
    }

    public void TriggeredDiffLock(TurnableObject turnableObject)
    {
        InteractDiffLock();
        ReflectDiffLock();
    }

    private void ReflectDiffLock()
    {
        if (BK_LeftWheel.rotationSpeed <= BK_RightWheel.rotationSpeed)
            BK_LeftWheel.rotationSpeed = BK_RightWheel.rotationSpeed;
        else
            BK_RightWheel.rotationSpeed = BK_LeftWheel.rotationSpeed;
    }

    private void ReflectGearChange(TurnableObject turnableObject)
    {
        IncreaseGear();
        DecreaseGear();
    }

    private void ReflectRangeShift(TurnableObject turnableObject)
    {
        if (turnableObject.value > 0)
        {
            //SwitchGear();
        }
    }

    private void ReflectPTOEngage(TurnableObject turnableObject)
    {
        if (turnableObject.value > 65) InteractPTO();
        else if (turnableObject.value < 50) ReleasePTO();
    }

    private void ReflectPTOSpeed(TurnableObject turnableObject)
    {
        if (IsPTOEngaged)
            OnSetPlow(turnableObject.value);
    }

    private void OnSetPlow(float value)
    {
        rotValue = (value*2 )- 90;
        rotValue = rotValue >= 60 ? 60 : rotValue;
        Plow.localRotation = Quaternion.AngleAxis(rotValue, Vector3.forward);
        //PlowMove(PloughConfig, rotValue, new Vector3(0, 0.1f, 0));
    }

    private void PlowMove(ConfigurableJoint config, float value, Vector3 _veocity)
    {
        var limit = config.angularZLimit;
        var velocity = config.targetAngularVelocity;
        velocity = _veocity;
        limit.limit = value;
        config.targetAngularVelocity = velocity;
        config.angularZLimit = limit;
    }

    private void ReflectIgnition(TurnableObject obj)
    {
        if (obj.value > 20 && obj.value < 50)
        {
            IgnitionIndicator.color = standBy;
        }
        else if(obj.value <= 80 && obj.value >= 50)
        { 
            IgnitionIndicator.color = on;
            SwitchEngineONOFF(EngineState.ON);
        }
        else if (obj.value < 20)
        {
            IgnitionIndicator.color = off   ;
            SwitchEngineONOFF(EngineState.OFF);
        }
    }

    private void ResetIgnitionKeyPos(TurnableObject turnObj, GrabbedObject grabObj)
    {
        //if (turnObj.value <= 80 && turnObj.value >= 50)
        //    grabObj.transform.localRotation = Quaternion.AngleAxis(50, turnObj.turnAxis);
    }


}
