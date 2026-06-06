using UnityEngine;

public class EnemyCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;

    public float GetDamage() => damage;
}
