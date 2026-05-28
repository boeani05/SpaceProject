using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float movementSpeed;

    private GameObject player;
    private new Rigidbody2D rigidbody2D;

    void Awake()
    {
        SetPlayer();
        SetRigidbody2D();
    }

    private void SetPlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void SetRigidbody2D()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!IsEnemyAlive())
        {
            Destroy(gameObject);
        }
    }

    private bool IsEnemyAlive()
    {
        return health > 0.0f;
    }

    void FixedUpdate()
    {
        MoveToPlayer(EvaluateDirection());
    }

    private void MoveToPlayer(Vector2 directionToMove)
    {
        rigidbody2D.linearVelocity = directionToMove * movementSpeed;
    }

    private Vector2 EvaluateDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }
}
