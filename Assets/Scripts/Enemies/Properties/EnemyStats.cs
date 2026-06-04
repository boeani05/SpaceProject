using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float knockbackMultiplier;
    [SerializeField] private float damage;
    [SerializeField] private float health;

    public float GetMovementSpeed()
    {
        return movementSpeed;
    }

    public float GetKnockbackMultiplier()
    {
        return knockbackMultiplier;
    }

    public float GetDamage()
    {
        return damage;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }
}
