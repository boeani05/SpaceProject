using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable, IDeath
{
    public Action OnDeath;
    private EnemyHealthStats enemyStat;

    void Awake()
    {
        InitializeEnemyStat();
    }
    private void InitializeEnemyStat()
    {
        enemyStat = gameObject.GetComponent<EnemyHealthStats>();
    }

    public void ApplyDamage(float damage)
    {
        enemyStat.SetHealth(enemyStat.GetHealth() - damage);
        NotifyManagerOnDeath();
    }

    private void NotifyManagerOnDeath()
    {
        if (!IsAlive())
        {
            OnDeath?.Invoke();
        }
    }

    public bool IsAlive()
    {
        return enemyStat.GetHealth() > 0.0f;
    }
}
