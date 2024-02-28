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
        if (Input.GetKeyDown(KeyCode.W))
        {
            manager.stampaccelerator = true; 
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            manager.stampaccelerator = false; 
        }
    }

    private void OnTriggerStay(Collider other)
   
    {
      
        if (other.gameObject.tag == "Left")
        {
            Debug.Log("Pressing",gameObject);
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
