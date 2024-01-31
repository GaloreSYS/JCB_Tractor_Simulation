using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "Terrain")
        {
            if(SpawnRocksAndPile.Instance.gameover)return;
            GameManager.Instance.moduleStatus = ModuleStatus.Failed;
            GameManager.Instance._totalScore -= 80;
            SpawnRocksAndPile.Instance.GameOver();
        }
    }
}
