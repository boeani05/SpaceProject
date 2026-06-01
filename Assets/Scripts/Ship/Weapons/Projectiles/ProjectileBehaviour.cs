using Unity.VisualScripting;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionObject = collision.gameObject;

        collisionObject.GetComponent<IDamageable>()?.ApplyDamage(damage);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
