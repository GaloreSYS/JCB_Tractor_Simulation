using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public Button Tlb;
    public Button Tractor;



    // Start is called before the first frame update
    void Start()
    {
        Tractor.onClick.AddListener(() =>
        {
            StartCoroutine(LoadYourAsyncScene(1));
        });

        Tlb.onClick.AddListener(() =>
        {
            StartCoroutine(LoadYourAsyncScene(2));
        });

    }

    IEnumerator LoadYourAsyncScene(int index)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(index);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
