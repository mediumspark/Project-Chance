using UnityEngine;
using System.Collections; 

public class AimedBullet : Bullet
{
    protected Vector3 Destination;

    public void SetDestination(float duration)
    {
        Destination = Player.Position;
        StartCoroutine(Timer(duration));
    }

    protected IEnumerator Timer(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        Destroy(gameObject); 
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, Destination + Vector3.right * 10, 0.2f);
    }
}
