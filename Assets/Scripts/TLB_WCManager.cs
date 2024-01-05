using UnityEngine;

//public enum DrivingMode
//{
//    FourWheelDrive,
//    TwoWheelDrive

//}
public class TLB_WCManager : MonoBehaviour
{
    public bool developmentMode;
    // public DrivingMode TLB_DrivingMode;
    [SerializeField] private WheelCollider[] WheelColliders;
    public Transform[] WheelTransform;
    [SerializeField] WheelCollider FR, FL, RR, RL;
    float rpm;

    public float Steerinput;
    float steeringOffset = 0;
    // Start is called before the first frame update
    void Start()
    {
        WheelColliders = GetComponentsInChildren<WheelCollider>();

        WheelColliders[0] = FR;
        WheelColliders[1] = FL;
        WheelColliders[2] = RR;
        WheelColliders[3] = RL;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    private void FixedUpdate()
    {
        UpdateWheelMovements();
    }
    
    public void Steering(float Steerinput)
    {
//        Debug.Log(Steerinput);
        WheelColliders[0].steerAngle = Steerinput*18; //* 10 + steeringOffset;
        WheelColliders[1].steerAngle = Steerinput*18;//* 10 + steeringOffset;
    }
    
    public void ApplyTorue(float torque)
    {   
        if (!TLB_Engine.Instance.isParkingBreak && TLB_Engine.isIgnition && !TLB_Engine.Instance.isNeutral || developmentMode )
        {
            torque = TLB_Engine.Instance.isForward ? -torque : torque;
            for (int i = 0; i < WheelColliders.Length; i++)
            {
                //if (TLB_DrivingMode == DrivingMode.FourWheelDrive)
                {
                    WheelColliders[i].motorTorque = torque / 4;
                    // rpm = WheelColliders[0].rpm;
                }
                //if (TLB_DrivingMode == DrivingMode.TwoWheelDrive)
                {
                    if (i < 2)
                    {
                        WheelColliders[i].motorTorque = torque / 4;
                        // rpm = WheelColliders[2].rpm;
                    }

                }
            }
        }
        
    }

    public float CalculateRPM()
    {
        return (WheelColliders[2].rpm + WheelColliders[3].rpm) / 2; ;
    }
    public void ApplyBrake(float BrakingTorque)
    {
        for(int i = 0; i < WheelColliders.Length; i++)
        {
            WheelColliders[i].brakeTorque = BrakingTorque;
        }
    }
    public void EngineBraking(float EngineBrake)
    {
        for (int i = 0; i < WheelColliders.Length; i++)
        {
            WheelColliders[i].brakeTorque = EngineBrake / 2;
        }
    }
    private void UpdateWheelMovements()
    {
        for (var i = 0; i < WheelTransform.Length; i++)
        {
            Vector3 pos;
            Quaternion rot;
            WheelColliders[i].GetWorldPose(out pos, out rot);
            WheelTransform[i].transform.position = pos;
            WheelTransform[i].transform.rotation = rot;
        }
    }
}