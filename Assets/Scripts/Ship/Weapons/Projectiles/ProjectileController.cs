using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float offsetInPercent;

    private Vector2 currentDistanceToMouse;
    private Vector2 offsetOfProjectile;
    private GameObject newProjectile;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        SetCurrentDistanceToMouse();

            SetOffsetOfProjectile();
            
            SetNewProjectile();

            DeliverDistanceToProjectile();
    }

    private void SetCurrentDistanceToMouse()
    {
        currentDistanceToMouse = CalculateNormalizedDistanceToMouse();
    }

    private Vector2 CalculateNormalizedDistanceToMouse()
    {
        return (ConvertMousePositionToWorldSpace() - GetPositionOfGameObject()).normalized;
    }

    private Vector2 ConvertMousePositionToWorldSpace()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 GetPositionOfGameObject()
    {
        return (Vector2) transform.position;
    }

    private void SetOffsetOfProjectile()
    {
        offsetOfProjectile = CalculateOffsetOfProjectile();
    }

    private Vector2 CalculateOffsetOfProjectile()
    {
        return currentDistanceToMouse * (offsetInPercent / 100);
    }

    private void SetNewProjectile()
    {
        newProjectile = Instantiate(projectilePrefab, GetPositionOfGameObject() + offsetOfProjectile, Quaternion.identity);
    }

    private void DeliverDistanceToProjectile()
    {
        newProjectile.GetComponent<ProjectileBehaviour>().SetDistanceToMouse(currentDistanceToMouse);
    }
}
