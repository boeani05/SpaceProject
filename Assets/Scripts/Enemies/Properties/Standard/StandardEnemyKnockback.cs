using System.Collections;
using UnityEngine;

public class StandardEnemyKnockback : MonoBehaviour
{
    private StandardEnemyKnockbackStats enemyKnockbackStats;
    private BaseEnemyMovementStats enemyMovementStats;
    private bool isKnockbackActive;
    private float knockbackForce;
    private new Rigidbody2D rigidbody2D;
    private StandardEnemyNavigation enemyNavigation;

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
        enemyKnockbackStats = gameObject.GetComponent<StandardEnemyKnockbackStats>();
    }

    private void InitializeEnemyMovementStats()
    {
        enemyMovementStats = gameObject.GetComponent<BaseEnemyMovementStats>();
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
        enemyNavigation = gameObject.GetComponent<StandardEnemyNavigation>();
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
