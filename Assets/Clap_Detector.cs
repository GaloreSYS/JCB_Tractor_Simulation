using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clap_Detector : MonoBehaviour
{
    public bool Clapped;
    public TouchSceneChanger touchSceneChanger;
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.name);
        if(other.gameObject.name=="ManusHand_L")
        {
            Debug.Log("Claped");
            if (!Clapped)
            {
                Clapped = true;
                touchSceneChanger.GoToSimulator();
            }
        }
        
    }
}
