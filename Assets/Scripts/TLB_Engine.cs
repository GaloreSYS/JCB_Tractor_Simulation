using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;
using Manus.Interaction;
using System;
using Vehicle.Engine;
using Input = UnityEngine.Input;


public class TLB_Engine : MonoBehaviour
{
    public static TLB_Engine Instance;
    [SerializeField] int maxTorque, maxRPM = 2200, engineBraking = 500, idleRPM = 950, rpm; //= 516
    [SerializeField] private float ThrottleInput;
    [SerializeField] AnimationCurve torqueCurve;
    public float torque;
    public TLB_WCManager wCManager;
    public float speed, MaxSpeed;
    public  bool isParkingBreak = true;
    public static bool isIgnition = false;
    public  bool isNeutral ;
    public  bool isForward ;
    public  bool isReverse ;
    public bool Breaks, Parking;


    //[SerializeField] ConfigurableJoint _backArmHingeJoint;
    //[SerializeField] ConfigurableJoint _backArmHingeJoint2;
    //[SerializeField] ConfigurableJoint _backArmHingeJoint3;
    [SerializeField] Transform _backArm;
    [SerializeField] Vector2 LimitBackArm;
    [SerializeField] Vector3 TurnAxisBackArm;
    [SerializeField] Vector2 LimitBackForwardArm;
    [SerializeField] Vector3 TurnAxisBackArmFrontMove;
    [SerializeField] Transform _backForeArm;
    [SerializeField] Vector2 LimitForeArm;
    [SerializeField] Vector3 TurnAxisForeArm;
    [SerializeField] Transform _backBucket;
    [SerializeField] Vector2 LimitBucket;
    [SerializeField] Vector3 TurnAxisBucket;

    [SerializeField] Button _backArmLeftBtn;
    [SerializeField] Button _backArmRightBtn;
    [SerializeField] Button _backArmUpBtn;
    [SerializeField] Button _backArmDownBtn;

    //[SerializeField] ConfigurableJoint _frontArmHingeJoint;
    //[SerializeField] ConfigurableJoint _frontArmBucketHingeJoint;
    [SerializeField] Transform _frontArm;
    [SerializeField] Vector2 LimitFrontArm;
    [SerializeField] Vector3 TurnAxisFrontArm;
    [SerializeField] Transform _frontArmBucket;
    [SerializeField] Vector2 LimitfrontArmBucket;
    [SerializeField] Vector3 TurnAxisFrontArmBucket;

    //[SerializeField] TurnableObject RightStabilizerLever;
    //[SerializeField] TurnableObject LeftStabilizerLever;
    // [SerializeField] TurnableObject ParkingBreakLever;
    [SerializeField] TurnableObject IgnitionKey;

    //[SerializeField] TurnableObject ShuttleGear;
    [SerializeField] Transform _sterring;

    [SerializeField] Transform _hydraulicRightLeg;
    [SerializeField] Transform _hydraulicLeftLeg;

