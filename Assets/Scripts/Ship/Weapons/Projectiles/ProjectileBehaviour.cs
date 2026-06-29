using UnityEngine;

public abstract class ProjectileBehaviour : MonoBehaviour, IProjectile
{
    private Camera mainCamera;
    private Vector2 direction;
    private new Rigidbody2D rigidbody2D;

    private IProjectileStats projectileStats;

    protected void Awake()
    {
        mainCamera = Camera.main;
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        projectileStats = gameObject.GetComponent<IProjectileStats>();
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = direction * projectileStats.GetProjectileSpeed();
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
        collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(projectileStats.GetDamage(), GetProjectileElement());
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    protected abstract Element GetProjectileElement();
}
