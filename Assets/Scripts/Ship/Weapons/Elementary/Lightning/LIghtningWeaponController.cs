using UnityEngine;

public class LIghtningWeaponController : MonoBehaviour, IElementaryWeapon
{
    [SerializeField] private GameObject lightningPrefab;
    [SerializeField] private float offsetInPercent;
    private Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Melee()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ranged();
        }
    }

    public void Ranged()
    {
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(lightningPrefab, CalculateProjectileSpawningPosition(CalculateShootingDirection()), Quaternion.identity);
    }

    private Vector2 CalculateShootingDirection()
    {
        return ((Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position).normalized;
    }

    private Vector2 CalculateProjectileSpawningPosition(Vector2 directionFacing)
    {
        return (Vector2)transform.position + directionFacing * (offsetInPercent / 100f);
    }

    public void Ultimate()
    {

    }

    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon)
    {

    }
}
