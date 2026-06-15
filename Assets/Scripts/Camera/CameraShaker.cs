using System.Collections;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public static CameraShaker Instance;
    [SerializeField] private float shakeDuration;

    void Awake()
    {
        Instance = this;
    }
    public void Shake(float intensity)
    {
        StartCoroutine(ShakeRoutine(intensity));
    }

    private IEnumerator ShakeRoutine(float intensity)
    {
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;

        while (elapsedTime <= shakeDuration)
        {
            Vector2 offset = Random.insideUnitCircle * intensity;

            transform.position = originalPosition + (Vector3)offset;

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
    }
}
