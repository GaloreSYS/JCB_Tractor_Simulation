using System.Collections;
using System.Collections.Generic;
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
        spawnAt = 100 - 5;
    }
    void Update()
    {
        float marginValue = (float)mowingManager.totalMarker * mowingManager.marginError;
        float normalizedValue = ((mowingManager.markersPos.Count - marginValue) / (float)(mowingManager.totalMarker - marginValue));
        normalizedValue = Mathf.Clamp01( normalizedValue - Mathf.Lerp(0, mowingManager.marginError, 1-normalizedValue));
        percentageText.text = Mathf.RoundToInt(normalizedValue * 100f).ToString() + " %";
        MowingProgress = Mathf.RoundToInt(normalizedValue * 100f);

        if (convyer != null)
        {
            Debug.Log(Mathf.RoundToInt(normalizedValue * 100f) +" "+spawnAt + " Found Conveyer" + (Mathf.RoundToInt(normalizedValue * 100f) < spawnAt));
            if (Mathf.RoundToInt(normalizedValue * 100f) < spawnAt)
                {
                    Debug.Log("Spawn Grass Bundle");
                    convyer.SpawnGrassBundle();
                    spawnAt -= spawnInterval;
                }
             
            return;
        }
    }
    
}
