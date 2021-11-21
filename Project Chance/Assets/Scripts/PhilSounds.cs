using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhilSounds : MonoBehaviour
{

    public void PhilAttack()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Attack", this.gameObject);
    }

    public void PhilClone()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Clone", this.gameObject);
    }

    public void PhilDamaged()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Damaged", this.gameObject);
    }

    public void PhilFootsteps()
    {
        AkSoundEngine.PostEvent("Play_Philanthropist_Footsteps", this.gameObject);
    }
}
