using System;
using UnityEngine;

public class IceRangedCombatStats : MonoBehaviour, IProjectileStats
{
    [SerializeField] private float slowMultiplier;
    [SerializeField] private float slowDuration;
    [SerializeField] private float damage;
    [SerializeField] private float projectileSpeed;

    public float GetSlowMultiplier() => slowMultiplier;
    public float GetSlowDuration() => slowDuration;
    public float GetDamage() => damage;
    public float GetProjectileSpeed() => projectileSpeed;
}
