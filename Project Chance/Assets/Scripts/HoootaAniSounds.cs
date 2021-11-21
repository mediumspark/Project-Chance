using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoootaAniSounds : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AkSoundEngine.PostEvent("Play_Air_Enemy_Flying", this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HoootaAttack()
    {
        AkSoundEngine.PostEvent("Play_Air_Enemy_Ranged_Attack", this.gameObject);
    }
}
