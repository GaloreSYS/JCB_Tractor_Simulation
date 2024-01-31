using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrasnsitionManger : MonoBehaviour
{
    public FadeEffect fadeEffect;

    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        fadeEffect.FadeOut();
        yield return new WaitForSeconds(fadeEffect.fadeDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
