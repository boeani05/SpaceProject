using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float speedOfProjectile;

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
        rigidbody2D.linearVelocity = direction * speedOfProjectile;
        DestroyIfOutOfBounds();
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

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
