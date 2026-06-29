using UnityEngine;

public class LightningWeaponController : ProjectileController, IElementaryWeapon, IWeapon
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

    public Element GetElement()
    {
        return Element.LIGHTNING;
    }
}