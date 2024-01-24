using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratorTrue : MonoBehaviour
{
    public ArmDataJCB manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
   
    {
        if (other.gameObject.tag == "Left")
        {
            manager.stampaccelerator = true;

        }
    }

    private void OnTriggerExit(Collider other)
    { 
        if(other.gameObject.tag=="Left")
        {

            manager.stampaccelerator = false;

        }
    }


}
