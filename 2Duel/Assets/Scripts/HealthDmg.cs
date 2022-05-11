using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDmg : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public HealthBehavior Healthbar;
    [SerializeField]
    private AudioSource KillSound;
    public Text healthText;
    public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        //Healthbar.SetHealth(currentHealth,maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        HealthbarFiller();
        
    }
    
    void HealthbarFiller(){
        healthBar.fillAmount = currentHealth/maxHealth;
    }

    public void takeDamage (int damage){
        currentHealth -= damage;
        //Healthbar.SetHealth(currentHealth,maxHealth);

        // animação levando lapada 

        if(currentHealth <=0){
            Death();
            Destroy(gameObject);
        }
    }

    void Death(){
        gameObject.SetActive(false);
        Debug.Log("Player abatido");
        KillSound.Play();
    }


}
