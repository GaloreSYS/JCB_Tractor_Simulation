using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    public Transform Vehicle;
    public Vector3 Offset;
    public float FollowSpeed;
    public float LookSpeed;
    void FixedUpdate()
    {
        
    }

    //private void LookAtTarget()
    //{
    //    Vector3 lookDir = Vehicle.position - transform.position;
    //    Quaternion rot = Quaternion.LookRotation(lookDir,Vector3.up);
    //    transform.rotation = Quaternion.Lerp(transform.rotation, rot, LookSpeed*Time.deltaTime);
    //}

    private void MoveToTarget()
    {

    }
}
