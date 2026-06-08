using UnityEngine;

public class ShipFlip : MonoBehaviour
{
    private bool isFacingRight;
    private bool isFacingUp;

    public void Flip(float horizontalInput, float verticalInput)
    {
        if (ShouldFlip(isFacingRight, horizontalInput)) 
        { 
            isFacingRight = !isFacingRight; FlipAxis(true); 
        }

        if (ShouldFlip(isFacingUp, verticalInput)) 
        { 
            isFacingUp = !isFacingUp; FlipAxis(false); 
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
        } else 
        {
            scale.y *= -1;
        }

        transform.localScale = scale;
    }
}