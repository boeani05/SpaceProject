using UnityEngine;

public interface IBurnable
{
    void ApplyBurn(float tickInterval, float damagePerTick, float burnDuration);
}
