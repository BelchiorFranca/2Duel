using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;

public class MultiplayerMenu : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    public InputField createInput;
    public InputField joinInput;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateGameButton()
    {

    }

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby();
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

    public override void OnJoinedRoom()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
