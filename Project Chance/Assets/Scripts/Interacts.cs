using UnityEngine;

public class Interacts
{
    public static void PlayerHit(Collider2D[] colliders, GameObject go, int damage)
    {
        foreach (Collider2D col in colliders)
        {
            if (OnInteract(LayerMask.LayerToName(col.gameObject.layer)))
            {
                if ((col.tag.Equals("DamagingObsticle") || col.tag.Equals("Enemy")) 
                    && go.TryGetComponent(out Player P))
                {
                    P.OnTakeDamage(damage);
                }
            }
        }
    }

    public static bool OnInteract(string Layer)
    {
        switch (Layer)
        {
            case "Obsticle ":
                Debug.Log("Obsticle");
                return true; 

            case "Enemy":
                Debug.Log("Enemy");
                return true;

            case "PlayerAttack":
                Debug.Log("Enemy Hit");
                return true; 

            default:
                break; 
        } 
        return false; 
    }
}
