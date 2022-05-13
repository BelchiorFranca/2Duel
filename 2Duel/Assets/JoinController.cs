using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
          if(manager.playerCount == 1){
            StartCoroutine(Win());
          }
      }
        
    }

    private IEnumerator Win (){
      Debug.Log("yaay o cara venceu");
      yield return new WaitForSeconds(3);
      SceneManager.LoadScene("MainMenu");

    }
}
