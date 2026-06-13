using UnityEngine;

public class BattleShipProjectile : MonoBehaviour, IProjectile
{
    private Camera mainCamera;
    private Vector2 direction;
    private new Rigidbody2D rigidbody2D;

    private IProjectileStats projectileStats;

    protected void Awake()
    {
        SetMainCamera();
        SetRigidbody2D();
        InitializeProjectileStats();
    }

    private void SetMainCamera()
    {
        mainCamera = Camera.main;
    }

    private void SetRigidbody2D()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void InitializeProjectileStats()
    {
        projectileStats = gameObject.GetComponent<IProjectileStats>();
    }

    void FixedUpdate()
    {
        ApplyMovementToProjectile();
        DestroyIfOutOfBounds();
    }

    private void ApplyMovementToProjectile()
    {
        rigidbody2D.linearVelocity = direction * projectileStats.GetProjectileSpeed();
    }

    private void DestroyIfOutOfBounds()
    {
        if (DidProjectileLeaveScreen())
        {
            Destroy(gameObject);
        }
    }

    private bool DidProjectileLeaveScreen()
    {
        Vector2 projectilePositionOnScreen = mainCamera.WorldToScreenPoint(transform.position);

        return projectilePositionOnScreen.x < 0 || projectilePositionOnScreen.x > mainCamera.pixelWidth ||
            projectilePositionOnScreen.y < 0 || projectilePositionOnScreen.y > mainCamera.pixelHeight;
    }

    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(projectileStats.GetDamage());
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
