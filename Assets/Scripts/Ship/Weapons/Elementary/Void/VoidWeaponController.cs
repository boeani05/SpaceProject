using System;
using UnityEngine;

public class VoidWeaponController : WeaponController, IElementaryWeapon, IWeapon
{
    [SerializeField] private GameObject blackHolePrefab;

    private VoidCombinedWeapons voidCombinedWeapons;

    private GameObject combinationPrefab;

    void Awake()
    {
        base.Awake();

        voidCombinedWeapons = gameObject.GetComponent<VoidCombinedWeapons>();
        combinationPrefab = null;
    }

    void Update()
    {
        if(combinationPrefab != null && Input.GetMouseButtonDown(0))
        {
            Instantiate(combinationPrefab, CalculateMousePosition(), Quaternion.identity);
            combinationPrefab = null;
        } else if(Input.GetMouseButtonDown(0))
        {
            Ranged();
        }
    }

    public void Melee()
    {
        
    }

    public void Ranged()
    {
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(blackHolePrefab, CalculateMousePosition(), Quaternion.identity);
    }

    public void Ultimate()
    {
        
    }

    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon)
    {
        combinationPrefab = voidCombinedWeapons.GetCombinationPrefab(elementaryWeapon.GetElement());
    }

    public Element GetElement()
    {
        return Element.VOID;
    }

    void OnDisable()
    {
        combinationPrefab = null;
    }
}