using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] new Rigidbody2D rigidbody;
    [SerializeField] float movementSpeed;

    private float horizontalInput;
    private float verticalInput;
    private bool isFacingRight;
    private bool isFacingUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = GetHorizontalAxis();
        verticalInput = GetVerticalAxis();

        Flip();
    }

        private float GetHorizontalAxis()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    private float GetVerticalAxis()
    {
        return Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rigidbody.linearVelocity = SetLinearVelocityOfRigidbody();
    }

    private void Flip()
    {
        FlipHorizontallyIfNeeded();

        FlipVerticallyIfNeeded();
    }

    private void FlipHorizontallyIfNeeded()
    {
        if (!ShouldFlip(isFacingRight, horizontalInput)) return;

        isFacingRight = !isFacingRight;

        FlipX();
    }

    private void FlipVerticallyIfNeeded()
    {
        if (!ShouldFlip(isFacingUp, verticalInput)) return;

        isFacingUp = !isFacingUp;

        FlipY();
    }

    private bool ShouldFlip(bool isFacingPositiveDirection, float directionalInput)
    {
        return isFacingPositiveDirection && directionalInput < 0 ||
               !isFacingPositiveDirection && directionalInput > 0;
    }

    private void FlipX()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;

        transform.localScale = scale;
    }

    private void FlipY()
    {
        Vector3 scale = transform.localScale;
        scale.y *= -1;

        transform.localScale = scale;
    }

    private Vector2 SetLinearVelocityOfRigidbody()
    {
        return new Vector2(horizontalInput, verticalInput).normalized * movementSpeed;
    }
}
