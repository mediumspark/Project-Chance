using System.Collections;
using UnityEngine;
using System.Linq;

public class Gooba : Enemy
{
    protected override void Awake()
    {
        isRanged = false;
        isAutoFire = false;
        CanAttack = true; 
        AttackCooldown = 5.0f;
        MaxHealth = 5;
        CurrentHealth = MaxHealth; 
        base.Awake();
    }

    public override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
        Debug.Log("Taken Damage");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        switch (CurrentState)
        {
            case EnemyStates.Attacking:
                StartCoroutine(EnemyAttack());
                break;
            case EnemyStates.Alerted:
                transform.eulerAngles = transform.position.x - FindObjectOfType<Player>().transform.position.x < 0
                    ? Vector3.zero : new Vector3(0, 180);
                if (InAttackRange())
                {
                    CurrentState = EnemyStates.Attacking;
                }
                break;
            case EnemyStates.Idle:
                if (InAttackRange())
                {
                    CurrentState = EnemyStates.Alerted;
                }
                Vector2 speedholer = movementForce;
                movementForce = Vector2.zero;
                break;

            case EnemyStates.Patroling:
                if (InAttackRange())
                {
                    CurrentState = EnemyStates.Alerted;
                }
                break;

            default:
                CurrentState = EnemyStates.Idle;
                break; 
        }
        
    }

    protected override IEnumerator EnemyAttack()
    {
        if (CanAttack)
        {
            Debug.Log("Attack from " + transform.name);
            CanAttack = false; 
        }
        yield return new WaitForSecondsRealtime(AttackCooldown);
        Debug.Log(transform.name + " can attack again");
        CanAttack = true;
        CurrentState = EnemyStates.Alerted; 
    }

    protected override bool InAttackRange()
    {
        var InRange = Physics.OverlapSphere(transform.position, AttackRange).
            ToList().Where(ctx => LayerMask.LayerToName(ctx.gameObject.layer) == "Player").FirstOrDefault();

        return InRange != null; 
    }

    protected override void Patroling()
    {
        throw new System.NotImplementedException();
        //Does not patrol
    }
}