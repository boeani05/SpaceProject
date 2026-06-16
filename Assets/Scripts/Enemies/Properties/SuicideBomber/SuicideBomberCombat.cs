using UnityEngine;

public class SuicideBomberCombat : BaseEnemyCombat
{
    [SerializeField] private float explosionShakeIntensity;
    private SuicideBomberCombatStats combatStats;
    private BaseEnemyHealth enemyHealth;

    protected override void Awake()
    {
        base.Awake();
        combatStats = gameObject.GetComponent<SuicideBomberCombatStats>();
        enemyHealth = gameObject.GetComponent<BaseEnemyHealth>();
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, combatStats.GetExplosionRadius());
        
        foreach(Collider2D collider in colliders)
        {
            base.DealDamage(collider.gameObject);
        }

        CameraShaker.Instance.Shake(explosionShakeIntensity);

        enemyHealth.Kill();
    }
}
