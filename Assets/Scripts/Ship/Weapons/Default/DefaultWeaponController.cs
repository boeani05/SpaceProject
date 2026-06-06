using UnityEngine;

public class DefaultWeaponController : ProjectileController
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
}
