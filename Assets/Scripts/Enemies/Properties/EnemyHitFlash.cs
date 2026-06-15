using System.Collections;
using UnityEngine;

public class EnemyHitFlash : MonoBehaviour
{
    private EnemyHitFlashStats flashStats;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    void Awake()
    {
        flashStats = gameObject.GetComponent<EnemyHitFlashStats>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void Flash()
    {
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        spriteRenderer.color = Color.white;
        yield return new WaitForSeconds(flashStats.GetFlashDuration());
        spriteRenderer.color = originalColor;
    }
}
