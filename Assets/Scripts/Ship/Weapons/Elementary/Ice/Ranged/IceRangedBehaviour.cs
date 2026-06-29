using UnityEngine;

public class IceRangedBehaviour : ProjectileBehaviour
{
    private IceRangedCombatStats combatStats;

    void Awake()
    {
        base.Awake();
        combatStats = gameObject.GetComponent<IceRangedCombatStats>();
    }

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        Slow(collision.gameObject.GetComponent<ISlowable>());
    }

    protected override Element GetProjectileElement()
    {
        return Element.ICE;
    }

    private void Slow(ISlowable enemy)
    {
        enemy?.ApplySlow(combatStats.GetSlowMultiplier(), combatStats.GetSlowDuration());
    }
}
