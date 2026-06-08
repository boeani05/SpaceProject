using UnityEngine;

public class ShipMovementStats : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    public float GetMovementSpeed() => movementSpeed;
}
