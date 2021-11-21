using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    Player player;
    bool MusicPause = false;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        AkSoundEngine.PostEvent("Play_SoundTrack", this.gameObject);
        AkSoundEngine.PostEvent("Play_Ambience", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Healing)
        {
            if (!MusicPause)
            {
                HealingMusicPause();
            }   
        }
        else if (MusicPause)
        {
            HealingMusicResume();
            MusicPause = false;
        }
    }

    public void HealingMusicPause()
    {
        AkSoundEngine.PostEvent("Stop_Music", this.gameObject);
        MusicPause = true;
    }

    public void HealingMusicResume()
    {
        AkSoundEngine.PostEvent("Resume_Music", this.gameObject);
        MusicPause = false;
    }
}
