using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class TheMayorBoss : Boss
{
    #region Variables
    private GameObject AttackPillar, ProjectileAttack; 
    
    [SerializeField]
    private GameObject SpawnSpotOnPlayer, SpawnSpotAsProjectile;

    private DestructablePilar DestructablePilar;

    [SerializeField]
    private float MayorPilarHeight = 10f;

    [SerializeField]
    private float AttackPilarScale;

    public Vector3 PilarPosition = Vector3.zero;

    bool RecentlyRaisedPilar; 

    bool isPilarAlive = false;

    private TextBoxManager IntroText;
    [SerializeField]
    private PlayableDirector Intro, Victory;

    public Slider enemyHealthBar;

    #endregion

    #region Mayor Attack
    protected class MayorPilars : MonoBehaviour
    {
        public bool Projectile;
        private float YDestination, RaisingSpeed, MovingSpeed;

        public void SetPilarHeight(float ScaleY, float Speed)
        {
            YDestination = ScaleY; RaisingSpeed = Speed; 
        }
        public void SetPilarSpeed(float speed) { Projectile = true;  MovingSpeed = speed; }

        private void FixedUpdate()
        {
            if (transform.localScale.y <= YDestination)
            {
                transform.localScale = new Vector3(1, transform.localScale.y + RaisingSpeed, 1);
            }
            if (Projectile)
            {
                transform.Translate(Vector3.right * MovingSpeed, 0);
            }
        }
    }
    #endregion

    public override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
        Victory.gameObject.SetActive(true);
    }

    protected override void Awake()
    {
        base.Awake();

        IntroText = GetComponentInChildren<TextBoxManager>();

        MaxHealth = 50;
        CurrentHealth = MaxHealth;
        AttackPillar = (GameObject)Resources.Load("Prefabs/Enemies/Boss Attack Pillar");
        ProjectileAttack = (GameObject)Resources.Load("Prefabs/Enemies/Enemy Bullet");
        PrizeWeapon = new TheMayor(FindObjectOfType<Player>());

        DestructablePilar = FindObjectOfType<DestructablePilar>();
        DestructablePilar.SetPilarHeight(MayorPilarHeight, 0.25f);

        enemyHealthBar = GameObject.Find("EnemyHealthBar").GetComponent<Slider>();
        enemyHealthBar.maxValue = MaxHealth;
    }

    private void Update()
    {
        SpawnSpotOnPlayer.transform.position = new Vector3(Player.Position.x, transform.parent.position.y);
       
        if(IntroText.Finished && !battlestart)
            Intro.gameObject.SetActive(true);
        else
        {
            Intro.gameObject.SetActive(false);
        }


        if (battlestart)
        {
            isPilarAlive = !DestructablePilar.DeadPilar;
        }
        enemyHealthBar.value = CurrentHealth;
    }


    public void RaiseDestructablePilar()
    {
        DestructablePilar.DeadPilar = false; 
    }

    public void ShootAtPlayer()
    {
        AimedBullet bul = Instantiate(ProjectileAttack, SpawnSpotAsProjectile.transform).AddComponent<AimedBullet>();
        bul.SetDestination(2.0f); 
        bul.BulletSpeed = 2.5f;
        bul.transform.SetParent(null);
        AkSoundEngine.PostEvent("Play_Mayor_RockProjectile", this.gameObject);
    }

    private void PilarAttack()
    {
        GameObject go = Instantiate(AttackPillar, SpawnSpotOnPlayer.transform.position, Quaternion.identity);
        MayorPilars attack = go.AddComponent<MayorPilars>();
        float PlayerY = Player.Position.y > 0 ? Player.Position.y  + 5f : (Player.Position.y + 5.0f) * -1; 
        attack.SetPilarHeight(PlayerY, 0.7f);
        RecentlyRaisedPilar = true;
        AkSoundEngine.PostEvent("Play_Mayor_Impacts", this.gameObject);
    }

    private void PilarWave()
    {
        GameObject go = Instantiate(AttackPillar, SpawnSpotAsProjectile.transform);
        MayorPilars attack = go.AddComponent<MayorPilars>();
        attack.SetPilarHeight(3.0f, 0.1f);
        attack.SetPilarSpeed(0.10f);
        RecentlyRaisedPilar = true;
        AkSoundEngine.PostEvent("Play_Mayor_RockSummon", this.gameObject);
    }

    protected override IEnumerator Phase1Attack()
    {
        if (isPilarAlive && !RecentlyRaisedPilar)
        {
            PilarAttack(); 
            yield return new WaitForSecondsRealtime(BaseCooldownTime);
            ShootAtPlayer(); 
            Destroy(FindObjectOfType<MayorPilars>().gameObject);
            RecentlyRaisedPilar = false; 
        }
        else if (!isPilarAlive && !RecentlyRaisedPilar)
        {
            yield return new WaitForSecondsRealtime(BaseCooldownTime * 2);
            RaiseDestructablePilar();
        }
        yield return new WaitForSeconds(BaseCooldownTime);//Attack Over
        startAttack = true;
    }// While on the pillar 1 throwing projectiles

    protected override IEnumerator Phase2Attack()
    {
        if (isPilarAlive && !RecentlyRaisedPilar)
        {
            PilarAttack();
            yield return new WaitForSecondsRealtime(BaseCooldownTime);
            ShootAtPlayer(); 
            Destroy(SpawnSpotOnPlayer.transform.GetChild(0).gameObject);
        }
        else if(!isPilarAlive)
        {
            yield return new WaitForSecondsRealtime(BaseCooldownTime);
            RaiseDestructablePilar();
        }
        yield return new WaitForSeconds(BaseCooldownTime);//Attack over
        startAttack = true;

    }// Summons an even higher pilar
     // While on pillar 2 thowing projectiles, and summoning pilars from the ground

    protected override IEnumerator Phase3Attack()
    {
        PilarWave();
        if(DestructablePilar != null)
            Destroy(DestructablePilar);
        yield return new WaitForSeconds(BaseCooldownTime);//Attack over
        startAttack = true;
    }
    //knocked off of pilar in one place
    //Jumps around creating waves of pillars 
}