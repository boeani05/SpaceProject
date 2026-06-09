using UnityEngine;

public class FireRangedControllerStats : MonoBehaviour
{
    [SerializeField] private float explosionDelay;

    public float GetExplosionDelay() => explosionDelay;
}
