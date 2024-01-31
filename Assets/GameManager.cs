using _4040.Scripts; 
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public enum ModuleStatus
{
    Completed,
    Failed
}

public class GameManager : MonoBehaviour
{
    public ModuleStatus moduleStatus;
    public static GameManager Instance;
  public string name,empId;

    public TMP_Text userNameText;
    public TMP_Text empIdText;

    public string timeTake;

    public int _totalScore = 100;

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
        
        name = "default user";
        empId =  "873475802";
        userNameText.text = name;
        empIdText.text = empId;
    }

    public void UpdateUserName(string value)
    {
        name = value;
        userNameText.text = value;
    }

    public void UpdateEmpID(string value)
    {
        empId = value;
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

    public void OnGameOver()
    {
        StopStopWatch();
        ResultUIManager.Instance.FillData(name, empId, moduleStatus.ToString(), timeTake,_totalScore.ToString());
    }

    public bool awareness;
    public void AwarenessFailed()
    {
        if (!awareness)
        {
            awareness = true;
            _totalScore -= 20;
        }
    }

    private void Update()
    {
        if (stopWatch.ElapsedSeconds > 0)
        {
            timeTake = stopWatch.ElapsedTimeFormatted;
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
        }
    }
}