using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    private WeaponChanger weaponChanger;

    private Dictionary<KeyCode, int> weaponMap;

    void Awake()
    {
        InitializeWeaponChanger();
        InitializeWeaponMap();
    }

    private void InitializeWeaponChanger()
    {
        weaponChanger = gameObject.GetComponent<WeaponChanger>();
    }

    private void InitializeWeaponMap()
    {
        weaponMap = new Dictionary<KeyCode, int>
        {
            { KeyCode.Q, 0 },
            { KeyCode.Alpha1, 1 },
            { KeyCode.Alpha2, 2 },
            { KeyCode.Alpha3, 3 },
            { KeyCode.Alpha4, 4 }
        };
    }

    void Update()
    {
        foreach(KeyCode key in weaponMap.Keys)
        {
            if(Input.GetKeyDown(key))
            {
                weaponChanger.Switch(weaponMap[key]);
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            weaponChanger.NextWeapon();
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            weaponChanger.PreviousWeapon();
        }
    }
}
