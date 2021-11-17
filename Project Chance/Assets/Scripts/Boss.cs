using System.Collections;
using UnityEngine;


[RequireComponent(typeof(DistanceToPlayer))]
public abstract class Boss : Character
{
    [SerializeField]
    protected bool battlestart;
    [SerializeField]
    protected bool startAttack;

    protected Weapon PrizeWeapon; 

    protected Vector3 AttackLocation;
        

    protected override void FixedUpdate()
    {
        if (battlestart && startAttack)
        {
            if (CurrentHealth > MaxHealth / 2)
            {
                StartCoroutine(Phase1Attack()); 
            }// phase 1
            else if (CurrentHealth < MaxHealth / 2 && CurrentHealth > MaxHealth * 0.1f)
            {
                StartCoroutine(Phase2Attack());
            }// phase 2
            else if (CurrentHealth < MaxHealth * 0.1f)
            {
                StartCoroutine(Phase3Attack()); 
            }
        }
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        FindObjectOfType<Player>().addWeapon(PrizeWeapon); 
    }

    public void BeginBossFight()
    {
        battlestart = true;
        startAttack = true; 
    }

    protected abstract IEnumerator Phase1Attack();
    protected abstract IEnumerator Phase2Attack();
    protected abstract IEnumerator Phase3Attack();
}
