using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody2D;
    [SerializeField] float speedOfProjectile;

    private Vector2 distanceToMouse;

    void FixedUpdate()
    {
        MoveToMouseCursor();
    }

    private void MoveToMouseCursor()
    {
        rigidbody2D.linearVelocity = distanceToMouse * speedOfProjectile;
    }

    public void SetDistanceToMouse(Vector2 distanceToMouse)
    {
        this.distanceToMouse = distanceToMouse;
    }
}
