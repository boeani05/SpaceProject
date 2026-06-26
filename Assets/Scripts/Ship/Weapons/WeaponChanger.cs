using System;
using UnityEngine;

public class WeaponChanger : MonoBehaviour
{
    [SerializeField] private MonoBehaviour[] allWeapons;

    private IWeapon[] weapons;

    private int currentWeaponIndex;

    void Awake()
    {
        InitializeWeapons();

        currentWeaponIndex = 0;
    }

    private void InitializeWeapons()
    {
        weapons = Array.ConvertAll(allWeapons, weapon => weapon as IWeapon);
    }

    public void Switch(int index)
    {
        currentWeaponIndex = index;
        DeactivateAllWeapons();

        (weapons[index] as MonoBehaviour)?.gameObject.SetActive(true);
    }

    private void DeactivateAllWeapons()
    {
        foreach (IWeapon weapon in weapons)
        {
            (weapon as MonoBehaviour)?.gameObject.SetActive(false);
        }
    }

    public void NextWeapon()
    {
        DeactivateAllWeapons();

        currentWeaponIndex = (currentWeaponIndex + 1) % weapons.Length;

        (weapons[currentWeaponIndex] as MonoBehaviour)?.gameObject.SetActive(true);
    }

    public void PreviousWeapon()
    {
        DeactivateAllWeapons();

        currentWeaponIndex = (currentWeaponIndex - 1 + weapons.Length) % weapons.Length;

        (weapons[currentWeaponIndex] as MonoBehaviour)?.gameObject.SetActive(true);
    }
}
