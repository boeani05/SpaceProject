using System.Collections;
using UnityEngine;

public class StandardEnemyMovement : BaseEnemyMovement
{
    private StandardEnemyKnockback enemyKnockback;

    protected override void Awake()
    {
        base.Awake();
        InitializeEnemyKnockback();
    }

    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<StandardEnemyKnockback>();
    }

    protected override void FixedUpdate()
    {
        if (enemyKnockback.IsKnockbackActive()) return;
        base.FixedUpdate();
    }
}
