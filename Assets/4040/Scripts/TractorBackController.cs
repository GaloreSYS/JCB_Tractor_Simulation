using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBackController : MonoBehaviour
{
    [SerializeField] Animator _anim;
    [SerializeField] [Range(-1f, 1f)] float Value;
   
    void FixedUpdate()
    {
        _anim.SetFloat("SetTractorAnim", Value) ;
    }
}
