using UnityEngine;

public class BurnStats : MonoBehaviour
{
    [SerializeField] private float tickInterval;
    [SerializeField] private float damagePerTick;
    [SerializeField] private float burnDuration;

    public float GetTickInterval() => tickInterval;
    public float GetDamagePerTick() => damagePerTick;
    public float GetBurnDuration() => burnDuration;
}
