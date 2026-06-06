using UnityEngine;

public class IceRangedCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float slowMultiplier;
    [SerializeField] private float slowDuration;
    [SerializeField] private float damage;

    public float GetSlowMultiplier() => slowMultiplier;
    public float GetSlowDuration() => slowDuration;
    public float GetDamage() => damage;
}
