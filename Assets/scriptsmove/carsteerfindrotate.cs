using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class carsteerfindrotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float a,z;
    public bool b;
    public Rigidbody _intObj;
    public Vector3 check;
    public GameObject cubesteer;
    void Start()
    {
        _intObj = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //     this.gameObject.transform.localEulerAngles = new Vector3(0, 0,z=(b)? UnityEngine.Random.Range(0, 360):0);
        //     this.gameObject.transform.localPosition = new Vector3(-0.0209999997f, 1.13552856f, -7.26100016f);
        //this.gameObject.transform.localRotation = Quaternion.Euler(new Vector2(0,-180));
        //   this.gameObject.transform.localEulerAngles.z = 5;
        //      Debug.Log(this.gameObject.transform.eulerAngles.z) ;
        //      Quaternion objRot = _intObj.rigidbody.rotation;  //_intObj is the interactive object
        /*    check.x = 0;
            check.y = -180;
            this.gameObject.transform.localEulerAngles = check;
            */


        //fromcube
        //   this.transform.localEulerAngles = new Vector3(cubesteer.transform.localEulerAngles.x, cubesteer.transform.localEulerAngles.y, cubesteer.transform.localEulerAngles.z);


        this.transform.localEulerAngles = new Vector3(cubesteer.transform.localEulerAngles.x, Mathf.Clamp(0,0,265), cubesteer.transform.localEulerAngles.z);


        if (this.gameObject.transform.localEulerAngles.y >= 0)
        {
     //       Debug.Log(this.gameObject.transform.localEulerAngles.z);
        }

        a = this.gameObject.transform.localEulerAngles.y-360;
       
      //  Debug.Log(a+"hi");

        if (a < 0)
        {
    //        Debug.Log(a);
        }
    }


    private void OnCollisionStay(Collision collision)
    {
        b = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        b=false;
    }
    private Rigidbody Get_intObj()
    {
        return _intObj;
    }



 /*   private void FixedUpdate()
    {

        Quaternion objRot = _intObj.rigidbody.rotation;
        Vector3 inEuler = objRot.eulerAngles;
        //  if (inEuler.y != 0F || inEuler.z != 0.0F)
        {
            inEuler.y = -180F;
            inEuler.x = 0F;
            objRot = Quaternion.Euler(inEuler);
            //        _intObj.rigidbody.rotation = objRot;
        }
    }*/

}