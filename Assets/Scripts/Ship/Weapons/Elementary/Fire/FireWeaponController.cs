using System;
using System.Collections;
using UnityEngine;

public class FireWeaponController : MonoBehaviour, IElementaryWeapon
{
    [SerializeField] private float explosionDelay;
    [SerializeField] private float explosionVisibleDelay;
    [SerializeField] private GameObject explosionPrefab;

    private Camera mainCamera;

    void Awake()
    {
        InitializeMainCamera();
    }

    private void InitializeMainCamera()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ranged();
        }
    }
    
    public void Melee()
    {
        
    }

    public void Ranged()
    {
        Vector2 currentMousePosition = CalculateMousePosition();
        StartCoroutine(FireSequence(currentMousePosition));
    }

    private Vector2 CalculateMousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private IEnumerator FireSequence(Vector2 mousePosition)
    {
        yield return new WaitForSeconds(explosionDelay);
        GameObject explosion = SpawnExplosion(mousePosition);
        yield return new WaitForSeconds(explosionVisibleDelay);
        Destroy(explosion);
    }

    private GameObject SpawnExplosion(Vector2 position)
    {
        return Instantiate(explosionPrefab, position, Quaternion.identity);
    }
    public void Ultimate()
    {
        
    }

    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon)
    {
        
    }
}
