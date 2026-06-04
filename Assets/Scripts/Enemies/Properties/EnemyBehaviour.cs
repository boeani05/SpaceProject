using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private EnemyStat enemyStat;
    private EnemyKnockback enemyKnockback;
    private EnemyNavigation enemyNavigation;
    private new Rigidbody2D rigidbody2D;

    void Awake()
    {
        InitializeEnemyStat();
        InitializeEnemyKnockback();
        InitializeEnemyNavigation();
        InitializeRigidbody2D();
    }
    private void InitializeEnemyStat()
    {
        enemyStat = gameObject.GetComponent<EnemyStat>();
    }
    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<EnemyKnockback>();
    }
    private void InitializeEnemyNavigation()
    {
        enemyNavigation = gameObject.GetComponent<EnemyNavigation>();
    }
    private void InitializeRigidbody2D()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (!enemyKnockback.IsKnockbackActive())
        {
            MoveToPlayer(enemyNavigation.EvaluateDirection());
        }
    }    
    private void MoveToPlayer(Vector2 directionToMove)
    {
        rigidbody2D.linearVelocity = directionToMove * enemyStat.GetMovementSpeed();
    }
}
