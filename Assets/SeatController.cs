using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatController : MonoBehaviour
{
    [SerializeField] Transform camera;
    [SerializeField] Transform Target;
    private void Update()
    {
        //Debug.Log(transform.localEulerAngles);
        //if(camera.localEulerAngles.y < 220 && camera.localEulerAngles.y>150 )
        //{
        //    Target.localRotation = new Quaternion(Target.localEulerAngles.x, Target.localEulerAngles.y, 180,0);
        //}
     
    }
}
