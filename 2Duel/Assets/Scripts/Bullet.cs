using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public float timeHealth;
    public float speed;

    public GameObject bullet;
    public Transform attackPoint;
    public LayerMask layerEnemy;

    [System.Obsolete("CreateBullet(bool isFacingRight) is deprecated, please use CreateBullet() instead.")]
    public void CreateBullet(bool isFacingRight)
    {
        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
        if (isFacingRight)
        {
            rigidbody2d.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigidbody2d.velocity = new Vector2(-speed, 0);
        }
        Destroy(gameObject, timeHealth);
    }

    public void CreateBullet()
    {
        Rigidbody2D rigidbody2d = GetComponent<Rigidbody2D>();
        gameObject.SetActive(true);
        rigidbody2d.AddForce(transform.right * speed);
        Invoke("DisableBullet", timeHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("acertou hit no " + collision.name + " e tirou " + damage + " de dano");
            collision.GetComponent<HealthDmg>().takeDamage(damage);
            DisableBullet();
        }
        if (collision.CompareTag("Ground"))
        {
            DisableBullet();
        }

        if (collision.CompareTag("Wall"))
        {
            DisableBullet();
        }
    }

    private void DisableBullet()
    {
        gameObject.SetActive(false);
    }
}
