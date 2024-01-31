using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class DialogeController : MonoBehaviour
{
    public static DialogeController instance;
    public DialogueScriptable scriptable;
    public TMP_Text text;
    public bool Activatext;

    private void Start()
    {
        
        instance = this;
        
    }
    void FixedUpdate()
    {
        
        if (Activatext == true)
        {
            text.text = scriptable.ScriptWords.ToString();
        }
        else
        {
            text.text = "";
        }
    }

   

}
