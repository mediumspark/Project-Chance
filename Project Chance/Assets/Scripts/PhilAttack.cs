using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))][RequireComponent(typeof(SpriteRenderer))]
public class PhilAttack : MonoBehaviour
{
    GameObject Real, Fake;
    public Vector2 PlayerLocation = Vector2.zero;
    public bool isReal = false;

    public bool Attack;
    public float Speed = 0.5f;

    public GameObject RealOneObject { get; set; } 

    private void Awake()
    {
        Real = Resources.Load<GameObject>("Prefabs/Bosses/The Fake Phil Prefab");
        Fake = Resources.Load<GameObject>("Prefabs/Bosses/The Real Phil Prefab");
    }

    public void Summon()
    {
        if (isReal)
        {
            Instantiate(Real, transform);
        }
        else
        {
            Instantiate(Fake, transform);
        }
    }

    private void FixedUpdate()
    {
        if (Attack)
            transform.position = Vector3.MoveTowards(transform.position, PlayerLocation, Speed);

        if (Real && RealOneObject != null)
            RealOneObject.transform.position = transform.position; 
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}