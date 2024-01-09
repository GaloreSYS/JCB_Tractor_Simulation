using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JCBStandsLeftAndRight : MonoBehaviour
{
    public static JCBStandsLeftAndRight Instance;
    public Animator AnimArms;

    public bool enableLeftDown, enableLeftUp, enablerightLegdown, enableRightlegup, CheckEngine;
    public float ValueArmsLeft, ValueArmsRight;

    public ArmDataJCB _ArmDataJCB;

    public bool LeftSupportOn, RightSupportOn;
    public enum SelectedLeg
    {
        Left,
        Right
    }

    public SelectedLeg _selectedLeg;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ValueArmsLeft = -1;
        ValueArmsRight = -1;
    }
    public void Update()
    {
        CheckEngine = _ArmDataJCB.CheckEngine;

        if(CheckEngine == true)
        {
            enableLeftDown = _ArmDataJCB.EnableLeftLeg;
            enableLeftUp = _ArmDataJCB.DisableLeftLeg;

            enablerightLegdown = _ArmDataJCB.EnableRightLeg;
            enableRightlegup = _ArmDataJCB.DisableRightLeg;

            if (_selectedLeg == SelectedLeg.Left)
            {

                if (enableLeftDown == true)
                {
                    if (ValueArmsLeft >= -0.95)
                    {
                        ValueArmsLeft -= Time.deltaTime * _ArmDataJCB.LeftLeg;
                        enableLeftUp = false;
                    }
                    else
                    {
                        enableLeftDown = false;
                        _ArmDataJCB.EnableLeftLeg = false;
                        LeftSupportOn = false;
                        FF_Digger.Instance.rightLegOn = false;
                    }
                }


                if (enableLeftUp == true)
                {
                    if (ValueArmsLeft <= 0.95)
                    {
                        ValueArmsLeft += Time.deltaTime * _ArmDataJCB.LeftLeg;
                        enableLeftDown = false;
                    }
                    else
                    {
                        enableLeftUp = false;
                        _ArmDataJCB.DisableLeftLeg = false;
                        LeftSupportOn = true;
                        FF_Digger.Instance.leftLegOn = true;
                    }
                }


            }


            if (_selectedLeg == SelectedLeg.Right)
            {

                if (enablerightLegdown == true)
                {
                    if (ValueArmsRight >= -0.95f)
                    {
                        ValueArmsRight -= Time.deltaTime * _ArmDataJCB.RightLeg;
                        enableRightlegup = false;
                    }
                    else
                    {
                        enablerightLegdown = false;
                        _ArmDataJCB.EnableRightLeg = false;
                        RightSupportOn = false;
                        FF_Digger.Instance.rightLegOn = false;
                    }
                }


                if (enableRightlegup == true)
                {
                    if (ValueArmsRight <= 0.95)
                    {
                        ValueArmsRight += Time.deltaTime * _ArmDataJCB.RightLeg;
                        enablerightLegdown = false;
                    }
                    else
                    {
                        enableRightlegup = false;
                        _ArmDataJCB.DisableRightLeg = false;
                        RightSupportOn = true;
                        FF_Digger.Instance.rightLegOn = true;
                    }
                }



            }



            AnimArms.SetFloat("UPL", ValueArmsLeft);
            AnimArms.SetFloat("UPR", ValueArmsRight);
        }

        
    }
}
