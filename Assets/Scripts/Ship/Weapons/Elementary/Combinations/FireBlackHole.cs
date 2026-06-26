using UnityEngine;

public class FireBlackHole : BaseBlackHole
{
    private BurnStats burnStats;

    protected override void Awake()
    {
        base.Awake();
        burnStats = gameObject.GetComponent<BurnStats>();
    }

    protected override void AffectEnemy(Collider2D collider)
    {
        collider.gameObject.GetComponent<IBurnable>()?.ApplyBurn(burnStats.GetTickInterval(), burnStats.GetDamagePerTick(), burnStats.GetBurnDuration());
    }
}
