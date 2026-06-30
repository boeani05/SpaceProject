using UnityEngine;

public class BaseBlackHoleStats : MonoBehaviour
{
    [SerializeField] private float radiusOfPull;
    [SerializeField] private float duration;
    [SerializeField] private float pullForce;
    [SerializeField] private float tickInterval;

    public float GetRadiusOfPull() => radiusOfPull;
    public float GetDuration() => duration;
    public float GetPullForce() => pullForce;
    public float GetTickInterval() => tickInterval;
}
