using UnityEngine;

public class ShipBehaviour : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;

    public void ApplyDamage(float damage, Element element)
    {
        health -= damage;
    }

    void Update()
    {
        if (!IsShipAlive())
        {
            GameManager.GameOver();
        }
    }

    private bool IsShipAlive()
    {
        return health > 0.0f;
    }
}
