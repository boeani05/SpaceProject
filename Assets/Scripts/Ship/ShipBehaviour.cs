using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] private float health;

    void Update()
    {
        if (!IsShipAlive())
        {
            Destroy(gameObject);
        }
    }

    private bool IsShipAlive()
    {
        return health > 0.0f;
    }

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float health)
    {
        this.health = health;
    }
}
