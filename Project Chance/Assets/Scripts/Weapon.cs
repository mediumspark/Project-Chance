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
                       StartCoroutine( collision.gameObject.GetComponentInParent<Boss>().deactivateHurtbox(3f, collision)); 
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

    public Default(Player player, float MoveDistance, int damage, Color Color)
    {
        Player = player; this.MoveDistance = MoveDistance; Default.damage = damage; Default.CloakColor = Color; 
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
        GameObject Effect = Resources.Load<GameObject>("Prefabs/Charge Attack");

        GameObject go = Player.Instantiate(Effect, Player.transform);
        Player.isInvol = true;
        go.AddComponent<AttackEffect>();

        Player.Gravity *= 4;

        yield return new WaitUntil(() => Player.isGrounded);

        Object.Destroy(go);
        Player.isInvol = false;
        Player.canMove = true;
    }


}

public class TheMayor : Weapon
{

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