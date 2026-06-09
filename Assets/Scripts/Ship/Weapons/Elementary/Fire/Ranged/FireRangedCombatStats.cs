using System;
using UnityEngine;

public class FireRangedCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;
    [SerializeField] private float explosionVisibleDelay;

    public float GetDamage() => damage;
    public float GetExplosionVisibleDelay() => explosionVisibleDelay;
}
