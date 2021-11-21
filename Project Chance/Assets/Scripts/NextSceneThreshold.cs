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
        AkSoundEngine.StopAll();
        switch (SceneName)
        {
            case "City_1":
                AkSoundEngine.SetState("Level", "City_1");
                break;

            case "City_2":
                AkSoundEngine.SetState("Level", "City_2");
                break;

            case "City_3":
                AkSoundEngine.SetState("Level","City_3");
                break;

            case "Lab":
                AkSoundEngine.SetState("Level", "Lab");
                break;

            case "Mayor Room":
                AkSoundEngine.SetState("Level","Mayor_Room");
                break;

            case "Phil Room":
                AkSoundEngine.SetState("Level", "Phil_Room");
                break;

            case "Startup":
                AkSoundEngine.SetState("Level", "Startup");
                break;

            case "House(Start)":
                AkSoundEngine.SetState("Level", "The_Hub");
                break;

            default:
                break;
        }
        GameManager.LoadScene(SceneName, spawnPoint);
    }
}