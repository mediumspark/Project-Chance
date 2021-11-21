using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Player : Character
{   
    public static Vector3 Position;

    private PlayerControls Controls;

    //I wanted these to be viewable in the inspector to check that they work.
    private WeaponHandler WH = new WeaponHandler();

    private bool Healing;
    private int HealSpeed = 10;
    private bool TouchingWall;
    float Wall_Gravity = 0.5f;
    float Normal_Gravity = 1.5f;

    public Slider healthBar, staminaBar;

    public float currentHealth { get => CurrentHealth; set => CurrentHealth = value;  }

    [SerializeField]
    private GameObject WallDetectionObject;

    public bool FacingRight;

    public bool canMove { get; set; }
    public bool Moving => moving;
    AnimatorMethods AniMethods;

    public bool isInvol { get => invulnerable; set => invulnerable = value; }
    public bool isGrounded { get => grounded; }

    private int base_speed = 4;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        canMove = true;
        gravity = Normal_Gravity;

        AniMethods = GetComponent<AnimatorMethods>();

        MaxHealth = 100;
        CurrentHealth = MaxHealth;

        Speed = base_speed;

        WH.Add(new Default(this, 4f, 10));
        WH.SetCurrentWeapon(0);

        healthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        staminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();

        #region Inputs
        Controls = new PlayerControls();

        Controls.Basic.Movement.performed += Movement_performed;
        Controls.Basic.Movement.canceled += ctx => Stop(); 

        Controls.Basic.Jump.performed += Jump_performed;
        Controls.Basic.Jump.canceled += ctx => jumping = false;
        Controls.Basic.Jump.canceled += ctx => WallJumping = false;

        Controls.Basic.Heal.performed += ctx => Healing = true;
        Controls.Basic.Heal.canceled += ctx => Healing = false;
        Controls.Basic.Heal.canceled += ctx => AkSoundEngine.PostEvent("Stop_Player_Heal", this.gameObject);

        Controls.Basic.Attack.performed += Attack_performed;

        Controls.Basic.WeaponCycle.performed += ctx => WH.WeaponSwap(ctx.ReadValue<float>());

        #endregion
    }

    [SerializeField]
    private float Stamina;
    public float CurrentStamina { get => Stamina; set => Stamina = value; }
    [SerializeField]
    private float MaxStamina = 100;
    [SerializeField]
    private float abilityCost;
    private bool WallJumping = false;

    public float AbilityCost { get => abilityCost; set=> abilityCost = value; }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(grounded && canMove)
            StartCoroutine(Jump(0.5f));
    }

    public void Stop()
    {
        movementForce.x = 0;
        moving = false;
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (canMove && !Healing)
        {
            movementForce.x = obj.ReadValue<float>();
            moving = true;
        }
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        if (CurrentStamina > 9)
        {
            WH.Fire();
            AniMethods.SetChargeTrigger();
            staminaBar.value = CurrentStamina;
        }
    }

    Vector2 WallJumpForce;
    private IEnumerator WallJump()
    {
        WallJumping = true;
        WallJumpForce = new Vector2(0, jumpForce);
        WallJumpForce.x = FacingRight ? -JumpForce : JumpForce;
        FacingRight = WallJumpForce.x > 0;

        yield return new WaitForSeconds(0.5f);
        WallJumping = false;

    }

    protected override void GravityCheck()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1);
        Interacts.PlayerHit(colliders, gameObject, 5);
        Collider[] BackgroundColliders = Physics.OverlapSphere(WallDetectionObject.transform.position, 0.5f);
        TouchingWall = Interacts.WallCling(BackgroundColliders);

        if (TouchingWall)
        {
            gravity = Wall_Gravity;
            if (Controls.Basic.Jump.triggered)
            {
                StartCoroutine(WallJump());
            }
        }

        if (WallJumping)
        {
            movementForce = WallJumpForce;
            if (Controls.Basic.Movement.triggered && !grounded)
            {
                WallJumping = false;
            }
        } 

        if (GravityOn)
        {
            if (!grounded && !jumping && !WallJumping)
            {
                movementForce.y = -gravity;
            }
            else if (grounded && !jumping && !WallJumping)
            {
                movementForce.y = 0;
                if(!WallJumping && !moving && !Controls.Basic.Movement.triggered)
                {
                    movementForce.x = 0;
                }
            }

            if (jumping || WallJumping)
            {
                movementForce.y = jumpForce;
            }

            if (grounded)
            {
                gravity = Normal_Gravity; 
            }

        }
    }

    public override void OnTakeDamage(int damage)
    {
        if (!invulnerable)
        {
            //PlayAnimation for taking damage that allows player to be invulnerable for its duration
            AniMethods.SetDamageTrigger();
            base.OnTakeDamage(damage);
            StartCoroutine(InvolTimer());
            healthBar.value = CurrentHealth;
        }
    }

    protected override void OnDeath()
    {
        GameManager.LevelReload();
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
        base.FixedUpdate();

        AniMethods.SetGrounded(grounded);
    }

    private void Update()
    {
        if (grounded)
        {
            AniMethods.SetRun(moving);
            AniMethods.SetHealing(Healing);

            if (Healing)
            {
                if (CurrentHealth < MaxHealth)
                {
                    CurrentHealth += HealSpeed * Time.deltaTime;
                    healthBar.value = CurrentHealth;
                }

                if (Stamina < MaxStamina)
                {
                    Stamina += Time.deltaTime * HealSpeed;
                    staminaBar.value = CurrentStamina;
                }
            }
        }


        if (moving)
        {
            FacingRight = movementForce.x > 0;
        }

        if (!FacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0);
        }

        Position = transform.position;

    }

    public void addWeapon(Weapon newWeapon)
    {
        WH.Add(newWeapon);
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
        Gizmos.DrawWireCube(GroundedPlacer.transform.position, new Vector3(.5f, GroundDistance));
        Gizmos.DrawWireSphere(WallDetectionObject.transform.position, 0.5f);
    }

    private void LowHealth()
    {
        AkSoundEngine.SetRTPCValue("Health", CurrentHealth);
        AkSoundEngine.PostEvent("Play_Player_LowHealth", this.gameObject);
    }
}
