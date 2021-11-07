using UnityEngine;
public class Gooba : Enemy
{
    protected override void Awake()
    {
        GravityOn = true;
        isRanged = false; 
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
    }

    protected override void OnDeath()
    {
        Destroy(gameObject); 
    }
    protected override void Attacking()
    {
        throw new System.NotImplementedException();
    }

    protected override bool InAttackRange()
    {
        throw new System.NotImplementedException();
    }

    protected override void Patroling()
    {
        throw new System.NotImplementedException();
    }
}
