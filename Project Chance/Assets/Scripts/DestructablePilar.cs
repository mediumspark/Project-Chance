using UnityEngine;

public class DestructablePilar : MonoBehaviour, IDestructable
{
    public bool DeadPilar = false;
    private float YDestination, RaisingSpeed;

    public void OnHit()
    {
        transform.parent.localScale = new Vector3(1, 0.5f, 1);
        DeadPilar = true;
    }
    public void SetPilarHeight(float ScaleY, float Speed)
    {
        YDestination = ScaleY; RaisingSpeed = Speed;
    }

    private void FixedUpdate()
    {
        if (!DeadPilar && transform.parent.localScale.y <= YDestination)
        {
            transform.parent.localScale = new Vector3(1, transform.parent.localScale.y + RaisingSpeed, 1);
        }
    }
}
