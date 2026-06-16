using System;
using UnityEngine;

public abstract class BaseEnemyHealth : MonoBehaviour, IDamageable, IDeath
{
    [SerializeField] private float hitShakeIntensity;
    [SerializeField] private float deathShakeIntensity;

    public Action OnDeath;
    private BaseEnemyHealthStats enemyStat;
    private EnemyHitFlash hitFlash;

    void Awake()
    {
        enemyStat = gameObject.GetComponent<BaseEnemyHealthStats>();
        hitFlash = gameObject.GetComponent<EnemyHitFlash>();
    }

    public void ApplyDamage(float damage)
    {
        CameraShaker.Instance.Shake(hitShakeIntensity);
        enemyStat.SetHealth(enemyStat.GetHealth() - damage);
        hitFlash.Flash();
        NotifyManagerOnDeath();
    }

    private void NotifyManagerOnDeath()
    {
        if (!IsAlive())
        {
            OnDeath?.Invoke();
            CameraShaker.Instance.Shake(deathShakeIntensity);
        }
    }

    public bool IsAlive()
    {
        return enemyStat.GetHealth() > 0.0f;
    }

    public void Kill()
    {
        OnDeath?.Invoke();
    }
}
