using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private ShipInputReader inputHandler;
    private ShipFlip shipFlip;
    private ShipMovementStats movementStats;

    void Awake()
    {
        movementStats = gameObject.GetComponent<ShipMovementStats>();
        inputHandler = gameObject.GetComponent<ShipInputReader>();
        shipFlip = gameObject.GetComponent<ShipFlip>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
        shipFlip.Flip(inputHandler.GetHorizontalInput(), inputHandler.GetVerticalInput());
    } 

    void FixedUpdate() 
    {
        Move();
    } 

    private void Move()
    {
        rigidbody.AddForce(inputHandler.GetMovementDirection() * movementStats.GetAccelerationForce());

        if(rigidbody.linearVelocity.magnitude > movementStats.GetMaxSpeed())
        {
            rigidbody.linearVelocity = rigidbody.linearVelocity.normalized * movementStats.GetMaxSpeed();
        }
    }
}