using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBackController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] float Value;
    private void Start()
    {
        Value = 1;
    }
    public void GoUp()
    {
        _anim.SetBool("UpLoader", true);
    }

    public void GoDown()
    {
        _anim.SetBool("UpLoader", false);
    }
}
