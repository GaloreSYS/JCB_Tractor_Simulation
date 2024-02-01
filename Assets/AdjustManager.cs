using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustManager : MonoBehaviour
{
    public float speed = 10f;
    
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveY = 0;
        if (Input.GetKey(KeyCode.Q))
        {
            moveY = -speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            moveY = speed * Time.deltaTime;
        }
        float moveZ = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
        transform.Translate(new Vector3(moveX, moveY, moveZ));
    }
}
