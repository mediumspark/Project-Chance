using UnityEngine;

public class ScatterShotBullet : AimedBullet
{
    public void SetDestination(Vector3 Destination, float duration)
    {
        this.Destination = Destination;

        StartCoroutine(Timer(duration));
    }
}
