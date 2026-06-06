using UnityEngine;

public class EnemyHealthStats : MonoBehaviour
{
    [SerializeField] private float health;

    public float GetHealth() => health;

    public void SetHealth(float health)
    {
        this.health = health;
    }
}
