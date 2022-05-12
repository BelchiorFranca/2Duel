using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float timeHealth;
    public float speed;

    public AudioClip clip;
    public AudioSource Source;

    public GameObject bullet;
    public Transform attackPoint;
    public LayerMask layerEnemy;

    public void CreateBullet()
    {
        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        rigidbody2d.AddForce(transform.right * speed);
        Invoke(nameof(DisableBullet), timeHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log($"Acertou hit no {collision.name} e tirou {damage} de dano");
            collision.GetComponent<HealthDmg>().takeDamage(damage);
            DisableBulletAndCancelInvoke();
        }
        else if (collision.CompareTag("Ground"))
        {
            DisableBulletAndCancelInvoke();
        }
        else if (collision.CompareTag("Wall"))
        {
            DisableBulletAndCancelInvoke();
        }
    }

    private void DisableBulletAndCancelInvoke()
    {
        CancelInvoke(nameof(DisableBullet));
        DisableBullet();
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
