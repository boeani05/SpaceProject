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

    void FixedUpdate()
    {
        Vector2 directionToMove = (player.transform.position - transform.position).normalized;

        MoveToPlayer(directionToMove);
    }

    private void MoveToPlayer(Vector2 directionToMove)
    {
        rigidbody2D.linearVelocity = directionToMove * movementSpeed;
    }
}
