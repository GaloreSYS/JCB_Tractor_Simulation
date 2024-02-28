
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BF_MowingUI : MonoBehaviour
{
    public float MowingProgress = 100f;

    public Text percentageText;
    public BF_MowingManager mowingManager;
    public int spawnInterval = 5;
    private int spawnAt;
    public Convyer convyer;

    private void Start()
    {
        if (GameManager.Instance != null)
        {
            if (convyer == null)
                GameManager.Instance.moduleName = "Plowing(Tractor)";
            else
                GameManager.Instance.moduleName = "Baeler(Tractor)";
            
            GameManager.Instance.StartStopWatch();
        }

        spawnAt = 100 - 5;
    }

    void Update()
    {
        float marginValue = (float)mowingManager.totalMarker * mowingManager.marginError;
        float normalizedValue = ((mowingManager.markersPos.Count - marginValue) /
                                 (float)(mowingManager.totalMarker - marginValue));
        normalizedValue =
            Mathf.Clamp01(normalizedValue - Mathf.Lerp(0, mowingManager.marginError, 1 - normalizedValue));
        MowingProgress = (Mathf.RoundToInt(normalizedValue * 100f)) ;
        MowingProgress = 100 - MowingProgress;
        MowingProgress = MowingProgress * 2;
        percentageText.text = MowingProgress .ToString(CultureInfo.InvariantCulture) + " %";


        if (convyer != null)
        {
            if (Mathf.RoundToInt(normalizedValue * 100f) < spawnAt)
            {
                Debug.Log("Spawn Grass Bundle");
                convyer.SpawnGrassBundle();
                spawnAt -= spawnInterval;
            }
            if (MowingProgress > 90 && !gameover)
            {
                
                GameOver(ModuleStatus.Completed);
            }

            if (gameover)
            {
                percentageText.text = "Completed";
            }
            return;
        }

        if (MowingProgress > 90 && !gameover)
        {
            GameOver(ModuleStatus.Completed);
        }
    }

    public FadeEffect fadeEffect;
    public bool gameover;
    public AudioClip gameOverAudio;
    public AudioClip gameOverFailedAudio;
    public AudioSource gameOverSource;

    public void GameOver(ModuleStatus moduleStatus)
    {
       
        gameover = true;
        fadeEffect.fadeDuration = 7;

        if (moduleStatus == ModuleStatus.Failed)
        {
            gameOverSource.PlayOneShot(gameOverFailedAudio);
        }
        else
        {
            gameOverSource.PlayOneShot(gameOverAudio);
        }
        if(GameManager.Instance!=null)
        {
            GameManager.Instance.moduleStatus = moduleStatus;
            GameManager.Instance.StopStopWatch();
        }
        fadeEffect.FadeOut();
        Invoke(nameof(GoToMainMenu), 8f);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Results");
    }
}