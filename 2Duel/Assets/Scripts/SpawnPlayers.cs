using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject playerPrefab;

    //posição de spawn caso a gente vá fazer random mas por enquanto foda-se
    /*public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    */

    
    void Start()
    {
        Vector2 SpawnPosition = new Vector2((float)9.43,(float)-2.33);
        PhotonNetwork.Instantiate(playerPrefab.name,SpawnPosition, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
