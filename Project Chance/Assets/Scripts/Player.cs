using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{   
    private PlayerControls Controls;

    //I wanted these to be viewable in the inspector to check that they work. 
    [SerializeField]
    private Weapon CurrentWeapon;     
    [SerializeField]
    private List<Weapon> Weapons;

    private bool Crouch;
    public bool FacingRight;

    public bool canMove { get; set; }
    public bool Moving => moving; 
    AnimatorMethods AniMethods; 
    
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(gameObject);
        canMove = true;

        AniMethods = GetComponent<AnimatorMethods>(); 

        MaxHealth = 100;
        CurrentHealth = MaxHealth; 

        CurrentWeapon = new Default(this, 4f, 10, Color.black);
        Weapons.Add(CurrentWeapon); 

        Controls = new PlayerControls();
        Controls.Basic.Movement.performed += Movement_performed;
        Controls.Basic.Movement.canceled += ctx => movementForce.x = 0;
        Controls.Basic.Movement.canceled += ctx => moving = false; 


        Controls.Basic.Jump.performed += Jump_performed;
        Controls.Basic.Jump.canceled += ctx => jumping = false;   

        Controls.Basic.Crouch.performed += ctx => Crouch = true;
        Controls.Basic.Crouch.canceled += ctx => Crouch = false;

        Controls.Basic.Attack.performed += ctx => CurrentWeapon.Fire(); 
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        if (!invulnerable)
        {
            Interacts.PlayerHit(colliders, gameObject, 10);
        }
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(grounded && canMove)
            StartCoroutine(Jump(0.5f));
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (canMove)
        {
            moving = true; 
            movementForce.x = obj.ReadValue<float>();
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            FacingRight = obj.ReadValue<float>() > 0;
            if (!FacingRight)
            {
                transform.eulerAngles = new Vector3(0, 180);
            }
            else {
                transform.eulerAngles = new Vector3(0, 0);
            }
        }
    }

    protected override IEnumerator Jump(float duration)
    {
        jumping = true;
        yield return new WaitForSeconds(duration);
        jumping = false; 
    }

    public override void OnTakeDamage(int damage)
    {
        //PlayAnimation for taking damage that allows player to be invulnerable for its duration
        AniMethods.SetDamageTrigger();
        base.OnTakeDamage(damage);
        StartCoroutine(InvolTimer());

        Debug.Log("Took " + damage);        
    }

    IEnumerator InvolTimer()
    {
        invulnerable = true; 
        yield return new WaitForSeconds(1.2f);
        invulnerable = false; 
    }

    private void OnEnable()
    {
        Controls.Enable(); 
    }

    private void OnDisable()
    {
        Controls.Disable();
    }

}