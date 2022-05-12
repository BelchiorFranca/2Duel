using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBehavior : MonoBehaviour
{
    private Slider slider;
    public HealthDmg playerHealth;
    public Image fillImage;
    public Color Low;
    public Color High;
    public Vector3 Offset;
    private Transform target;
    private Vector2 Wantedpos;
    public GameObject Player;
    
    
    // Start is called before the first frame update

    // Update is called once per frame
    void Awake() {

        slider= GetComponent<Slider>();
      
        
    }
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(Player.transform.position + Offset);
       
        if(slider.value <= slider.minValue){
            fillImage.enabled = false;
        }
        if(slider.value > slider.minValue && !fillImage.enabled){
            fillImage.enabled = true;
        }
        
        float fillValue = playerHealth.GetComponent<HealthDmg>().currentHealth/playerHealth.GetComponent<HealthDmg>().maxHealth;
        if(fillValue <= slider.maxValue/3){
            fillImage.color = Color.red;
        }
        else if(fillValue > slider.maxValue/3){
            fillImage.color = Color.green;
        }
        slider.value = fillValue;
        
        
    }

    
}
