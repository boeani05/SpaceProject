using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float offsetInPercent;

    private Camera mainCamera;

    void Awake()
    {
        InitializeMainCamera();
    }

    private void InitializeMainCamera()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        Vector2 direction = CalculateShootingDirection();
        Vector2 spawnPosition = CalculateProjectileSpawningPosition(direction);

        GameObject projectile = SpawnProjectile(spawnPosition);
        InitializeProjectile(projectile, direction);
    }

    private Vector2 CalculateShootingDirection()
    {
        return ((Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
    }

    private Vector2 CalculateProjectileSpawningPosition(Vector2 directionFacing)
    {
        return (Vector2)transform.position + directionFacing * (offsetInPercent / 100f);
    }

    private GameObject SpawnProjectile(Vector2 spawnPosition)
    {
        return Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
    }

    private void InitializeProjectile(GameObject projectile, Vector2 direction)
    {
        projectile.GetComponent<ProjectileBehaviour>().SetDirection(direction);
    }
}
