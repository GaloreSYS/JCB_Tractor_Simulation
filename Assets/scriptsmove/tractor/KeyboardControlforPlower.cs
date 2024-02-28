using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardControlforPlower : MonoBehaviour
{
    public GameObject UpObject, DownObject;
    public ArmDataJCB TractorPlowerValue;
    public bool downobject, Upobject;

    private void Start()
    {
        Up();
    }

    public void Up()
    {
        togglebuttonUP();
        DownObject.SetActive(false);
        downobject = DownObject.activeSelf;
    }

    public void Down()
    {
        togglebuttonDown();
        UpObject.SetActive(false);
        Upobject = UpObject.activeSelf;
    }
   
    private void Update()
    {
        TractorPlowerValue.TractorPlowDown = downobject;
        TractorPlowerValue.TractorPlowUP = Upobject;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
           Up();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
Down();
        }
    }

    public void togglebuttonUP()
    {
        Upobject = UpObject.activeSelf;
        UpObject.SetActive(!Upobject);
    }

    public void togglebuttonDown()
    {
        downobject = DownObject.activeSelf;
        DownObject.SetActive(!downobject);
    }
}
