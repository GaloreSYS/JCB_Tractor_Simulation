using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFollowTest : MonoBehaviour
{
    public GameObject ParentObject;
    public GameObject ChildObject;
    public float A;
    public float B;
    public Quaternion InitialRotation;
    public Quaternion childObjInitialRotation;
    public Quaternion childObjTargetRotation;

    // Start is called before the first frame update
    void Start()
    {
        InitialRotation = ParentObject.transform.localRotation;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Mathf.Abs(ParentObject.transform.localRotation.eulerAngles.y-InitialRotation.eulerAngles.y)>=A && Mathf.Abs(ParentObject.transform.localRotation.eulerAngles.y - InitialRotation.eulerAngles.y) <= B)
        {
            //s   ChildObject.transform.localRotation = Quaternion.Euler(ChildObject.transform.localRotation.x,180f, ChildObject.transform.localRotation.z);
            ChildObject.transform.localRotation = childObjTargetRotation;
        }
        else 
        {
            ChildObject.transform.localRotation = childObjInitialRotation;
        }
        //if (Mathf.Abs(ParentObject.transform.localRotation.eulerAngles.y - InitialRotation.eulerAngles.y) <= 20)
    }
}
