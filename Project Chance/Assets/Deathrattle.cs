using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathrattle : MonoBehaviour
{
    [SerializeField]
    GameObject[] BulletSpawnPoints; 

    private void OnDestroy()
    {
        foreach(GameObject spawnpoint in BulletSpawnPoints)
        {
            GameObject go = (GameObject)Resources.Load("Prefabs/Enemy Bullet");
            ScatterShotBullet bul = Instantiate(go, spawnpoint.transform.position, Quaternion.identity).AddComponent<ScatterShotBullet>();
            bul.BulletSpeed = 3.0f;
            bul.SetDestination(Player.Position, 5.0f);
        }
    }
}
