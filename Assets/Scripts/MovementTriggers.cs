using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTriggers : MonoBehaviour
{

    public enum Type
    {
        Acc,
        Break,
        Back
    }

    public static bool forward = true;
    public Type mech;
    public Quaternion DefaultRotation;
    public bool IsRotated = false;
    public bool SetLimit = false;
    private bool isPressed;
    public Vector2 Limits = new Vector3(0.0f, 90.0f);
    public Vector3 TurnAxis = Vector3.forward;
    public Transform Pedal;

    private float _moveValue;
    private float _prevMoveValue=0f;

    private void Start()
    {
        DefaultRotation = this.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        ActivatePedal();
    }

    private void OnTriggerStay(Collider other)
    {
        switch (mech)
        {
            case Type.Acc:
                VehicleMovements.instance.Accelerate(1) ;
                break;
            case Type.Break:
                VehicleMovements.instance.ApplyBreak();
                break;
            case Type.Back:
                VehicleMovements.instance.Accelerate(-1);
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ReleasePedal();
        switch (mech)
        {
            case Type.Acc:
                VehicleMovements.instance.StayPut();
                break;
            case Type.Break:
                VehicleMovements.instance.ReleaseBreak();
                break;
            case Type.Back:
                VehicleMovements.instance.StayPut();
                break;
            default:
                break;
        }
    }

    public void ActivatePedal()
    {
        if (Pedal == null) return;
        if (TurnAxis == Vector3.forward && mech == Type.Break)
            Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);

        else if (TurnAxis == Vector3.forward)
            Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);

        else if (TurnAxis == Vector3.right)
            Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);

        else if (TurnAxis == Vector3.up)
            Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);
    }

    public void ReleasePedal()
    {
        if (Pedal == null) return;
        if (TurnAxis == Vector3.forward && mech == Type.Break)
            Pedal.localRotation = Quaternion.AngleAxis(10, TurnAxis);

        else if (TurnAxis == Vector3.forward)
            Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);

        else if (TurnAxis == Vector3.right)
            Pedal.localRotation = Quaternion.AngleAxis(0, TurnAxis);

        else if (TurnAxis == Vector3.up)
            Pedal.localRotation = Quaternion.AngleAxis(-10, TurnAxis);
    }

    private void RotatePedalsOnInteract(Quaternion target)
    {
        if(!this.IsRotated)
        {
            this.IsRotated = true;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, target, 0.7f * Time.deltaTime);
        }
    }

    private void ResetRotationOnRelease()
    {
        if(this.IsRotated)
        {
            this.IsRotated = false;

            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, DefaultRotation, 0.5f * Time.deltaTime);
        }
    }

}
