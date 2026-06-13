using System;
using UnityEngine;

public class BattleShipProjectileStats : MonoBehaviour, IProjectileStats
{
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float damage;

    public float GetProjectileSpeed() => projectileSpeed;
    public float GetDamage() => damage;
}
