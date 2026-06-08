using System;
using System.Collections;
using UnityEngine;

public class FireWeaponController : WeaponController, IElementaryWeapon
{
    [SerializeField] private GameObject explosionPrefab;
    private FireRangedCombatStats combatStats;

    void Awake()
    {
        base.Awake();
        InitializeCombatStats();
    }

    private void InitializeCombatStats()
    {
        combatStats = gameObject.GetComponent<FireRangedCombatStats>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Ranged();
    }

    public void Melee() { }

    public void Ranged() => Shoot();

    private void Shoot()
    {
        Vector2 currentMousePosition = CalculateMousePosition();
        StartCoroutine(FireSequence(currentMousePosition));
    }

    private IEnumerator FireSequence(Vector2 mousePosition)
    {
        yield return new WaitForSeconds(combatStats.GetExplosionDelay());
        GameObject explosion = SpawnExplosion(mousePosition);
        yield return new WaitForSeconds(combatStats.GetExplosionVisibleDelay());
        Destroy(explosion);
    }

    private GameObject SpawnExplosion(Vector2 position)
    {
        return Instantiate(explosionPrefab, position, Quaternion.identity);
    }

    public void Ultimate() { }
    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon) { }
}