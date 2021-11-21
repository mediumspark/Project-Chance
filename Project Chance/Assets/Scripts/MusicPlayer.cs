using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_SoundTrack", this.gameObject);
        AkSoundEngine.PostEvent("Play_Ambience", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
