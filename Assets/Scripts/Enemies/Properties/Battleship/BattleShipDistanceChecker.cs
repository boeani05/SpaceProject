using UnityEngine;

public class BattleShipDistanceChecker : MonoBehaviour
{
    private BattleShipDistanceStats distanceStats;

    private PlayerLocator playerLocator;

    void Awake()
    {
        InitializeDistanceStats();
        InitializePlayerLocator();
    }

    private void InitializeDistanceStats()
    {
        distanceStats = gameObject.GetComponent<BattleShipDistanceStats>();
    }

    private void InitializePlayerLocator()
    {
        playerLocator = gameObject.GetComponent<PlayerLocator>();
    }

    public bool IsInRange()
    {
        return (playerLocator.GetPlayerPosition() - (Vector2)transform.position).magnitude <= distanceStats.GetRange();
    }
}
