using UnityEngine;

public class LightningWeaponController : ProjectileController, IElementaryWeapon
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) Ranged();
    }

    public void Melee() { }

    public void Ranged() {
        Shoot();
    } 

    protected override void Shoot()
    {
        Instantiate(GetPrefab(), projectileCalculator.CalculateProjectileSpawningPosition(projectileCalculator.CalculateShootingDirection()), Quaternion.identity);
    }

    public void Ultimate() { }
    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon) { }
}