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
                collision.gameObject.GetComponentInParent<Enemy>().OnTakeDamage(damage); 
            }
        }
    }

    public virtual void OnUpgrade(int damageUpgrade)
    {

    }

    public virtual void Fire()
    {
        Debug.Log("Default Weapon Fired");
    }

}


public class Default : Weapon
{
    private float MoveDistance;
    Player Player;

    public Default(Player player, float MoveDistance, int damage, Color Color)
    {
        Player = player; this.MoveDistance = MoveDistance; Default.damage = damage; Default.CloakColor = Color; 
    }

    public override void Fire()
    {
        Player.StartCoroutine(Dash());
    }


    private IEnumerator Dash()
    {
        GameObject Effect = Resources.Load<GameObject>("Prefabs/Charge Attack");

        GameObject go = Player.Instantiate(Effect, Player.transform);
        go.AddComponent<AttackEffect>();

        float gravityplaceholder = 1.5f;
        Player.Gravity = 0;
        Player.canMove = false; 
        
        float DashDistance = Player.FacingRight ? MoveDistance :-MoveDistance; 
        Player.MovementForce = new Vector2(DashDistance, 0);
        
        yield return new WaitForSeconds(0.25f);
        
        Object.Destroy(go);
        Player.Gravity = gravityplaceholder; 
        Player.MovementForce =  Player.Moving ? Player.MovementForce * 0.5f : Vector2.zero; 
        Player.canMove = true;
    }
}

public class ThePhilanthropist : Weapon
{

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