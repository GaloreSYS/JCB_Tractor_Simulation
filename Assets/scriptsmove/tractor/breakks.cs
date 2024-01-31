using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breakks : MonoBehaviour
{

    public ArmDataJCB brakeee;
    // Start is called before the first frame update
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
            brakeee.tractorbrakess = true;
        }
    }


}
