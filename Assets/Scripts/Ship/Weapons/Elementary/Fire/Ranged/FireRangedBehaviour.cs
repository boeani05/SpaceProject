using System.Collections;
using UnityEngine;

public class FireRangedBehaviour : MonoBehaviour
{
    private FireRangedCombatStats combatStats;
    private BurnStats burnStats;

    void Awake()
    {
        combatStats = gameObject.GetComponent<FireRangedCombatStats>();
        burnStats = gameObject.GetComponent<BurnStats>();
        StartCoroutine(FireSequence());
    }

    private IEnumerator FireSequence()
    {
        yield return new WaitForSeconds(combatStats.GetExplosionVisibleDelay());
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(combatStats.GetDamage(), Element.FIRE);
        collision.gameObject.GetComponent<IBurnable>()?.ApplyBurn(burnStats.GetTickInterval(), burnStats.GetDamagePerTick(), burnStats.GetBurnDuration());
    }
}
