using UnityEngine;

public class DefaultWeaponStats : MonoBehaviour, IProjectileStats
{
    [SerializeField] private float damage;
    [SerializeField] private float projectileSpeed;

    public float GetDamage() => damage;
    public float GetProjectileSpeed() => projectileSpeed;
}
