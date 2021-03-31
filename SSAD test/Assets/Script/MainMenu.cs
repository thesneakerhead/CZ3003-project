using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string versionName = "0.2";
    public bool isMultiplayer = false;
    // Start is called before the first frame update
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        PhotonNetwork.ConnectUsingSettings(versionName);
    }
    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }
    public void singlePlayer()
    {
        isMultiplayer = false;
        PhotonNetwork.LoadLevel("ChooseCharacters");
    }
    public void multiPlayer()
    {
        isMultiplayer = true;
        PhotonNetwork.LoadLevel("Multiplayer");
    }
    

}
