using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Pedals
{
    Accelerator,
    Brake
}
public class Tractor_Pedals_ColTest : MonoBehaviour
{
    public Pedals PedalType;
    public Tractor_Engine_New TCT;
    public bool IspedalActive;
    // Start is called before the first frame update
    void Start()
    {
        IspedalActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if(IspedalActive)
        {
            if (PedalType == Pedals.Accelerator)
            {
                TCT.AcceleratePedal();
            }
            if (PedalType == Pedals.Brake)
            {
                TCT.BrakePedal();
            }
        }
        else if (!IspedalActive)
        {
            if (PedalType == Pedals.Accelerator)
            {
                TCT.StopVehicle();
            }
            if (PedalType == Pedals.Brake)
            {
                TCT.ZeroBrake();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name != null)
        {
            
            IspedalActive = true;
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name != null)
        {
            
            IspedalActive = false;
        }
        
    }
}
