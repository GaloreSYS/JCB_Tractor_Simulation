using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using Valve.VR;

public class ViveInput : MonoBehaviour
{
    private InputAction grabAction;
    private InputAction triggerAction;

    private void Awake()
    {
        grabAction = new InputAction(binding: "/action/default/in/Grab Grip", type: InputActionType.Button);
        triggerAction = new InputAction(binding: "/action/default/in/Trigger", type: InputActionType.Button);

        grabAction.performed += context => GrabButtonPressed();
        triggerAction.performed += context => TriggerButtonPressed();
    }
    private void OnEnable()
    {
        grabAction.Enable();
        triggerAction.Enable();
    }

    private void OnDisable()
    {
        grabAction.Disable();
        triggerAction.Disable();
    }
    private void GrabButtonPressed()
    {
        Debug.Log("1Grab Button Pressed");
    }
    private void TriggerButtonPressed()
    {
        Debug.Log("2Trigger Button Pressed");
    }

}
