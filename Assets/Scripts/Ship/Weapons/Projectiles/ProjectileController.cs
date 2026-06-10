using UnityEngine;

public abstract class ProjectileController : MonoBehaviour, IWeapon
{
    [SerializeField] private GameObject prefab;

    protected ProjectileCalculator projectileCalculator;

    void Awake()
    {
        InitializeProjectileCalculator();
    }

    private void InitializeProjectileCalculator()
    {
        projectileCalculator = gameObject.GetComponent<ProjectileCalculator>();
    }

    protected virtual void Shoot()
    {
        Vector2 direction = projectileCalculator.CalculateShootingDirection();
        Vector2 spawnPosition = projectileCalculator.CalculateProjectileSpawningPosition(direction);

        GameObject projectile = SpawnProjectile(spawnPosition);
        InitializeProjectile(projectile, direction);
    }

    protected GameObject SpawnProjectile(Vector2 spawnPosition)
    {
        return Instantiate(prefab, spawnPosition, Quaternion.identity);
    }

    private void InitializeProjectile(GameObject projectile, Vector2 direction)
    {
        projectile.GetComponent<IProjectile>().SetDirection(direction);
    }

    protected GameObject GetPrefab() => prefab;
}