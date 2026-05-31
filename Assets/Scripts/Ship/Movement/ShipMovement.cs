using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float movementSpeed;

    private float horizontalInput;
    private float verticalInput;
    private bool isFacingRight;
    private bool isFacingUp;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Flip();
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = new Vector2(horizontalInput, verticalInput).normalized * movementSpeed;
    }

    private void Flip()
    {
        if (ShouldFlip(isFacingRight, horizontalInput))
        {
            isFacingRight = !isFacingRight;
            FlipAxis(horizontal: true);
        }

        if (ShouldFlip(isFacingUp, verticalInput))
        {
            isFacingUp = !isFacingUp;
            FlipAxis(horizontal: false);
        }
    }

    private bool ShouldFlip(bool isFacingPositiveDirection, float input)
    {
        return (isFacingPositiveDirection && input < 0) || (!isFacingPositiveDirection && input > 0);
    }

    private void FlipAxis(bool horizontal)
    {
        Vector3 scale = transform.localScale;
        if (horizontal)
        {
            scale.x *= -1;
        }
        else
        {
            scale.y *= -1;
        }
        transform.localScale = scale;
    }
}
