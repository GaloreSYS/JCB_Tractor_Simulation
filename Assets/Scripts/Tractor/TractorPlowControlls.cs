using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorPlowControlls : MonoBehaviour
{
    public Animator AnimTractorController;
    public ArmDataJCB Tractor;
    public GameObject[] boxs;
    public GameObject testground;
    public bool EnableDown, EnableUp;
    public float ValueTractor; 
    public RaycastHit hit;
    public float rayLength = 0.5f;
    public bool onGround = false;
    
    private void Start()
    {
        ValueTractor = 0;
    }
    public void Update()
    {

        EnableDown = Tractor.TractorPlowDown;
        EnableUp = Tractor.TractorPlowUP;



        if (EnableDown == true)
        {
            if (ValueTractor >= -1)
            {
                ValueTractor -= Time.deltaTime * Tractor.TractorPlow;
                EnableUp = false;

            }
        }


        if (EnableUp == true)
        {
            if (ValueTractor <= 1)
            {
                ValueTractor += Time.deltaTime * Tractor.TractorPlow;
                EnableDown = false;
            }
        }

            Tractor.valueTractor = ValueTractor;
        AnimTractorController.SetFloat("TP", ValueTractor);



        //

        Ray checkGround = new Ray(testground.transform.position, Vector3.down);

        Debug.DrawRay(testground.transform.position, Vector3.down * rayLength);
        if (EnableUp == true)
        {
            boxs[0].gameObject.SetActive(false);
            boxs[1].gameObject.SetActive(false);
            boxs[2].gameObject.SetActive(false);

        }
        if (!EnableUp)
        {
            boxs[0].gameObject.SetActive(true);
            boxs[1].gameObject.SetActive(true);
            boxs[2].gameObject.SetActive(true);

        }
        // if (Physics.Raycast(checkGround, out hit, rayLength))
        // {
        //     if (hit.collider.tag == "ground")
        //     {
        //         onGround = true;
        //
        //         boxs[0].gameObject.SetActive(true);
        //         boxs[1].gameObject.SetActive(true);
        //         boxs[2].gameObject.SetActive(true);
        //     }
        //     if (EnableUp == true)
        //     {
        //         boxs[0].gameObject.SetActive(false);
        //         boxs[1].gameObject.SetActive(false);
        //         boxs[2].gameObject.SetActive(false);
        //
        //     }
        // }

    }

}
