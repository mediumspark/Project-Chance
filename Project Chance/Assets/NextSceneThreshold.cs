using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextSceneThreshold : Threshold
{
    [SerializeField]
    private string SceneName; 
    public override void OnHittingThreshold()
    {
        GameManager.instance.LoadScene(SceneName); 
    }
}
