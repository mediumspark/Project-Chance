using System.Collections;
using UnityEngine;
using System.Linq;

public class Hooota : Enemy
{
    [SerializeField]
    protected GameObject BulletSpawnPoint;

    [SerializeField]
    [Range(0, 5)]
    protected float ProjectileSpeed;

    protected override void Awake()
    {
        base.Awake();

        isRanged = true;
        isAutoFire = true;
        CanAttack = true;
        AttackCooldown = 2.5f;
        MaxHealth = 5;
        CurrentHealth = MaxHealth;
        StartCoroutine(EnemyAttack());
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
        var WallColliders = Physics.OverlapSphere(transform.position, AttackRange)
            .ToList().Where(ctx => LayerMask.LayerToName(ctx.gameObject.layer) == "Player").FirstOrDefault();

        return WallColliders != null;
    }

    protected override void Patroling()
    {
        throw new System.NotImplementedException();
        //Does not patrol
    }
}
