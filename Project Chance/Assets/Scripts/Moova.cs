using System.Collections;
using UnityEngine;

public class Moova : Enemy
{
    private int MovementSpeed = 5;
    private bool GoOppositeDirection = false; 

    protected override void Awake()
    {
        isRanged = false;
        isAutoFire = false;
        CanAttack = false;
        MaxHealth = 5;
        CurrentHealth = MaxHealth;
        movementForce.x = MovementSpeed;
        transform.eulerAngles = MovementSpeed > 0 ? Vector2.zero : new Vector2(0, 180);

        base.Awake();
        AkSoundEngine.PostEvent("Play_Ambience_Ground_Enemy_Bigger", this.gameObject);
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override IEnumerator EnemyAttack()
    {
        throw new System.NotImplementedException();
    }//Does not attack

    protected override bool InAttackRange()
    {
        throw new System.NotImplementedException();
    }//Does not attack

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(!GoOppositeDirection)
            StartCoroutine(ChangeDirection(hit));
    }


    protected override void Patroling()
    {
        if (GoOppositeDirection)
        {
            MovementSpeed *= -1;
            transform.eulerAngles = MovementSpeed > 0 ? Vector2.zero : new Vector2(0, 180);
            movementForce.x = MovementSpeed;
        }
    }

    public IEnumerator ChangeDirection(ControllerColliderHit hit)
    {
        GoOppositeDirection = hit.normal.y < 0.5f;
        Patroling();

        yield return new WaitForSeconds(1f);

        GoOppositeDirection = false; 
    }

    //Sounds

    private void MoovaFootstep ()
    {
        AkSoundEngine.PostEvent("Play_Ground_Enemy_Footsteps", this.gameObject);
    }

    private void MoovaRangedAttack ()
    {
        AkSoundEngine.PostEvent("Play_Ground_Enemy_Ranged_Attack", this.gameObject);
    }
}
