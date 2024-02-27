using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitFiller : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Filler"))
        {
            
        }
    }
}
