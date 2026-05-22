using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody2D;
    [SerializeField] float speedOfProjectile;

    private Camera mainCamera;
    private Vector2 direction;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void FixedUpdate()
    {
        rigidbody2D.linearVelocity = direction * speedOfProjectile;
        DestroyIfOutOfBounds();
    }

    private void DestroyIfOutOfBounds()
    {
        Vector2 screenPos = mainCamera.WorldToScreenPoint(transform.position);

        if (screenPos.x < 0 || screenPos.x > mainCamera.pixelWidth ||
            screenPos.y < 0 || screenPos.y > mainCamera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }
}
