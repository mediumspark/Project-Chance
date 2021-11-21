using System.Collections;
using UnityEngine;
using System.Linq;

public class Gooba : Enemy
{
    [SerializeField]
    protected GameObject BulletSpawnPoint;

    [SerializeField]
    [Range(0, 15)]
    protected float ProjectileSpeed;

    protected override void Awake()
    {
        isRanged = true;
        isAutoFire = true;
        CanAttack = true;
        AttackCooldown = 1.0f;
        MaxHealth = 5;
        CurrentHealth = MaxHealth;
        StartCoroutine(EnemyAttack());
        base.Awake();
    }

    public override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
        Debug.Log("Taken Damage");
    }


    protected override IEnumerator EnemyAttack()
    {
        GameObject go = (GameObject)Resources.Load("Prefabs/Enemy Bullet");
        Bullet bul = Instantiate(go, BulletSpawnPoint.transform).AddComponent<Bullet>();
        bul.BulletSpeed = ProjectileSpeed;
        bul.transform.parent = null;

        yield return new WaitForSeconds(AttackCooldown);
        if (bul != null)
            Destroy(bul.gameObject);
        if (isAutoFire)
        {
            StartCoroutine(EnemyAttack());
        }
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