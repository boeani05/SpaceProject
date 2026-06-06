using UnityEngine;

public class FireRangedCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;

    public float GetDamage() => damage;
}
