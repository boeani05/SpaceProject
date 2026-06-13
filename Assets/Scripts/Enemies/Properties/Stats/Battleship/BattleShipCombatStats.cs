using UnityEngine;

public class BattleShipCombatStats : MonoBehaviour
{
    [SerializeField] private float cooldown;

    public float GetCooldown() => cooldown;
}
