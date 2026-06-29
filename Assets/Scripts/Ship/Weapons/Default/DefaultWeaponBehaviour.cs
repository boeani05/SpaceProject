using Unity.VisualScripting;
using UnityEngine;

public class DefaultWeaponBehaviour : ProjectileBehaviour
{
    protected override Element GetProjectileElement()
    {
        return Element.STANDARD;
    }
}