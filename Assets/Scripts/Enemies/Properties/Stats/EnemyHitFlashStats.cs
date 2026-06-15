using UnityEngine;

public class EnemyHitFlashStats : MonoBehaviour
{
    [SerializeField] private float flashDuration;

    public float GetFlashDuration() => flashDuration;
}
