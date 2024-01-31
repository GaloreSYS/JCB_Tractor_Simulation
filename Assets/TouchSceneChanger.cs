using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchSceneChanger : MonoBehaviour
{
    public int sceneIndex;
    public FadeEffect fadeEffect;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GoToSimulator();
        }
    }

    [Button]
    public void GoToSimulator()
    {
        StartCoroutine(changeScene());
    }
    
    public void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
   
       StartCoroutine(changeScene());
    }

    public IEnumerator changeScene()
    {
        fadeEffect.FadeOut();
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadSceneAsync(sceneIndex);
    }
}
