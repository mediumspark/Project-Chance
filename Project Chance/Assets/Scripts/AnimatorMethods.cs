using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorMethods : MonoBehaviour
{
    Animator Ani;

    public WeaponSelected CurrentWeapon; 

    private void Awake()
    {
        Ani = GetComponent<Animator>();
    }

    public void SetDamageTrigger()
    {
        if(!Ani.GetCurrentAnimatorStateInfo(0).IsName("TakeDamage"))
            Ani.SetTrigger("Damaged");
    }

    public void SetRun(bool moving)
    {
        Ani.SetBool("Run", moving);
    }

    public void SetChargeTrigger()
    {
        if (!Ani.GetCurrentAnimatorStateInfo(0).IsName("Charging"))
            Ani.SetTrigger("ChargeAttack");
    }

    public void SetGrounded(bool Grounded)
    {
        Ani.SetBool("Grounded", Grounded);
    }

    public void SetHealing(bool Healing)
    {
        Ani.SetBool("Healing", Healing);
    }

    //Sound Scripts

    private void PlayerFootstep()
    {
        AkSoundEngine.PostEvent("Play_Footsteps", this.gameObject);
    }

    private void PlayerGroundSlide()
    {
        AkSoundEngine.PostEvent("Play_Player_GroundSlide", this.gameObject);
    }

    private void PlayerAttack()
    {
        AkSoundEngine.PostEvent("Play_Player_Attack", this.gameObject);
    }

    private void PlayerDamaged()
    {
        AkSoundEngine.PostEvent("Play_Player_Damaged", this.gameObject);
    }

    private void PlayerHeal()
    {
        AkSoundEngine.PostEvent("Play_Player_Heal", this.gameObject);
    }

}
