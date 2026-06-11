using UnityEngine;

public class StandardEnemyCombat : BaseEnemyCombat
{
    private StandardEnemyKnockback enemyKnockback;

    protected override void Awake()
    {
        base.Awake();
        InitializeEnemyKnockback();
    }
    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<StandardEnemyKnockback>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        StartCoroutine(enemyKnockback.TriggerKnockback());
    }
}
