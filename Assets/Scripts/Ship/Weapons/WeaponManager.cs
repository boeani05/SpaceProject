    using System;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class WeaponManager : MonoBehaviour
    {

        private WeaponChanger weaponChanger;

        private Dictionary<KeyCode, int> weaponMap;
        private IElementaryWeapon currentWeapon;

        private bool isCombining;

        void Awake()
        {
            weaponChanger = gameObject.GetComponent<WeaponChanger>();
            weaponMap = new Dictionary<KeyCode, int>
            {
                { KeyCode.Q, 0 },
                { KeyCode.Alpha1, 1 },
                { KeyCode.Alpha2, 2 },
                { KeyCode.Alpha3, 3 },
                { KeyCode.Alpha4, 4 }
            };

            isCombining = false;
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                isCombining = true;
                currentWeapon = weaponChanger.GetActiveWeapon();
            }

            if(isCombining)
            {
                foreach(KeyCode key in weaponMap.Keys)
                {
                    if(Input.GetKeyDown(key))
                    {
                        IElementaryWeapon combiningWeapon = weaponChanger.GetWeaponAt(weaponMap[key]);

                        if(combiningWeapon != null && currentWeapon != null)
                        {
                            currentWeapon.CombineWithElementaryWeapon(combiningWeapon);
                        }
                        isCombining = false;
                    }
                }

                if(Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    isCombining = false;
                }
            } else
            {
                foreach (KeyCode key in weaponMap.Keys)
                {
                    if (Input.GetKeyDown(key))
                    {
                        weaponChanger.Switch(weaponMap[key]);
                    }
                }

                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {
                    weaponChanger.NextWeapon();
                }

                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    weaponChanger.PreviousWeapon();
                }
            }
        }
    }
