using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LocalGame()
    {
        SceneManager.LoadScene("SampleScene");  
        Debug.Log("bora");

    }
/*
    public void MultiplayerGame()
    {
        SceneManager.LoadScene("MultiplayerMenu");
    }
    */

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}
