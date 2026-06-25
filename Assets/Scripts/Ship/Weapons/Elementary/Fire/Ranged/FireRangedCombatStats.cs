using System;
using UnityEngine;

public class FireRangedCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;
    [SerializeField] private float explosionVisibleDelay;
    [SerializeField] private float tickInterval;
    [SerializeField] private float damagePerTick;
    [SerializeField] private float burnDuration;

    public float GetDamage() => damage;
    public float GetExplosionVisibleDelay() => explosionVisibleDelay;
    public float GetTickInterval() => tickInterval;
    public float GetDamagePerTick() => damagePerTick;
    public float GetBurnDuration() => burnDuration;
}
