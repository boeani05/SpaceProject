using UnityEngine;

public class StandardEnemyKnockbackStats : MonoBehaviour
{
    [SerializeField] private float knockbackMultiplier;

    public float GetKnockbackMultiplier() => knockbackMultiplier;
}
