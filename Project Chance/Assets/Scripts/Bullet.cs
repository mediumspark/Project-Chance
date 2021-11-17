using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Character Owner { get; set; }
    public float BulletSpeed { get; set; }
    public delegate void OnColision(GameObject Opponent);

    public OnColision onColision;
    //If we want bullets do do more than just do damage we can assign their
    //effects onto this delegate and have it cause the effect on collision with an object

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * Time.deltaTime * BulletSpeed); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (onColision != null)
            onColision.Invoke(collision.gameObject);

        Destroy(gameObject);
    }
}
