using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCPMovementTriggers : MonoBehaviour
{
    public TLB_WCManager wCManager;
    public TLB_Engine tlbEngine;
    public Transform VRCamera;
    public Transform Seat;
    //public Transform RHand;
    public Vector3 TurnAxis = Vector3.forward;
    public Transform Pedal;
    public int GearValue;

    public ArmDataJCB GearData; 
    public enum Type
    {
        Acc,
        Break,
        Back,
        BackRotation,
        Up,
        Down,
        Left,
        Right,
        FRLeft,
        FRRight,
        FRRotation
    }


    public void Update()
    {
      GearValue  = GearData.gearValue;
    }

    public static bool forward = true;
    public Type mech;
    public void OnTriggerEnter()
    {
        //if (TurnAxis == Vector3.forward && mech == Type.Break)
        //    Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);

        //else if (TurnAxis == Vector3.forward)
        //    Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);

        //else if (TurnAxis == Vector3.right)
        //    Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);

        //else if (TurnAxis == Vector3.up)
        //    Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);
    }
    private void OnTriggerStay(Collider other)
    {
        GameObject go = other.gameObject;

        if(go.name == "LegTrackerRight" || go.name == "LegTrackerLeft")
        {
            Debug.Log("Collision detected");
            switch (mech)
            {
                case Type.Acc:
                    wCManager.ApplyTorue(1 * (10000 * GearValue));
                    break;
                case Type.Break:
                    wCManager.ApplyBrake(2000);
                    break;
                case Type.Back:
                    wCManager.ApplyTorue(1 * (30000 * 3));
                    break;
                case Type.BackRotation:
                    BackRotation();
                    break;
                case Type.Up:
                    tlbEngine.BackForeArmUpAndMove(0);
                    break;
                case Type.Down:
                    tlbEngine.BackForeArmUpAndMove(1);
                    break;
                case Type.Left:
                    tlbEngine.BackArmLeftandRightMove(0);
                    break;
                case Type.Right:
                    tlbEngine.BackArmLeftandRightMove(1);
                    break;
                case Type.FRLeft:
                    tlbEngine.FrontArmUpAndMove(0);
                    break;
                case Type.FRRight:
                    tlbEngine.FrontArmUpAndMove(1);
                    break;
                case Type.FRRotation:
                    FRRotation();
                    break;
                default:
                    break;
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.name == "LegTrackerRight" || go.name == "LegTrackerLeft")
        {

            switch (mech)
            {
                case Type.Acc:
                    wCManager.ApplyTorue(0);
                    break;
                case Type.Break:
                    wCManager.ApplyBrake(0);
                    break;
                case Type.Back:
                    wCManager.ApplyTorue(0);
                    break;
                default:
                    break;
            }

        }
            //if (TurnAxis == Vector3.forward && mech == Type.Break)
            //    Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);

            //else if (TurnAxis == Vector3.forward)
            //    Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);

            //else if (TurnAxis == Vector3.right)
            //    Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);

            //else if (TurnAxis == Vector3.up)
            //    Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);
        
    }

    public void SeatRotation()
    {
        /*VRCamera.position = new Vector3(1.94f, 4.9f, 7.7f);
        Quaternion Value =  Quaternion.Euler(-0.057f, -89.705f, 0.032f);
        VRCamera.rotation = Value;*/
    }
    public void BackRotation()
    {
        //Seat.position = new Vector3(VRCamera.position.x, VRCamera.position.y, VRCamera.position.z);
        //Quaternion CameraValue = Quaternion.Euler(-89.606f, -266.78f, 0.572f);
        //Seat.rotation = CameraValue;
        //RHand.position = new Vector3(-1.2f, 0f, 0f);
    }

    public void FRRotation()
    {
        //Quaternion CameraValue = Quaternion.Euler(-90f, 266.78f, -0.017f);
        //Seat.rotation = CameraValue;
    }
}
