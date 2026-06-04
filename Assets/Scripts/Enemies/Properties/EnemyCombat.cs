using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private EnemyStat enemyStat;
    private EnemyKnockback enemyKnockback;

    void Awake()
    {
        InitializeEnemyStat();
        InitializeEnemyKnockback();
    }
    private void InitializeEnemyStat()
    {
        enemyStat = gameObject.GetComponent<EnemyStat>();
    }
    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<EnemyKnockback>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        collisionObject.GetComponent<IDamageable>()?.ApplyDamage(enemyStat.GetDamage());

        StartCoroutine(enemyKnockback.TriggerKnockback());
    }
}
