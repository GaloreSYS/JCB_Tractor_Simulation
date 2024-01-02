using System.Collections;
using System.Collections.Generic;
using Digger.Modules.Core.Sources;
using Digger.Modules.Runtime.Sources;
using UnityEngine;
using UnityEngine.Serialization;

public class FF_Digger : MonoBehaviour
{
    [Header("Async parameters")]
    [Tooltip("Enable to edit the terrain asynchronously and avoid impacting the frame rate too much.")]
    public bool editAsynchronously = true;

    [Header("Modification parameters")] public BrushType brush = BrushType.Sphere;
    public ActionType action = ActionType.Dig;
    [Range(0, 7)] public int textureIndex;
    [Range(0.5f, 10f)] public float size = 4f;
    [Range(0f, 1f)] public float opacity = 0.5f;

    private DiggerMasterRuntime diggerMasterRuntime;

    [FormerlySerializedAs("cubde")] public Transform diggerObject;
    private void Start()
    {
        diggerMasterRuntime = FindObjectOfType<DiggerMasterRuntime>();
        if (!diggerMasterRuntime)
        {
            enabled = false;
            Debug.LogWarning(
                "DiggerRuntimeUsageExample component requires DiggerMasterRuntime component to be setup in the scene. DiggerRuntimeUsageExample will be disabled.");
        }
    }
    private void Update()
    {
                if (editAsynchronously)
                {
                    diggerMasterRuntime.ModifyAsyncBuffured(diggerObject.position, brush, action, textureIndex, opacity,
                        size);
                }
                else
                {
                    diggerMasterRuntime.Modify(diggerObject.position, brush, action, textureIndex, opacity, size);
                }
    }
}
