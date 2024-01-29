using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brakescri : MonoBehaviour
{
    public ArmDataJCB brakemanager;

    private void OnTriggerStay(Collider other)

    {
        if (other.gameObject.tag == "Left")
        {
            brakemanager.brakess = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        brakemanager.brakess=false;
    }





}
