using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoinController : MonoBehaviour
{
    // Start is called before the first frame update
     public PlayerInputManager manager;
     public HealthDmg player;
     float timer = 0.0f;
     private int seconds;
    
    void Start()
    {
      manager = GetComponent<PlayerInputManager>();
     // player = GetComponent<HealthDmg>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
      if(timer>10){
          manager.DisableJoining();
      }
        
    }
}
