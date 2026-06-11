using System.Collections;
using UnityEngine;

public class StandardEnemyMovement : BaseEnemyMovement
{
    private StandardEnemyKnockback enemyKnockback;

    void Awake()
    {
        base.Awake();
        InitializeEnemyKnockback();
    }

    protected override void FixedUpdate()
    {
        if (!enemyKnockback.IsKnockbackActive())
        {
            base.FixedUpdate();
        }
    }

    private void InitializeEnemyKnockback()
    {
        enemyKnockback = gameObject.GetComponent<StandardEnemyKnockback>();
    }
}
