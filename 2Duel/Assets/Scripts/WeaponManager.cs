using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject pistol;
    public GameObject uzi;
    public GameObject rifle;
    private PlayerAttack playerAttack;

    private void Awake()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetWeapon(Weapon.Sword);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetWeapon(Weapon.Rifle);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetWeapon(Weapon.Uzi);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(Weapon.Pistol);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeapon(Weapon.Sword);
        }
    }

    public void SetWeapon(Weapon weapon)
    {
        switch (weapon)
        {
            case Weapon.Sword:
                playerAttack.SetBulletPrefabs(null);
                playerAttack.SetWeaponCategory(WeaponCategory.Blade);
                break;
            case Weapon.Pistol:
                playerAttack.SetBulletPrefabs(pistol);
                playerAttack.SetWeaponCategory(WeaponCategory.Fire);
                break;
            case Weapon.Uzi:
                playerAttack.SetBulletPrefabs(uzi);
                playerAttack.SetWeaponCategory(WeaponCategory.Fire);
                break;
            case Weapon.Rifle:
                playerAttack.SetBulletPrefabs(rifle);
                playerAttack.SetWeaponCategory(WeaponCategory.Fire);
                break;
        }
    }
}
