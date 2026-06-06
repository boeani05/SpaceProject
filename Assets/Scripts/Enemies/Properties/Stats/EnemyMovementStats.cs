using UnityEngine;

public class EnemyMovementStats : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    public float GetMovementSpeed() => movementSpeed;

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
}
