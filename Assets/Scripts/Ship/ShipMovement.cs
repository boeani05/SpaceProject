using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float movementSpeed;
    private bool isFacingRight;
    private bool isFacingUp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
