using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;

public class HandAnimatorController : MonoBehaviour
{
    [SerializeField] private InputActionReference triggerAction;
    [SerializeField] private InputActionReference gripAction;

    private Animator anim;

    [SerializeField] private XRController xrController;

    private void Start()
    {
        triggerAction.action.Enable();
        gripAction.action.Enable();
        //anim = GetComponent<Animator>();
        //xrController = GetComponent<XRController>();

    }

    private void Update()
    {
        float triggerValue = triggerAction.action.ReadValue<float>();
        float gripValue = triggerAction.action.ReadValue<float>();

        //var rot = triggerAction.action.ReadValue<Vector2>();

        //Debug.Log($"ControllerRotation: {triggerValue} {gripValue} ");

        //anim.SetFloat("Trigger", triggerValue);
        //anim.SetFloat("Grip", gripValue);

    }

}
