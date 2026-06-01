using UnityEngine;

public interface IElementaryWeapon
{
    void Melee();
    void Ranged();
    void Ultimate();
    void CombineWithElementaryWeapon(IElementaryWeapon elementaryWeapon);
}
