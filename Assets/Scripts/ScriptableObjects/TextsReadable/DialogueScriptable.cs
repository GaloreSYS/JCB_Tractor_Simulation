using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogeFlow",menuName = "DialogeHolder",order = 0)]
public class DialogueScriptable : ScriptableObject
{

    [TextArea(4, 30)]
    [Header("Put Your Text Here")]
    public string ScriptWords;
}