    [SerializeField] Text SpeedText;
    [SerializeField] Text RPMText;
    [SerializeField] Rigidbody VehicleRB;
    Vector2 _limitRangeLeg = new(-7, 0);
    public Image IgnitionIndicator;
    private Color32 off = new Color32(218, 11, 0, 255);
    private Color32 on = new Color32(26, 219, 0, 255);
    private Color32 standBy = new Color32(218, 182, 0, 255);

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //RightStabilizerLever.onGrabEnd += ResetLeverPos;
        //RightStabilizerLever.onValueChanged += InteractedRightLever;
        //LeftStabilizerLever.onValueChanged += InteractedLeftLever;
        //LeftStabilizerLever.onGrabEnd += ResetLeverPos;
        //ParkingBreakLever.onValueChanged += InteractParkingLever;
        IgnitionKey.onValueChanged += ReflectIgnition;
        IgnitionKey.onGrabEnd += ResetIgnitionKeyPos;
        //ShuttleGear.onValueChanged += InteractShuttleGear;
    }

    private void OnDestroy()
    {
        //RightStabilizerLever.onGrabEnd -= ResetLeverPos;
        //RightStabilizerLever.onValueChanged -= InteractedRightLever;
        //LeftStabilizerLever.onValueChanged -= InteractedLeftLever;
        //LeftStabilizerLever.onGrabEnd -= ResetLeverPos;
        //ParkingBreakLever.onValueChanged -= InteractParkingLever;
        IgnitionKey.onValueChanged -= ReflectIgnition;
        IgnitionKey.onGrabEnd -= ResetIgnitionKeyPos;
        //ShuttleGear.onValueChanged -= InteractShuttleGear;
    }


    public void DetectParkingLeverValueOFF()
    {
        if (Parking == false)
        {
            isParkingBreak = true;
            wCManager.ApplyBrake(maxTorque * 10);
        }
    }

    public void DetectParkingValueON()
    {
        if (Parking)
        {
            isParkingBreak = false;
            wCManager.ApplyBrake(0);
        }
    }

    private void InteractParkingLever(TurnableObject obj)
    {
        if (obj.value > -7f)
        {
            isParkingBreak = false;
            wCManager.ApplyBrake(0);
        }
        else if (obj.value < -33f)
        {
            isParkingBreak = true;
            wCManager.ApplyBrake(maxTorque * 10);
        }
    }

    private void InteractedRightLever(TurnableObject obj)
    {
        if (obj.value > obj.startValue)
        {
            var clamp = Mathf.Clamp(((obj.value / 1500f) + _hydraulicRightLeg.localPosition.y), _limitRangeLeg.x,
                _limitRangeLeg.y);
            _hydraulicRightLeg.localPosition = new Vector3(_hydraulicRightLeg.localPosition.x, clamp,
                _hydraulicRightLeg.localPosition.z);
        }
        else if (obj.value < obj.startValue)
        {
            var clamp = Mathf.Clamp(-((obj.value / 1500f) - _hydraulicRightLeg.localPosition.y), _limitRangeLeg.x,
                _limitRangeLeg.y);
            _hydraulicRightLeg.localPosition = new Vector3(_hydraulicRightLeg.localPosition.x, clamp,
                _hydraulicRightLeg.localPosition.z);
        }
    }

    private void InteractedLeftLever(TurnableObject obj)
    {
        if (obj.value > obj.startValue)
        {
            var clamp = Mathf.Clamp(((obj.value / 1500f) + _hydraulicLeftLeg.localPosition.y), _limitRangeLeg.x,
                _limitRangeLeg.y);
            _hydraulicLeftLeg.localPosition = new Vector3(_hydraulicLeftLeg.localPosition.x, clamp,
                _hydraulicLeftLeg.localPosition.z);
        }
        else if (obj.value < obj.startValue)
        {
            var clamp = Mathf.Clamp(-((obj.value / 1500f) - _hydraulicLeftLeg.localPosition.y), _limitRangeLeg.x,
                _limitRangeLeg.y);
            _hydraulicLeftLeg.localPosition = new Vector3(_hydraulicLeftLeg.localPosition.x, clamp,
                _hydraulicLeftLeg.localPosition.z);
        }
    }

    private void ResetLeverPos(TurnableObject turnObj, GrabbedObject grabObj)
    {
        grabObj.transform.localRotation = Quaternion.Slerp(grabObj.transform.localRotation, turnObj.startRot, 2);
    }

    private void FixedUpdate()
    {
        Breaks = isParkingBreak;
        SpeedText.text = ((int)(VehicleRB.velocity.magnitude * 3.6)).ToString();
        RPMText.text = (Mathf.Abs((int)wCManager.CalculateRPM()) / 100).ToString();
        //ThrottleInput = UnityEngine.Input.GetAxis("Vertical");
        speed = VehicleRB.velocity.magnitude * 3.6f;
        //torque = torqueCurve.Evaluate(rpm / (float)maxRPM) * maxTorque;
        //if (ThrottleInput > 0 || ThrottleInput < 0)
        //{
        //    if (speed <= MaxSpeed)
        //    {
        //        wCManager.ApplyTorue(-ThrottleInput * (maxTorque * 3));
        //    }

        //}

        //if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        //{
        //    wCManager.ApplyBrake(maxTorque * 10);

        //}
        //else
        //{
        //    wCManager.ApplyBrake(0);
        //}
        wCManager.Steering(_sterring.rotation.y);
    }

    public void FrontArmUpAndMove(float value)
    {
        float _rotValue;

        if (value == 0)
        {
            _rotValue = Mathf.Clamp(_frontArm.localEulerAngles.x + 0.05f, LimitFrontArm.x, LimitFrontArm.y);
            _frontArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisFrontArm);
        }
        else if (value == 1)
        {
            _rotValue = Mathf.Clamp(_frontArm.localEulerAngles.x - 0.05f, LimitFrontArm.x, LimitFrontArm.y);
            _frontArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisFrontArm);
        }
    }

    public void FrontBucketUpAndMove(float value)
    {
        float _rotValue;

        if (value == 0)
        {
            _rotValue = Mathf.Clamp(_frontArmBucket.localEulerAngles.x - 0.05f, LimitfrontArmBucket.x,
                LimitfrontArmBucket.y);
            _frontArmBucket.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisFrontArmBucket);
        }
        else if (value == 1)
        {
            _rotValue = Mathf.Clamp(_frontArmBucket.localEulerAngles.x + 0.05f, LimitfrontArmBucket.x,
                LimitfrontArmBucket.y);
            _frontArmBucket.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisFrontArmBucket);
        }
    }

    private void OnCntrollConfigMove(ConfigurableJoint config, Vector3 _tragetPos)
    {
        config.targetPosition = _tragetPos;
    }


    public void BackArmLeftandRightMove(float value)
    {
        float _rotValue;

        if (value == 0)
        {
            _rotValue = Mathf.Clamp(_backArm.localEulerAngles.y + 0.05f, LimitBackArm.x, LimitBackArm.y);
            //Quaternion.
            _backArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisBackArm);
        }
        else if (value == 1)
        {
            _rotValue = Mathf.Clamp(_backArm.localEulerAngles.y - 0.05f, LimitBackArm.x, LimitBackArm.y);
            _backArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisBackArm);
        }
    }

    public void BackFWDAndBCKMove(float value)
    {
        float _rotValue;

        if (value == 0)
        {
            _rotValue = Mathf.Clamp(_backArm.localEulerAngles.x + 0.05f, LimitBackForwardArm.x, LimitBackForwardArm.y);
            _backArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisBackArmFrontMove);
        }
        else if (value == 1)
        {
            _rotValue = Mathf.Clamp(_backArm.localEulerAngles.x - 0.05f, LimitBackForwardArm.x, LimitBackForwardArm.y);
            _backArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisBackArmFrontMove);
        }
    }

    public void BackForeArmUpAndMove(float value)
    {
        float _rotValue;

        if (value == 0)
        {
            _rotValue = Mathf.Clamp(_backForeArm.localEulerAngles.x - 0.05f, LimitForeArm.x, LimitForeArm.y);
            _backForeArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisForeArm);
        }
        else if (value == 1)
        {
            _rotValue = Mathf.Clamp(_backForeArm.localEulerAngles.x + 0.05f, LimitForeArm.x, LimitForeArm.y);
            _backForeArm.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisForeArm);
        }
    }

    public void BackArmDigMove(float value)
    {
        float _rotValue;

        if (value == 0)
        {
            _rotValue = Mathf.Clamp(_backBucket.localEulerAngles.x - 0.05f, LimitBucket.x, LimitBucket.y);
            _backBucket.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisBucket);
        }
        else if (value == 1)
        {
            _rotValue = Mathf.Clamp(_backBucket.localEulerAngles.x + 0.05f, LimitBucket.x, LimitBucket.y);
            _backBucket.localRotation = Quaternion.AngleAxis(_rotValue, TurnAxisBucket);
        }
    }

    public void OnCntrollConfigMovement(ConfigurableJoint config, float value, Vector3 _veocity)
    {
        if (config.angularXMotion == ConfigurableJointMotion.Limited)
        {
            var limit = config.lowAngularXLimit;
            var velocity = config.targetAngularVelocity;
            velocity = _veocity;
            limit.limit = value;
            config.targetAngularVelocity = velocity;
            config.lowAngularXLimit = limit;
        }
        else
        {
            var limit = config.angularYLimit;
            var velocity = config.targetAngularVelocity;
            velocity = _veocity;
            limit.limit = value;
            config.targetAngularVelocity = velocity;
            config.angularYLimit = limit;
        }
    }

    private void ReflectIgnition(TurnableObject obj)
    {
        if (obj.value > 10 && obj.value < 35)
        {
             IgnitionIndicator.color = off;
            GearControllerDataLinker.Instance.ControllData.CheckEngine = false;
            EngineStartAudioManger.Instance.PlayAudio1();
            isIgnition = false;
        }
        else if (obj.value < 7)
        {
              IgnitionIndicator.color = standBy;
            EngineStartAudioManger.Instance.StopAudio();
         
        }
        else if (obj.value <= 45 && obj.value >= 30)
        {
            IgnitionIndicator.color = on;
            GearControllerDataLinker.Instance.ControllData.CheckEngine = true;
            EngineStartAudioManger.Instance.PlayAudio2();
            isIgnition = true;
        }
    }


    private void ResetIgnitionKeyPos(TurnableObject turnObj, GrabbedObject grabObj)
    {
        //if (turnObj.value <= 45 && turnObj.value >= 30)
        //    grabObj.transform.localRotation = Quaternion.AngleAxis(30,turnObj.turnAxis);
    }


    private void InteractShuttleGear(TurnableObject turnableObject)
    {
        if (turnableObject.value <= -13)
        {
            isNeutral = false;
            isForward = false;
        }
        else if (turnableObject.value >= 13)
        {
            isNeutral = false;
            isForward = true;
        }
        else if (turnableObject.value > -13 && turnableObject.value < 13)
            isNeutral = true;
    }

    public void Forwordandbackword(int value)
    {
        if (value == 0)
        {
            isNeutral = true;
            isForward = false;
            isReverse = false;

        }


        if (value == 1)
        {
            isNeutral = false;
            isForward = true;
            isReverse = false;
        }

        if (value == 2)
        {
            isNeutral = false;
            isForward = false;
            isReverse = true;
        }

        Debug.LogError(value.ToString());
    }


    private void Update()
    {
        if (EngineManager.CurrentEngineState == EngineState.ON)
        {
            Parking = true;
        }
        else
        {
            Parking = false;
        }
        
        keyBoardController();
    }
    
    public void keyBoardController()
    {
      var  GearValue = 1;
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (TLB_Engine.Instance.isForward)
            {
                wCManager.ApplyTorue(1 * (10000 * 1));
            }
            else if (TLB_Engine.Instance.isReverse)
            {
                wCManager.ApplyTorue(1 * (5000));
            }
            else
            {
                Debug.Log("NEUTRAL");
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            wCManager.ApplyTorue(0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wCManager.ApplyBrake(2000);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            wCManager.ApplyBrake(0);
        }
    }
}