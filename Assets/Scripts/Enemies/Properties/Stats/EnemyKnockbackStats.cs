using UnityEngine;

public class EnemyKnockbackStats : MonoBehaviour
{
    [SerializeField] private float knockbackMultiplier;

    public float GetKnockbackMultiplier() => knockbackMultiplier;
}
