using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDmg : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public HealthBehavior Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        Healthbar.SetHealth(currentHealth,maxHealth);
    }

    // Update is called once per frame
  /*  void Update()
    {
        
    }
    */

    public void takeDamage (int damage){
        currentHealth -= damage;
        Healthbar.SetHealth(currentHealth,maxHealth);

        // animação levando lapada 

        if(currentHealth <=0){
            Death();
            Destroy(gameObject);
        }
    }

    void Death(){

        Debug.Log("Player2 abatido");
    }
}
