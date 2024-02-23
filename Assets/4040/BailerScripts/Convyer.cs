using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convyer : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float Speed;
    [SerializeField] GameObject PrefabHere, Loactionofspawn;
    void Start()
    {
        InvokeRepeating("Spawnables", 1, 20);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ConveyerMethod();
    }


    public void ConveyerMethod()
    {
        Vector3 position = rb.position;
        rb.position += Vector3.back * Speed * Time.fixedDeltaTime;
        rb.MovePosition(position);
    }

    public void Spawnables()
    {
        Instantiate(PrefabHere, Loactionofspawn.transform.position, Quaternion.identity);
    }
}
