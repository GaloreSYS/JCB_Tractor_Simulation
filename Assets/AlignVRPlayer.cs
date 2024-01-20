using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignVRPlayer : MonoBehaviour
{
    [SerializeField]
    Transform vrPlayer;

    // Update is called once per frame
    void Update()
    {
        vrPlayer.SetPositionAndRotation(new Vector3(transform.position.x, vrPlayer.position.y, transform.position.z), transform.rotation);
    }
}
