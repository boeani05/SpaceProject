using UnityEngine;

public class FireRangedBehaviour : MonoBehaviour
{
    private FireRangedCombatStats combatStats;

    void Awake()
    {
        InitializeCombatStats();
    }

    private void InitializeCombatStats()
    {
        combatStats = gameObject.GetComponent<FireRangedCombatStats>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(combatStats.GetDamage());
    }
}
