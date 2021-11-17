using System.Collections;
using UnityEngine; 

public class TheMayorBoss : Boss
{
    private GameObject pillar = (GameObject)Resources.Load("Prefabs/Enemies/Boss Attack Pillar");
    
    [SerializeField]
    private GameObject SpawnSpotOnPlayer;

    [SerializeField]
    private GameObject SpawnSpotAsProjectile;

    public Vector3 PilarScale = Vector3.zero;
    public Vector3 PilarPosition = Vector3.zero; //I need to adjust for y in pilar scale?

    protected override void Awake()
    {
        base.Awake();
        PrizeWeapon = new TheMayor(); 
    }

    public override void OnTakeDamage(int damage)
    {
        base.OnTakeDamage(damage);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    protected override IEnumerator Phase1Attack()
    {
        GameObject go = Instantiate(pillar, SpawnSpotOnPlayer.transform); 
        yield return new WaitForSeconds(BaseCooldownTime);//Attack Over
    }// While on the pillar 1 throwing projectiles

    protected override IEnumerator Phase2Attack()
    {
        GameObject go = Instantiate(pillar, SpawnSpotOnPlayer.transform);
        yield return new WaitForSeconds(BaseCooldownTime);//Attack over
    }// Summons an even higher pilar
     // While on pillar 2 thowing projectiles, and summoning pilars from the ground

    protected override IEnumerator Phase3Attack()
    {
        GameObject go = Instantiate(pillar, SpawnSpotOnPlayer.transform);
        yield return new WaitForSeconds(BaseCooldownTime);//Attack over
    }
    //knocked off of pilar in one place
    //Jumps around creating waves of pillars 
}