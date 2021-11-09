using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq; 

public class Interacts
{
    public static void PlayerHit(Collider2D[] colliders, GameObject go, int damage)
    {
        foreach (Collider2D col in colliders)
        {
            if (OnInteract(LayerMask.LayerToName(col.gameObject.layer)) && go.TryGetComponent(out Player P))
            {
                if (col.tag.Equals("DamagingObsticle") || col.tag.Equals("Enemy"))
                {
                    P.OnTakeDamage(damage);
                }

                if (col.tag.Equals("KillObsticle"))
                {
                    P.InstaDeath(); 
                }
            }
        }
    }

    public static bool WallCling(Collider[] colliders)
    {
        var WallColliders = colliders.ToList().Where(ctx => LayerMask.LayerToName(ctx.gameObject.layer) == "Wall" || LayerMask.LayerToName(ctx.gameObject.layer) == "Ground").FirstOrDefault();

        return WallColliders != null; 
    }

    private static bool OnInteract(string Layer)
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

            case "Wall":
                Debug.Log("Wall");
                return true; 

            default:
                break; 
        } 
        return false; 
    }
}
