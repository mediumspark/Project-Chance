using System.Collections;
using UnityEngine;

public enum EnemyStates { Idle, Patroling, Attacking, Alerted}

[RequireComponent(typeof(CharacterController))]
public class Character : MonoBehaviour
{
    protected CharacterController CharacterController;
    protected Vector2 movementForce;
    public Vector2 MovementForce { get => movementForce; set => movementForce = value; }

    protected float Speed = 1;
    protected bool grounded;
    protected bool invulnerable;
    protected bool moving;
    protected bool jumping;
    protected float MaxHealth, CurrentHealth, Attack;

    [SerializeField]
    protected GameObject GroundedPlacer;
    protected float GroundDistance = 0.09f;
    [SerializeField]
    LayerMask GroundLayer;
    protected Vector2 tempMovementForce;


    [SerializeField]
    protected bool GravityOn;
    public bool isGravityOn
    {
        get => GravityOn; set => GravityOn = value; 
    }
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

    public virtual IEnumerator Jump(float duration)
    {
        jumping = true;
        movementForce.y = jumpForce;
        yield return new WaitForSeconds(duration);
        jumping = false;
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
            }
            else if(grounded && !jumping)
            {
                movementForce.y = 0;
            }                        
        }

        grounded = Physics.CheckBox(GroundedPlacer.transform.position, new Vector3(.5f, GroundDistance), Quaternion.identity, GroundLayer);
        CharacterController.Move(movementForce * Speed * Time.deltaTime);
        tempMovementForce = movementForce; 
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
}
