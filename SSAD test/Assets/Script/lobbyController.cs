using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hashtable = ExitGames.Client.Photon.Hashtable;


public class lobbyController : MonoBehaviour
{
    public GameObject startButton;
    private bool readyState = false;
    private Hashtable playerProperties = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        playerProperties.Add("PlayerReady", readyState);
        PhotonNetwork.player.SetCustomProperties(playerProperties);
        Debug.Log((bool)PhotonNetwork.player.CustomProperties["PlayerReady"]);
    }

    // Update is called once per frame
    void Update()
    {

        if (allPlayersReady())
            startButton.SetActive(true);
        Debug.Log((bool)PhotonNetwork.player.CustomProperties["PlayerReady"]);
        Debug.Log("no of players" + PhotonNetwork.playerList.Length);
    }

    public void readyClick()
    {
        playerProperties["PlayerReady"] = true;
        PhotonNetwork.player.SetCustomProperties(playerProperties);
    }

    private bool allPlayersReady()
    {
        {
            foreach (var photonPlayer in PhotonNetwork.playerList)
            {
                //if not all players ready
                if (!(bool)photonPlayer.CustomProperties["PlayerReady"])
                    return false;
            }
            return true;
        }
    }
}
