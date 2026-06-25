using System.Collections;
using UnityEngine;

public class FireRangedBehaviour : MonoBehaviour
{
    private FireRangedCombatStats combatStats;

    void Awake()
    {
        InitializeCombatStats();
        InitializeExplosion();
    }

    private void InitializeCombatStats()
    {
        combatStats = gameObject.GetComponent<FireRangedCombatStats>();
    }

    private void InitializeExplosion()
    {
        StartCoroutine(FireSequence());
    }

    private IEnumerator FireSequence()
    {
        yield return new WaitForSeconds(combatStats.GetExplosionVisibleDelay());
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(combatStats.GetDamage());
        collision.gameObject.GetComponent<IBurnable>()?.ApplyBurn(combatStats.GetTickInterval(), combatStats.GetDamagePerTick(), combatStats.GetBurnDuration());
    }
}
