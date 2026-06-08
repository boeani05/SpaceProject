using UnityEngine;

public class ProjectileCalculator : MonoBehaviour
{
    [SerializeField] private float offsetInPercent;

    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }
    public Vector2 CalculateShootingDirection()
    {
        return ((Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
    }

    public Vector2 CalculateProjectileSpawningPosition(Vector2 direction)
    {
        return (Vector2)transform.position + direction * (offsetInPercent / 100f);
    }
}
