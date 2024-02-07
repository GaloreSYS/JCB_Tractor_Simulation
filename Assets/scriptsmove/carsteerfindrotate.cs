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

        a = this.gameObject.transform.localEulerAngles.y-360;

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




}