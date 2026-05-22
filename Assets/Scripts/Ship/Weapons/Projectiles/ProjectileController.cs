using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float offsetInPercent;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnProjectile();
    }

    private void SpawnProjectile()
    {
        Vector2 direction = ((Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
        Vector2 spawnPosition = (Vector2)transform.position + direction * (offsetInPercent / 100f);

        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        projectile.GetComponent<ProjectileBehaviour>().SetDirection(direction);
    }
}
