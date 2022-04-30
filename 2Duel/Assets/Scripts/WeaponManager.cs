using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pistol;
    [SerializeField]
    private GameObject uzi;
    [SerializeField]
    private GameObject rifle;
    [SerializeField]
    private GameObject blade;
    private PlayerAttack playerAttack;
    [SerializeField]
    private Sprite armPistol;
    [SerializeField]
    private Sprite armUzi;
    [SerializeField]
    private Sprite armRifle;
    [SerializeField]
    private Sprite armBlade;

    public Sprite[] spriteArray;

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
            SetWeapon(Weapon.Sword);
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
                playerAttack.ChangeSpriteArm(armBlade);
                break;
            case Weapon.Pistol:
                playerAttack.SetBulletPrefabs(pistol);
                playerAttack.SetWeaponCategory(WeaponCategory.Fire);
                playerAttack.ChangeSpriteArm(armPistol);
                break;
            case Weapon.Uzi:
                playerAttack.SetBulletPrefabs(uzi);
                playerAttack.SetWeaponCategory(WeaponCategory.Fire);
                playerAttack.ChangeSpriteArm(armUzi);
                break;
            case Weapon.Rifle:
                playerAttack.SetBulletPrefabs(rifle);
                playerAttack.SetWeaponCategory(WeaponCategory.Fire);
                playerAttack.ChangeSpriteArm(armRifle);
                break;
        }
        playerAttack.ChangeWeappon(weapon);
    }
}
