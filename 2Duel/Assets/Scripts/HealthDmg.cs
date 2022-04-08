using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDmg : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
  /*  void Update()
    {
        
    }
    */

    public void takeDamage (int damage){
        currentHealth -= damage;

        // animação levando lapada 

        if(currentHealth <=0){
            Death();
        }
    }

    void Death(){

        Debug.Log("Player2 abatido");
    }
}
