using System;
using UnityEngine;

public class LightningRangedCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;
    [SerializeField] private float paralyzeDuration;
    [SerializeField] private float paralyzeChanceInPercent;
    [SerializeField] private float rayVisible;
    [SerializeField] private float maxDistanceOfRay;

    public float GetDamage() => damage;
    public float GetParalyzeDuration() => paralyzeDuration;
    public float GetParalyzeChance() => paralyzeChanceInPercent;
    public float GetRayVisible() => rayVisible;
    public float GetMaxDistanceOfRay() => maxDistanceOfRay;
}
