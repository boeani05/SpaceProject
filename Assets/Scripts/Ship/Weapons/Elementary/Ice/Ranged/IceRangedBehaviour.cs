using UnityEngine;

public class IceRangedBehaviour : ProjectileBehaviour
{
    private IceRangedCombatStats combatStats;

    void Awake()
    {
        base.Awake();
        InitializeCombatStats();
    }

    private void InitializeCombatStats()
    {
        combatStats = gameObject.GetComponent<IceRangedCombatStats>();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Slow(collision.gameObject.GetComponent<ISlowable>());
    }

    private void Slow(ISlowable enemy)
    {
        enemy?.ApplySlow(combatStats.GetSlowMultiplier(), combatStats.GetSlowDuration());
    }
}
