using System;
using System.Collections;
using UnityEngine;

public class FireWeaponController : WeaponController, IElementaryWeapon
{
    [SerializeField] private GameObject explosionPrefab;

    private FireRangedControllerStats stats;

    void Awake()
    {
        base.Awake();

        InitializeStats();
    }

    private void InitializeStats()
    {
        stats = gameObject.GetComponent<FireRangedControllerStats>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Ranged();
    }

    public void Melee() { }

    public void Ranged() 
    {
        Shoot();
    } 

    private void Shoot()
    {
        Vector2 mousePosition = CalculateMousePosition();
        StartCoroutine(StartExplosion(mousePosition));
    }

    private IEnumerator StartExplosion(Vector2 mousePosition)
    {
        yield return new WaitForSeconds(stats.GetExplosionDelay());
        SpawnExplosion(mousePosition);
    }

    private void SpawnExplosion(Vector2 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }

    public void Ultimate() { }
    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon) { }
}