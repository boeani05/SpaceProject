using UnityEngine;

public class ShipMovementStats : MonoBehaviour
{
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationForce;

    public float GetMaxSpeed() => maxSpeed;
    public float GetAccelerationForce() => accelerationForce;
}