using UnityEngine;

public class DistanceToPlayer : MonoBehaviour
{
    private float GetDistanceToPlayerG;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>(); 
    }

    private void Update()
    {
        GetDistanceToPlayerG = Vector3.Distance(transform.position, player.transform.position);
    }
}
