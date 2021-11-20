using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneThreshold : Threshold
{
    [SerializeField]
    private string SceneName;
    [SerializeField]
    private int spawnPoint = 0; 
    public override void OnHittingThreshold()
    {
        GameManager.LoadScene(SceneName, spawnPoint); 
    }
}
