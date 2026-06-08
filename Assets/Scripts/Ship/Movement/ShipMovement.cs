using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    private ShipVelocityCalculator inputHandler;
    private ShipFlip shipFlip;

    void Awake()
    {
        InitializeInputHandler();
        InitializeShipFlip();
        InitializeRigidbody();
    }

    private void InitializeInputHandler() {
        inputHandler = gameObject.GetComponent<ShipVelocityCalculator>();
    } 
    private void InitializeShipFlip() {
        shipFlip = gameObject.GetComponent<ShipFlip>();
    } 
    private void InitializeRigidbody()
    {
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
        rigidbody.linearVelocity = inputHandler.GetVelocity();
    } 
}