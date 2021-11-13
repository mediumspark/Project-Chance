using System.Collections;
using UnityEngine;

public abstract class Enemy : Character
{
    protected bool isRanged; 

    protected abstract bool InAttackRange();
    protected abstract void Attacking();
    protected abstract void Patroling();
}

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    [SerializeField]
    protected bool GravityOn;
    protected CharacterController CharacterController;
    protected Vector2 movementForce;
    public Vector2 MovementForce { get => movementForce; set => movementForce = value; }

    
    [SerializeField]
    protected int Speed;
    protected bool grounded;
    protected bool invulnerable;
    protected bool moving;
    protected bool jumping;
    protected int MaxHealth, CurrentHealth, Attack;

    [SerializeField]
    protected GameObject GroundedPlacer;
    protected float GroundDistance = 0.09f;
    [SerializeField]
    LayerMask GroundLayer; 

    [SerializeField]
    protected float gravity; 
    public float Gravity
    {
        get => gravity; set => gravity = value; 
    }
    [SerializeField]
    protected float jumpForce; 
    public float JumpForce
    {
        get => jumpForce; set => jumpForce = value; 
    }
    protected virtual IEnumerator Jump(float duration)
    {
        yield return null; 
    }

    protected virtual void Awake()
    {
        CharacterController = GetComponent<CharacterController>();
    }

    protected virtual void FixedUpdate()
    {
        if (GravityOn)
        {
            if (!grounded && !jumping)
            {
                movementForce.y = -gravity;
            } else if (jumping)
            {
                movementForce.y = jumpForce;
            }
            else
            {
                movementForce.y = 0;
            }
        }

        grounded = Physics.CheckSphere(GroundedPlacer.transform.position, GroundDistance, GroundLayer);
        Debug.Log("isGrounded: " + grounded);
        CharacterController.Move(movementForce * Speed * Time.deltaTime);
    }

    public virtual void OnTakeDamage(int damage)
    {
        CurrentHealth -= damage; 
        if(CurrentHealth <= 0)
        {
            OnDeath(); 
        }
    }

    public void InstaDeath()
    {
        OnDeath(); 
    }

    protected virtual void OnDeath()
    {
    }

    protected virtual void OnStun()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundedPlacer.transform.position, GroundDistance);
    }
}
