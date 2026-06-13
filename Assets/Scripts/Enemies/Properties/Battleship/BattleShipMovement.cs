using UnityEngine;

public class BattleShipMovement : BaseEnemyMovement
{
    private BattleShipDistanceChecker distanceChecker;

    protected override void Awake()
    {
        base.Awake();
        InitializeDistanceChecker();
    }

    private void InitializeDistanceChecker()
    {
        distanceChecker = gameObject.GetComponent<BattleShipDistanceChecker>();
    }

    protected override bool ShouldMove() => !distanceChecker.IsInRange();
}
