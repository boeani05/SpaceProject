using UnityEngine;

public abstract class BaseEnemyNavigation : MonoBehaviour
{
    private PlayerLocator playerLocator;

    void Awake()
    {
        InitializePlayerLocator();
    }

    private void InitializePlayerLocator()
    {
        playerLocator = gameObject.GetComponent<PlayerLocator>();
    }

    public Vector2 EvaluateDirection()
    {
        return (playerLocator.GetPlayer().transform.position - transform.position).normalized;
    }
}
