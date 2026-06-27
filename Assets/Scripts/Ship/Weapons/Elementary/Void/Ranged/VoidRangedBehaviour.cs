using System.Collections;
using UnityEngine;

public class VoidRangedBehaviour : BaseBlackHole
{
    private BaseBlackHoleStats stats;

    protected override void Awake()
    {

    }

    void Start()
    {
        base.Awake();
    }

    protected override void AffectEnemy(Collider2D collider)
    {
        // collider.gameObject.GetComponent<IDamageable>()?.ApplyDamage()
    }
}
