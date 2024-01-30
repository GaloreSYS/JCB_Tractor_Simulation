using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlignVRPlayer : MonoBehaviour
{
    [SerializeField] Transform vrPlayer;

    public bool isAligning;

    public Vector3 offset;
    public void StopAlign()
    {
        isAligning = !isAligning;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StopAlign();    
        }

        if (isAligning)
            vrPlayer.SetPositionAndRotation(
                new Vector3(transform.position.x, vrPlayer.position.y, transform.position.z)+offset, transform.rotation);
    }
}