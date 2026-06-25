using System.Collections;
using UnityEngine;

public abstract class BaseEnemyMovement : MonoBehaviour, ISlowable, IParalyzable
{
    private BaseEnemyMovementStats enemyMovementStats;
    private BaseEnemyNavigation enemyNavigation;
    private new Rigidbody2D rigidbody2D;

    private bool isSlowed;
    private bool isParalyzed;

    protected virtual void Awake()
    {
        enemyMovementStats = gameObject.GetComponent<BaseEnemyMovementStats>();
        enemyNavigation = gameObject.GetComponent<BaseEnemyNavigation>();
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        isSlowed = false;
        isParalyzed = false;
    }

    protected virtual void FixedUpdate()
    {
        if (!ShouldMove())
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            return;
        }

        MoveToPlayer(enemyNavigation.EvaluateDirection());
    }

    protected virtual bool ShouldMove() => true;

    private void MoveToPlayer(Vector2 directionToMove)
    {
        rigidbody2D.linearVelocity = directionToMove * enemyMovementStats.GetMovementSpeed();
    }

    public void ApplySlow(float slowMultiplier, float slowDuration)
    {
        if (isSlowed) return;

        isSlowed = true;
        enemyMovementStats.SetMovementSpeed(enemyMovementStats.GetMovementSpeed() * slowMultiplier);
        StartCoroutine(ResetSlowedMovementSpeed(slowMultiplier, slowDuration));
    }

    private IEnumerator ResetSlowedMovementSpeed(float slowMultiplier, float slowDuration)
    {
        yield return new WaitForSeconds(slowDuration);
        enemyMovementStats.SetMovementSpeed(enemyMovementStats.GetMovementSpeed() / slowMultiplier);
        isSlowed = false;
    }

    public void Paralyze(float duration)
    {
        if (isParalyzed) return;

        isParalyzed = true;
        float currentMoveSpeed = enemyMovementStats.GetMovementSpeed();
        enemyMovementStats.SetMovementSpeed(0f);
        StartCoroutine(ResetParalyzedMovementSpeed(duration, currentMoveSpeed));
    }

    private IEnumerator ResetParalyzedMovementSpeed(float duration, float originalMovementSpeed)
    {
        yield return new WaitForSeconds(duration);
        enemyMovementStats.SetMovementSpeed(originalMovementSpeed);
        isParalyzed = false;
    }
}
