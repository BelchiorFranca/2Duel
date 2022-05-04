using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;

public class MultiplayerMenu : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public TMP_InputField createInput;
    public TMP_InputField joinInput;

    
    
  /*  void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    */

    public void CreateGameButton()
    {

    }


    public void JoinGameButton()
    {
        
    }

    public void BackMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);

    }

    public override void OnJoinedRoom(){
        PhotonNetwork.LoadLevel("SampleScene");
    }
    

   
}
