using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBStandsLeftAndRight : MonoBehaviour
{
    public Animator AnimArms;

    public bool enableLeftDown, enableLeftUp, enablerightLegdown, enableRightlegup;
    public float ValueArmsLeft, ValueArmsRight;

    public ArmDataJCB _ArmDataJCB;
    public enum SelectedLeg
    {
        Left,
        Right
    }

    public SelectedLeg _selectedLeg;

    private void Start()
    {
        ValueArmsLeft = -1;
        ValueArmsRight = -1;
    }
    public void Update()
    {

        enableLeftDown = _ArmDataJCB.EnableLeftLeg;
        enableLeftUp = _ArmDataJCB.DisableLeftLeg;
        
        enablerightLegdown = _ArmDataJCB.EnableRightLeg;
        enableRightlegup = _ArmDataJCB.DisableRightLeg;

        if(_selectedLeg == SelectedLeg.Left)
        {

            if (enableLeftDown == true)
            {
                if (ValueArmsLeft >= -1)
                {
                    ValueArmsLeft -= Time.deltaTime;
                    enableLeftUp = false;
                }
            }


            if (enableLeftUp == true)
            {
                if (ValueArmsLeft <= 1)
                {
                    ValueArmsLeft += Time.deltaTime;
                    enableLeftDown = false;
                }
            }


        }


        if (_selectedLeg == SelectedLeg.Right)
        {

            if (enablerightLegdown == true)
            {
                if (ValueArmsRight >= -1)
                {
                    ValueArmsRight -= Time.deltaTime;
                    enableRightlegup = false;
                }
            }


            if (enableRightlegup == true)
            {
                if (ValueArmsRight <= 1)
                {
                    ValueArmsRight += Time.deltaTime;
                    enablerightLegdown = false;
                }
            }


            
        }



        AnimArms.SetFloat("UPL", ValueArmsLeft);
        AnimArms.SetFloat("UPR", ValueArmsRight);
    }
}
