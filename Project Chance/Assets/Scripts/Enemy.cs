using System.Collections;
using UnityEngine;

[RequireComponent(typeof(DistanceToPlayer))]
public abstract class Enemy : Character
{
    [SerializeField]
    protected bool isRanged;
    [SerializeField]
    protected bool isAutoFire;
    protected bool CanAttack; 

    [SerializeField]
    protected float AttackRange;
    [SerializeField]
    protected float AttackCooldown; 
    protected EnemyStates CurrentState; 

    protected abstract bool InAttackRange();
    protected abstract IEnumerator EnemyAttack();
    protected abstract void Patroling();

    protected override void OnDeath()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, AttackRange); 
    }
}
