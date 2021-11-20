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
        Fake = Resources.Load<GameObject>("Prefabs/Bosses/The Fake Phil Prefab");
        RealOneObject = GameObject.Find("The Real One");
        GetComponent<BoxCollider2D>().size = new Vector2(1, 3);
    }

    public void Summon()
    {
        Instantiate(Fake, transform);
    }

    private void FixedUpdate()
    {
        gameObject.layer = isReal ? LayerMask.NameToLayer("Boss") : LayerMask.NameToLayer("Fake");
        tag = isReal ? "Boss" : "Fake"; 

        if (Attack) 
            transform.position = Vector3.MoveTowards(transform.position, PlayerLocation, Speed);


        if (isReal && RealOneObject != null)
            RealOneObject.transform.position = transform.position; 
    }

    private void OnDisable()
    {
        Destroy(gameObject);
    }
}