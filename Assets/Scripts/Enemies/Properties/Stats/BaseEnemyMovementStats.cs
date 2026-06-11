using UnityEngine;

public abstract class BaseEnemyMovementStats : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    public float GetMovementSpeed() => movementSpeed;

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }
}
