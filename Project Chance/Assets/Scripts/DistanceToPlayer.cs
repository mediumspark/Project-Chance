using UnityEngine;

public class DistanceToPlayer : MonoBehaviour
{
    private float GetDistanceToPlayerG;

    private void Update()
    {
        GetDistanceToPlayerG = Vector3.Distance(transform.position, Player.Position);
    }
}
