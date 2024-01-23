using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gearbox : MonoBehaviour
{

    public movementmanager gearspeedfrontback;
    public UnityEvent front = new();
    public UnityEvent back = new();
    public Vector3 temp;
    public GameObject objj;
    public Transform a;
    public Vector3 b;
    public float obj = 90, obj2 = 0, obj3 = 0;//obj3=1;
    void Start()
    {
        
    }
    void Update()
    {
   //     this.gameObject.transform.localPosition = new Vector3(-0.541053057f, 0.192304134f, -0.0875882208f);

        obj = Mathf.Clamp(obj, 90, 90);
        obj2 = Mathf.Clamp(obj2, 0, 0);
        obj3 = Mathf.Clamp(obj3, 20, 60);
        b.x = obj3;
        frontbackselectorr();

/*

        if (this.gameObject.transform.localEulerAngles.y > 0 && this.gameObject.transform.localEulerAngles.y <= 10)
        {

            gearspeedfrontback.frontandbackdecider = 1;

            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o10");
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,10, 0));
        }





  /*      if (this.gameObject.transform.localEulerAngles.y >= 11 && this.gameObject.transform.localEulerAngles.y <= 20)
        {
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o20");
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,20,0));
        }
        if (this.gameObject.transform.localEulerAngles.y >= 21&& this.gameObject.transform.localEulerAngles.y <= 30)
        {
            Debug.Log("o30");

            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,30, 00));
        }
        if (this.gameObject.transform.localEulerAngles.y >= 31 && this.gameObject.transform.localEulerAngles.y <= 40)
        {
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o40");
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,40, 0));
        }
        if (this.gameObject.transform.localEulerAngles.y >= 41 && this.gameObject.transform.localEulerAngles.y <= 50)
        {
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o50");
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,50,0));
        }
       if ((this.gameObject.transform.localEulerAngles.y >= 51) && (this.gameObject.transform.localEulerAngles.y <= 60))
        {
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3( 0,50, 0));
        }
        if (this.gameObject.transform.localEulerAngles.y >= 60 && this.gameObject.transform.localEulerAngles.y<=180)
        {
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o60");
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0,50, 0));
        }

        */



        /*

        if ((this.gameObject.transform.localEulerAngles.y <= 330) &&(this.gameObject.transform.localEulerAngles.y >= 300))
        {

            gearspeedfrontback.frontandbackdecider = 2;
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o70");
            //   this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(-40, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3( 0,-40, 0));
        }
     */
    }


    public void frontbackselectorr()
    {

        if (this.gameObject.transform.localEulerAngles.y > 0 && this.gameObject.transform.localEulerAngles.y <= 40)
        {

            gearspeedfrontback.frontandbackdecider = 2;

            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o10");
            //       this.gameObject.transform.localRotation=   Quaternion.Euler(new Vector3(60, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 10, 0));
        }
      

        if ((this.gameObject.transform.localEulerAngles.y <= 350) && (this.gameObject.transform.localEulerAngles.y >= 300))
        {

            gearspeedfrontback.frontandbackdecider = 1;
            Debug.Log(this.gameObject.transform.localEulerAngles.x);
            Debug.Log("o70");
            //   this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(-40, 90, 0));
            this.gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, -40, 0));
        }
    }
}