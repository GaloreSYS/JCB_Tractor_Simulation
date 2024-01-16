using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [FormerlySerializedAs("userData")] public (string name, string empId) UserData = new ();

    public TMP_Text userNameText;
    public TMP_Text empIdText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        userNameText.text = "default user";
        empIdText.text = "emp id: " + "873475802";
    }

    public void UpdateUserName(string value)
    {
        UserData.name = value;
        userNameText.text = value;
    }

    public void UpdateEmpID(string value)
    {
        UserData.empId = value;
        empIdText.text = "emp id: " + value;
    }
}