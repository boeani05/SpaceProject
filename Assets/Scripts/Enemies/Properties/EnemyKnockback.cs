using System.Collections;
using UnityEngine;

public class EnemyKnockback : MonoBehaviour
{
    private EnemyKnockbackStats enemyKnockbackStats;
    private EnemyMovementStats enemyMovementStats;
    private bool isKnockbackActive;
    private float knockbackForce;
    private new Rigidbody2D rigidbody2D;
    private EnemyNavigation enemyNavigation;

    void Awake()
    {
        InitializeEnemyKnockbackStats();
        InitializeEnemyMovementStats();
        InitializeRigidbody2D();
        InitializeIsKnockbackActive();
        InitializeKnockbackForce();
        InitializeEnemyNavigation();
    }
    private void InitializeEnemyKnockbackStats()
    {
        enemyKnockbackStats = gameObject.GetComponent<EnemyKnockbackStats>();
    }

    private void InitializeEnemyMovementStats()
    {
        enemyMovementStats = gameObject.GetComponent<EnemyMovementStats>();
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
        knockbackForce = enemyMovementStats.GetMovementSpeed() * enemyKnockbackStats.GetKnockbackMultiplier();
    }
    private void InitializeEnemyNavigation()
    {
        enemyNavigation = gameObject.GetComponent<EnemyNavigation>();
    }

    public bool IsKnockbackActive()
    {
        return isKnockbackActive;
    }

    public IEnumerator TriggerKnockback()
    {
        SetKnockbackActive(true);
        rigidbody2D.AddForce(-enemyNavigation.EvaluateDirection() * knockbackForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.2f);
        SetKnockbackActive(false);
    }

    private void SetKnockbackActive(bool isKnockbackActive)
    {
        this.isKnockbackActive = isKnockbackActive;
    }
}
