using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] private float speedOfProjectile;
    [SerializeField] private int damage; 

    private Camera mainCamera;
    private Vector2 direction;
    private new Rigidbody2D rigidbody2D;

    void Awake()
    {
        SetMainCamera();
        SetRigidbody2D();
    }

    private void SetMainCamera()
    {
        mainCamera = Camera.main;
    }

    private void SetRigidbody2D()
    {
        rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyMovementToProjectile();
        DestroyIfOutOfBounds();
    }

    private void ApplyMovementToProjectile()
    {
        rigidbody2D.linearVelocity = direction * speedOfProjectile;
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

    void OnCollisionEnter2D(Collision2D collider)
    {
        GameObject colliderObject = collider.gameObject;

        if (colliderObject.CompareTag("Enemy"))
        {
            ApplyDamage(colliderObject);
        }
    }

    private void ApplyDamage(GameObject enemy)
    {
        ReduceHealth(enemy.GetComponent<EnemyBehaviour>());  
    }

    private void ReduceHealth(EnemyBehaviour enemyBehaviour)
    {
        enemyBehaviour.SetHealth(enemyBehaviour.GetHealth() - damage);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
