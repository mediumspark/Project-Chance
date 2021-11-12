using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))][RequireComponent(typeof(SpriteRenderer))]
public class PhilAttack : MonoBehaviour
{
    Sprite Real, Fake;

    Collider2D Collider2D;
    SpriteRenderer SpriteRenderer;

    public Vector2 PlayerLocation = Vector2.zero;
    public bool isReal = false;

    public bool Attack;
    public float Speed = 0.5f;

    public GameObject RealOneObject { get; set; } 

    private void Awake()
    {
        Real = Resources.Load<Sprite>("Artwork/Phil (real)");
        Fake = Resources.Load<Sprite>("Artwork/Phil (Fake)");
        Collider2D = GetComponent<Collider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        SpriteRenderer.sprite = isReal ? Real : Fake;
        gameObject.layer = isReal ? LayerMask.NameToLayer("Boss") : LayerMask.NameToLayer("Fake");
        tag = isReal ? "Boss" : "Fake";
        SpriteRenderer.color = isReal ? Color.green : Color.blue; // Temp

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