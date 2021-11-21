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
                AkSoundEngine.PostEvent("Play_Music_Streets_Theme", this.gameObject);
                AkSoundEngine.PostEvent("Play_Ambience_Streets", this.gameObject);
                break;

            case "City_2":
                AkSoundEngine.PostEvent("Play_Music_Rooftops_Theme", this.gameObject);
                AkSoundEngine.PostEvent("Play_Ambience_Rooftops", this.gameObject);
                break;

            case "City_3":
                AkSoundEngine.PostEvent("Play_Music_TheWildSide_Theme", this.gameObject);
                AkSoundEngine.PostEvent("Play_Ambience_Streets", this.gameObject);
                break;

            case "Lab":
                AkSoundEngine.PostEvent("Play_Music_OfficeSpace_Theme", this.gameObject);
                AkSoundEngine.PostEvent("Play_Ambience_Office", this.gameObject);
                break;

            case "Mayor Room":
                AkSoundEngine.PostEvent("Play_music_Mayor_Theme", this.gameObject);
                AkSoundEngine.PostEvent("Play_Ambience_HotelCaput", this.gameObject);
                break;

            case "Phil Room":
                AkSoundEngine.PostEvent("Play_Music_Philanthropist_Theme", this.gameObject);
                break;

            case "Startup":
                AkSoundEngine.PostEvent("Play_Player_Heal", this.gameObject);
                break;

            default:
                break;
        }
        GameManager.LoadScene(SceneName, spawnPoint);
    }
}