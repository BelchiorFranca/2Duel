using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDmg = 30;
    public float FireRate;
    float ReadyForNextShot;

    private Weapon weapon;
    [SerializeField]
    private WeaponCategory weaponCategory;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject hand;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(Time.time > ReadyForNextShot){
                ReadyForNextShot = Time.time +1/FireRate;
                Attack();
            }
        }
    }

    void Attack()
    {
        switch (weaponCategory)
        {
            case WeaponCategory.Blade:
                animator.SetTrigger("Attack");
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("acertou hit no " + enemy.name + "e tirou " + attackDmg + " de dano");
                    enemy.GetComponent<HealthDmg>().takeDamage(attackDmg);
                }
                break;
            case WeaponCategory.Fire:
                GameObject bulletWeapon = null;
                switch (weapon)
                {
                    case Weapon.Pistol:
                        bulletWeapon = BulletObjectPool.SharedInstance.GetPistol();
                        break;
                    case Weapon.Uzi:
                        bulletWeapon = BulletObjectPool.SharedInstance.GetUzi();
                        break;
                    case Weapon.Rifle:
                        bulletWeapon = BulletObjectPool.SharedInstance.GetRifle();
                        break;
                }

                if (bulletWeapon != null)
                {
                    bulletWeapon.transform.position = attackPoint.transform.position;
                    bulletWeapon.transform.rotation = attackPoint.transform.rotation;
                    bulletWeapon.GetComponent<Bullet>().CreateBullet();
                }
                break;
        }
    }

    public void SetBulletPrefabs(GameObject bulletPrefabs)
    {
        bullet = bulletPrefabs;
    }

    public void SetWeaponCategory(WeaponCategory weaponCategory)
    {
        this.weaponCategory = weaponCategory;
    }

    public void ChangeSpriteArm(Sprite newHoldingWeapon)
    {
        hand.GetComponent<SpriteRenderer>().sprite = newHoldingWeapon;
    }

    public void ChangeWeappon(Weapon newHoldingWeapon)
    {
        weapon = newHoldingWeapon;
    }
}
