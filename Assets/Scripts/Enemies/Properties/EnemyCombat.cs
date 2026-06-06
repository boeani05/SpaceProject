using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    private IDamageSource damageSource;
    private EnemyKnockback enemyKnockback;

    void Awake()
    {
        InitializeDamageSource();
        InitializeEnemyKnockback();
    }
    private void InitializeDamageSource()
    {
        damageSource = gameObject.GetComponent<IDamageSource>();
    }
    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<EnemyKnockback>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(damageSource.GetDamage());
        StartCoroutine(enemyKnockback.TriggerKnockback());
    }
}
