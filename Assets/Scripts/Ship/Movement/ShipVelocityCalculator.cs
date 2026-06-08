using UnityEngine;

public class ShipVelocityCalculator : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private ShipMovementStats movementStats;

    void Awake() 
    {
        movementStats = gameObject.GetComponent<ShipMovementStats>();
    } 

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    public Vector2 GetVelocity() => new Vector2(horizontalInput, verticalInput).normalized * movementStats.GetMovementSpeed();
    public float GetHorizontalInput() => horizontalInput;
    public float GetVerticalInput() => verticalInput;
}