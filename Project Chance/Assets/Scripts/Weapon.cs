using UnityEngine;
using System.Collections;

[System.Serializable]
public class Weapon
{
    protected static Color CloakColor;
    protected static int damage;

    protected class AttackEffect : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.transform.CompareTag("Enemy") || collision.transform.CompareTag("Boss"))
            {
                if (collision.gameObject.GetComponentInParent<Character>())
                {
                    collision.gameObject.GetComponentInParent<Character>().OnTakeDamage(damage);
                    if (collision.transform.CompareTag("Boss"))
                       collision.gameObject.GetComponentInParent<Character>().StartCoroutine(
                           collision.gameObject.GetComponentInParent<Boss>().deactivateHurtbox(1.5f)); 
                }
                

                if(collision.gameObject.name == "New Game Object")
                {
                    Destroy(collision.gameObject); 
                }                
            }

            if (collision.transform.CompareTag("Destructable"))
            {
                collision.gameObject.GetComponent<IDestructable>().OnHit(); 
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("Hit 3D Object");
            if (collision.transform.CompareTag("Destructable"))
            {
                collision.gameObject.GetComponent<IDestructable>().OnHit();
            }
        }
    }

    public virtual void OnUpgrade(int damageUpgrade)
    {

    }

    public virtual void Fire(int cost)
    {
        Debug.Log("Default Weapon Fired");
    }

}

[System.Serializable]
public class Default : Weapon
{
    private float MoveDistance;
    Player Player;

    public Default(Player player, float MoveDistance, int damage)
    {
        Player = player; this.MoveDistance = MoveDistance; Default.damage = damage; 
    }

    public override void Fire(int cost)
    {
        if (cost <= Player.CurrentStamina) 
        {
            Player.CurrentStamina -= cost;
            Player.StartCoroutine(Dash());
        }
    }


    private IEnumerator Dash()
    {
        GameObject Effect = Resources.Load<GameObject>("Prefabs/Charge Attack");

        GameObject go = Player.Instantiate(Effect, Player.transform);
        Player.isInvol = true; 
        go.AddComponent<AttackEffect>();

        Player.isGravityOn = false; 
        Player.canMove = false; 
        
        float DashDistance = Player.FacingRight ? MoveDistance :-MoveDistance; 
        Player.MovementForce = new Vector2(DashDistance, 0);
        
        yield return new WaitForSeconds(0.25f);
        
        Object.Destroy(go);
        Player.isGravityOn = true;
        Player.isInvol = false; 
        Player.MovementForce =  Player.Moving ? Player.MovementForce * 0.5f : Vector2.zero; 
        Player.canMove = true;
    }
}

public class ThePhilanthropist : Weapon
{
    Player Player;
    public ThePhilanthropist(Player player)
    {
        Player = player; 
    }

    public override void Fire(int cost)
    {
        if (cost <= Player.CurrentStamina)
        {
            Player.CurrentStamina -= cost;
            if (Player.isGrounded)
                Player.StartCoroutine(Rise());
            else
                Player.StartCoroutine(Slam());
        }
    }

    public IEnumerator Rise()
    {
        Player.isGravityOn = false;
        Player.canMove = false; 
        Player.MovementForce = new Vector2(0, Player.JumpForce);
        yield return new WaitForSeconds(0.5f);
        Player.StartCoroutine(Slam()); 
    }

    public IEnumerator Slam()
    {
        Player.isGravityOn = true; 
        Player.ExternalChargeTrigger(); 
        GameObject Effect = Resources.Load<GameObject>("Prefabs/DropAttack");

        GameObject go = Player.Instantiate(Effect, Player.transform);
        Player.isInvol = true;
        go.AddComponent<AttackEffect>();

        Player.MovementForce *= 4;
        

        yield return new WaitUntil(() => Player.isGrounded);

        Player.isGravityOn = true;
        Object.Destroy(go);
        Player.isInvol = false;
        Player.canMove = true;
    }


}

public class TheMayor : Weapon
{
    Player Player;
    GameObject AttackPilar;

    public TheMayor(Player P)
    {
        Player = P;        
    }

    public override void Fire(int cost)
    {
        if (cost <= Player.CurrentStamina)
        {
            Player.CurrentStamina -= cost;
            Player.StartCoroutine(Stomp());
        }
    }

    private IEnumerator Stomp()
    {
        if (Player.isGrounded)
        {
            AttackPilar = (GameObject)Resources.Load("Prefabs/Enemies/Player Attack Pillar");
            GameObject go = Player.Instantiate(AttackPilar, Player.gameObject.transform);
            go.transform.localPosition = new Vector3(1, -0.7f);
            go.AddComponent<AttackEffect>(); 
            PlayerPilars attack = go.AddComponent<PlayerPilars>();
            float PlayerY = Player.GetComponent<CharacterController>().height; 
            attack.SetPilarHeight(PlayerY, 0.7f);
            go.transform.parent = null; 
            
            yield return new WaitForSeconds(5.0f);
            Player.Destroy(go);
        }
    }

    protected class PlayerPilars : MonoBehaviour
    {
        private float YDestination, RaisingSpeed;

        public void SetPilarHeight(float ScaleY, float Speed)
        {
            YDestination = ScaleY; RaisingSpeed = Speed;
        }
        private void FixedUpdate()
        {
            if (transform.localScale.y <= YDestination)
            {
                transform.localScale = new Vector3(1, transform.localScale.y + RaisingSpeed, 1);
            }
        }
    }
}

public class TheRebel : Weapon
{

}

public class TheChief : Weapon
{

}

public class TheBureaucrat : Weapon
{

}