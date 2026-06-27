using System;
using System.Collections;
using UnityEngine;

public abstract class BaseEnemyHealth : MonoBehaviour, IDamageable, IDeath, IBurnable
{
    [SerializeField] private float hitShakeIntensity;
    [SerializeField] private float deathShakeIntensity;

    public Action OnDeath;
    private BaseEnemyHealthStats enemyStat;
    private EnemyHitFlash hitFlash;
    private bool isBurning;
    private ElementVulnerability elementVulnerability;

    void Awake()
    {
        enemyStat = gameObject.GetComponent<BaseEnemyHealthStats>();
        hitFlash = gameObject.GetComponent<EnemyHitFlash>();
        isBurning = false;
        elementVulnerability = gameObject.GetComponent<ElementVulnerability>();
    }

    public void ApplyDamage(float damage, Element element)
    {
        CameraShaker.Instance.Shake(hitShakeIntensity);
        float effectiveDamage = elementVulnerability == null ? damage : elementVulnerability.GetEffectiveDamage(damage, element);
        enemyStat.SetHealth(enemyStat.GetHealth() - effectiveDamage);
        hitFlash.Flash();
        NotifyManagerOnDeath();
    }

    public void ApplyBurn(float tickInterval, float damagePerTick, float burnDuration)
    {
        if (!isBurning)
        {
            isBurning = true;
            StartCoroutine(Burn(tickInterval, damagePerTick, burnDuration));
        }
    }

    private IEnumerator Burn(float tickInterval, float damagePerTick, float burnDuration)
    {
        for (int ticksLeft = (int)(burnDuration / tickInterval); ticksLeft > 0; ticksLeft--)
        {
            ApplyDamage(damagePerTick, Element.FIRE);
            yield return new WaitForSeconds(tickInterval);
        }
        isBurning = false;
    }

    private void NotifyManagerOnDeath()
    {
        if (!IsAlive())
        {
            Kill();
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
