using System.Collections;
using UnityEngine;

public class VoidBlackHole : BaseBlackHole
{
    private VoidBlackHoleStats stats;

    protected override void Awake()
    {
        base.Awake();
        stats = gameObject.GetComponent<VoidBlackHoleStats>();
    }

    protected override void ApplyTickEffect(Collider2D collider)
    {
        collider.gameObject.GetComponent<IDamageable>()?.ApplyDamage(stats.GetDamage(), Element.VOID);
    }
}
