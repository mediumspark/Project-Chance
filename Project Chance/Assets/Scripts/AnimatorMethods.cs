using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorMethods : MonoBehaviour
{
    Animator Ani;

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
}
