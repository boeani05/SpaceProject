using UnityEngine;

public abstract class BaseEnemyCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;

    public float GetDamage() => damage;
}
