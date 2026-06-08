using UnityEngine;

public class LightningRangedBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayer;

    private LightningRangedCombatStats combatStats;
    private Camera mainCamera;
    private LineRenderer lineRenderer;
    private Vector2 rayDirection;
    private RaycastHit2D lightningRay;

    void Awake()
    {
        InitializeCombatStats();
        InitializeLineRenderer();
        InitializeMainCamera();
        InitializeRayDirection();
        InitializeLightningRay();
        DealDamage(lightningRay.collider);
        Destroy(gameObject, combatStats.GetRayVisible());
    }

    private void InitializeCombatStats()
    {
        combatStats = gameObject.GetComponent<LightningRangedCombatStats>();
    }
    private void InitializeMainCamera()
    {
        mainCamera = Camera.main;
    }

    private void InitializeLineRenderer()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
    }

    private void InitializeRayDirection()
    {
        rayDirection = (CalculateMousePosition() - (Vector2)transform.position).normalized;
    }

    private void InitializeLightningRay()
    {
        lightningRay = Physics2D.Raycast(transform.position, rayDirection, combatStats.GetMaxDistanceOfRay(), enemyLayer);

        Vector2 endPoint = lightningRay.collider != null
            ? lightningRay.point
            : (Vector2)transform.position + rayDirection * combatStats.GetMaxDistanceOfRay();

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, endPoint);
    }

    private Vector2 CalculateMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void DealDamage(Collider2D collision)
    {
        if (collision != null)
        {
            collision.gameObject.GetComponent<IDamageable>()?.ApplyDamage(combatStats.GetDamage());

            if (Random.Range(0f, 1f) < combatStats.GetParalyzeChance() / 100)
            {
                collision.gameObject.GetComponent<IParalyzable>()?.Paralyze(combatStats.GetParalyzeDuration());
            }
        }
    }
}
