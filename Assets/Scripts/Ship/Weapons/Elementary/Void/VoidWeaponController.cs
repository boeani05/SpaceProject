using System;
using UnityEngine;

public class VoidWeaponController : WeaponController, IElementaryWeapon
{
    [SerializeField] private GameObject blackHolePrefab;

    void Awake()
    {
        base.Awake();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
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
        
    }
}