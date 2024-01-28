
using TMPro;
using UnityEngine;

public enum ModuleStatus
{
    Completed,
    Failed
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public (string name, string empId) UserData = new ();

    public TMP_Text userNameText;
    public TMP_Text empIdText;

    public string timeTake;
    
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

    public StopWatch stopWatch = new StopWatch();

    public void StartStopWatch()
    {
        stopWatch.Start();
    }
    
    public void StopStopWatch()
    {
        stopWatch.Stop();
    }
    private void Update()
    {
        if (stopWatch.ElapsedSeconds > 0)
        {
            timeTake = stopWatch.ElapsedTimeFormatted;
        }
    }
}