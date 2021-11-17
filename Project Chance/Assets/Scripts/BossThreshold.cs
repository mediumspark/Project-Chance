using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public abstract class Threshold : MonoBehaviour 
{
    public abstract void OnHittingThreshold();
}

public class BossThreshold : Threshold
{
    public PlayableDirector BossOpening;

    public override void OnHittingThreshold()
    {
        BossOpening.gameObject.SetActive(true); 
    }

    public void BeginBossFight()
    {
        Boss currentboss = FindObjectOfType<Boss>();
        currentboss.BeginBossFight(); 
    }

}
