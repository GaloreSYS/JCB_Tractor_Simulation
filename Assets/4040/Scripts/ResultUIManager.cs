using System;
using TMPro;
using UnityEngine;

namespace _4040.Scripts
{
    public class ResultUIManager : MonoBehaviour
    {
        public static ResultUIManager Instance;
        public TMP_Text userName;
        public TMP_Text empId;
        public TMP_Text moduleStatus;
        public TMP_Text timeTake;
        public TMP_Text totalScore;

        private void Start()
        {
            Instance = this;
            GameManager.Instance.OnGameOver();
        }

        public void FillData(string uName, string id, string status, string timeTaken, string score)
        {
            userName.text = uName;
            empId.text = id;
            moduleStatus.text = status;
            timeTake.text = timeTaken;
            totalScore.text = score;
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}