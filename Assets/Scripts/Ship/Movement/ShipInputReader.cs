using UnityEngine;

public class ShipInputReader : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public Vector2 GetMovementDirection() => new Vector2(horizontalInput, verticalInput).normalized;
    public float GetHorizontalInput() => horizontalInput;
    public float GetVerticalInput() => verticalInput;
}