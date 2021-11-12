using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{   
    private PlayerControls Controls;

    //I wanted these to be viewable in the inspector to check that they work. 
    private Weapon CurrentWeapon;     
    private List<Weapon> Weapons = new List<Weapon>();

    private bool Healing;
    private int HealSpeed = 1; 
    private bool Crouch;
    private bool TouchingWall;
    float Wall_Gravity = 0.5f;
    float Normal_Gravity = 1.5f;

    [SerializeField]
    private GameObject WallDetectionObject; 

    public bool FacingRight;

    public bool canMove { get; set; }
    public bool Moving => moving; 
    AnimatorMethods AniMethods; 

    public bool isInvol { get => invulnerable; set => invulnerable = value; }

    private int base_speed = 4; 
    
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

        Speed = base_speed; 

        Controls = new PlayerControls();
        Controls.Basic.Movement.performed += Movement_performed;
        Controls.Basic.Movement.canceled += ctx => movementForce.x = 0;
        Controls.Basic.Movement.canceled += ctx => moving = false; 

        Controls.Basic.Jump.performed += Jump_performed;
        Controls.Basic.Jump.canceled += ctx => jumping = false;   

        Controls.Basic.Crouch.performed += ctx => Crouch = true;
        Controls.Basic.Crouch.canceled += ctx => Crouch = false;

        Controls.Basic.Heal.performed += ctx => Healing = true;
        Controls.Basic.Heal.canceled += ctx => Healing = false;

        Controls.Basic.Attack.performed += ctx => CurrentWeapon.Fire();
    }

    [SerializeField]
    private float Stamina;
    [SerializeField]
    private float MaxStamina = 100;

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(grounded && canMove)
            StartCoroutine(Jump(0.5f));

        if (TouchingWall)
            StartCoroutine(WallJump(0.5f));
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (canMove && !Crouch)
        {
            moving = true; 
            movementForce.x = obj.ReadValue<float>();
            SpriteRenderer sr = GetComponent<SpriteRenderer>();
            FacingRight = obj.ReadValue<float>() > 0;
        } 
        /*else if (Crouch)
        {
            movementForce.x = obj.ReadValue<float>() * 2.0f;
        } If we ever want to create a crouch slide or crouch dash*/ 
    }

    protected override IEnumerator Jump(float duration)
    {
        jumping = true;
        yield return new WaitForSeconds(duration);
        jumping = false; 
    }

    private IEnumerator WallJump(float duration)
    {
        Vector2 tempMovementForce = MovementForce; 
        Vector2 Jumpforce = new Vector2(0, jumpForce);
        Jumpforce.x = FacingRight ? -1.5f : 1.5f;
        FacingRight = Jumpforce.x > 0; 
        movementForce = Jumpforce;
        jumping = true;
        canMove = false; 
        yield return new WaitForSeconds(duration);
        jumping = false;
        canMove = true; 
        MovementForce = tempMovementForce; 
    }

    public override void OnTakeDamage(int damage)
    {
        //PlayAnimation for taking damage that allows player to be invulnerable for its duration
        AniMethods.SetDamageTrigger();
        base.OnTakeDamage(damage);
        StartCoroutine(InvolTimer());

        Debug.Log("Took " + damage);        
    }

    protected override void OnDeath()
    {
        GameManager.instance.LevelReload();
        Destroy(gameObject); 
    }

    IEnumerator InvolTimer()
    {
        invulnerable = true; 
        yield return new WaitForSeconds(1.2f);
        invulnerable = false; 
    }

    protected override void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        Collider[] BackgroundColliders = Physics.OverlapSphere(WallDetectionObject.transform.position, 0.5f);
        TouchingWall = Interacts.WallCling(BackgroundColliders);
        if (TouchingWall)
        {
            gravity = Wall_Gravity;
        }
        else 
        {
            gravity = Normal_Gravity;
        }

        if (!FacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0);
        }

        if (Healing)
        {
            if(CurrentHealth < MaxHealth)
            {
                CurrentHealth += HealSpeed * Time.deltaTime;
            }

            if (Stamina < MaxStamina)
            {
                Stamina += Time.deltaTime * HealSpeed;
            }
        }

        if (!invulnerable)
        {
            Interacts.PlayerHit(colliders, gameObject, 10);
        }

        base.FixedUpdate();
    }

    public void addWeapon(Weapon newWeapon)
    {
        Weapons.Add(newWeapon);
    }

    private void OnEnable()
    {
        Controls.Enable(); 
    }

    private void OnDisable()
    {
        Controls.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(GroundedPlacer.transform.position, GroundDistance);
        Gizmos.DrawWireSphere(WallDetectionObject.transform.position, 0.5f);
    }

}