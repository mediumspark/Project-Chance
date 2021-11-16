using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Player : Character
{
    private PlayerControls Controls;

    //I wanted these to be viewable in the inspector to check that they work.
    private readonly WeaponHandler WH = new WeaponHandler();

    private bool Healing;
    private int HealSpeed = 1;
    private bool TouchingWall;
    float Wall_Gravity = 0.5f;
    float Normal_Gravity = 1.5f;




    public Slider healthBar;

    [SerializeField]
    private GameObject WallDetectionObject;

    public bool FacingRight;

    public bool canMove { get; set; }
    public bool Moving => moving;
    AnimatorMethods AniMethods;
    SpriteRenderer sr;

    public bool isInvol { get => invulnerable; set => invulnerable = value; }
    public bool isGrounded { get => grounded; }

    private int base_speed = 4;

    protected override void Awake()
    {
        base.Awake();


        DontDestroyOnLoad(gameObject);
        canMove = true;

        AniMethods = GetComponent<AnimatorMethods>();

        MaxHealth = 100;
        CurrentHealth = MaxHealth;

        Speed = base_speed;

        sr = GetComponent<SpriteRenderer>();
        WH.Add(new Default(this, 4f, 10, Color.black));
        WH.SetCurrentWeapon(0);

        #region Inputs
        Controls = new PlayerControls();

        Controls.Basic.Movement.performed += Movement_performed;
        Controls.Basic.Movement.canceled += ctx => movementForce.x = 0;
        Controls.Basic.Movement.canceled += ctx => moving = false;

        Controls.Basic.Jump.performed += Jump_performed;
        Controls.Basic.Jump.canceled += ctx => jumping = false;

        Controls.Basic.Heal.performed += ctx => Healing = true;
        Controls.Basic.Heal.canceled += ctx => Healing = false;

        Controls.Basic.Attack.performed += ctx => WH.Fire();
        Controls.Basic.Attack.performed += ctx => AniMethods.SetChargeTrigger();

        Controls.Basic.WeaponCycle.performed += ctx => WH.WeaponSwap(ctx.ReadValue<float>());
        #endregion
    }

    [SerializeField]
    private float Stamina;
    [SerializeField]
    private float MaxStamina = 100;

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (grounded && canMove)
            StartCoroutine(Jump(0.5f));

        if (TouchingWall)
            StartCoroutine(WallJump(0.5f));
    }

    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if (canMove && !Healing)
        {
            moving = true;
            movementForce.x = obj.ReadValue<float>();
        }

        FacingRight = obj.ReadValue<float>() > 0;

    }

    private IEnumerator WallJump(float duration)
    {
        if (!grounded)
        {
            Vector2 tempMovementForce = MovementForce;
            Vector2 WallJumpForce = new Vector2(0, jumpForce);
            WallJumpForce.x = FacingRight ? -JumpForce : JumpForce;
            FacingRight = WallJumpForce.x > 0;
            movementForce = WallJumpForce;
            jumping = true;
            yield return new WaitForSeconds(duration); // Jump Ended
            jumping = false;
            MovementForce = tempMovementForce;
        }
    }

    public override void OnTakeDamage(int damage)
    {
        //PlayAnimation for taking damage that allows player to be invulnerable for its duration
        AniMethods.SetDamageTrigger();
        base.OnTakeDamage(damage);
        StartCoroutine(InvolTimer());
        healthBar.value = CurrentHealth;
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

        if (Healing)
        {
            if (CurrentHealth < MaxHealth)
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

        AniMethods.SetGrounded(grounded);
    }

    private void Update()
    {
        if (grounded)
        {
            AniMethods.SetRun(moving);
        }

        if (!FacingRight)
        {
            transform.eulerAngles = new Vector3(0, 180);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0);
        }
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


}