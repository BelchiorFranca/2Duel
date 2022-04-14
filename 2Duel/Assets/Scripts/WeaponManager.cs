using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject pistol;
    public GameObject uzi;
    public GameObject rifle;
    private PlayerAttack playerAttack;
    public Animator animator;

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
            animator.SetBool("Holding_Sword",true);
            animator.SetBool("Holding_Uzi",false);
            SetWeapon(Weapon.Sword);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
           animator.SetBool("Holding_Uzi",true);
           animator.SetBool("Holding_Sword",false);
            SetWeapon(Weapon.Uzi);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetWeapon(Weapon.Pistol);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SetWeapon(Weapon.Rifle);
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
