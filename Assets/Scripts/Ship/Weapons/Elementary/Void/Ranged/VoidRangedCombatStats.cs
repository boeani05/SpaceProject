using UnityEngine;

public class VoidRangedCombatStats : MonoBehaviour, IDamageSource
{
    [SerializeField] private float damage;
    [SerializeField] private float radiusOfPull;
    [SerializeField] private float duration;
    [SerializeField] private float pullForce;

    public float GetDamage() => damage;
    public float GetRadiusOfPull() => radiusOfPull;
    public float GetDuration() => duration;
    public float GetPullForce() => pullForce;
}
