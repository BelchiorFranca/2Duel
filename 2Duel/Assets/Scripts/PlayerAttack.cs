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

    public WeaponCategory weaponCategory;
    public GameObject bullet;
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
        
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
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
                GameObject bulletWeapon = Instantiate(bullet,attackPoint.position,attackPoint.rotation);
                bulletWeapon.GetComponent<Rigidbody2D>().AddForce(bulletWeapon.transform.right * 1200);
                bulletWeapon.transform.position = attackPoint.transform.position;
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
}
