using UnityEngine;

public class IceWeaponController : ProjectileController, IElementaryWeapon
{
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

    public void Ultimate()
    {

    }

    public void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon)
    {

    }
}
