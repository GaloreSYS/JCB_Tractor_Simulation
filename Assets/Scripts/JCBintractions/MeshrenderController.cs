using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshrenderController : MonoBehaviour
{
    public static MeshrenderController instance;
    public MeshRenderer[] AllChildrenMeshRendrers;

    public bool isEnable;
    private void Awake()
    {
        instance = this;
        AllChildrenMeshRendrers = GetComponentsInChildren<MeshRenderer>();

    }


    public void Update()
    {
        foreach (MeshRenderer renderer in AllChildrenMeshRendrers)
            if (!isEnable == true)
            {
                renderer.enabled = true;
            }
            else
            {
                renderer.enabled = false;
            }
    }

    public void EnableAndDisableTheMeshRendrer()
    {
        foreach (MeshRenderer renderer in AllChildrenMeshRendrers)
        {
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            else
            {
                renderer.enabled = true;
            }
        }

    }
}
