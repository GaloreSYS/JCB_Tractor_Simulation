using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTheScene : MonoBehaviour
{
    [Header ("Example 0 to 9")]
    public int SceneNumber;

    public void OnClickLoadTheScene(int value)
    {
        
        SceneNumber = value;
        SceneManager.LoadScene(SceneNumber);
    }
    public void LoadSceneOnClick(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
