using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class HealthDmg : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField]
    private AudioSource KillSound;
    public AudioClip  Kill;
    public AudioClip bodyHit;
    public Vector3 AudioPos;

   
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        KillSound = GetComponent<AudioSource>();
        AudioPos = new Vector3(0,0,0);
        
        //Healthbar.SetHealth(currentHealth,maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
  

    public void takeDamage (int damage){
        currentHealth -= damage;
        //Healthbar.SetHealth(currentHealth,maxHealth);
       // KillSound.PlayOneShot(bodyHit);
        // animação levando lapada 

        if(currentHealth <=0){
           AudioSource.PlayClipAtPoint(Kill,AudioPos);
            Death();
            
            
        }
    }

    void Death(){
        
        Destroy(gameObject);
        Debug.Log("Player abatido");
       
    }


}
