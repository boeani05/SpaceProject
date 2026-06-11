using UnityEngine;

public class SuicideBomberCombatStats : BaseEnemyCombatStats
{
    [SerializeField] private float explosionRadius;

    public float GetExplosionRadius() => explosionRadius;
}
