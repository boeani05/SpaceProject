using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;
    [SerializeField] private float damage;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float knockbackMultiplier;

    private GameObject player;

    private new Rigidbody2D rigidbody2D;

    private bool isKnockbackActive;

    private float knockbackForce;

    public void ApplyDamage(float damage)
    {
        health -= damage;
    }

    void Awake()
    {
        InitializePlayer();
        InitializeRigidbody2D();
        InitializeIsKnockbackActive();
        InitializeKnockbackForce();
    }

    private void InitializePlayer()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void InitializeRigidbody2D()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void InitializeIsKnockbackActive()
    {
        isKnockbackActive = false;
    }

    private void InitializeKnockbackForce()
    {
        knockbackForce = movementSpeed * knockbackMultiplier;
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
        if (!isKnockbackActive)
        {
            MoveToPlayer(EvaluateDirection());
        }
    }

    private void MoveToPlayer(Vector2 directionToMove)
    {
        rigidbody2D.linearVelocity = directionToMove * movementSpeed;
    }

    private Vector2 EvaluateDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        collisionObject.GetComponent<IDamageable>()?.ApplyDamage(damage);

        StartCoroutine(Knockback());
    }

    private IEnumerator Knockback()
    {
        SetIsKnockbackActive(true);
        rigidbody2D.AddForce(-EvaluateDirection() * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        SetIsKnockbackActive(false);
    }

    private void SetIsKnockbackActive(bool isKnockbackActive)
    {
        this.isKnockbackActive = isKnockbackActive;
    }
}
