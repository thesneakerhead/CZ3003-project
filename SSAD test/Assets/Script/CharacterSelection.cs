﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Hashtable = ExitGames.Client.Photon.Hashtable;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public SelectedCharacter sel;
    private Hashtable playerProperties = new Hashtable();
    public GameObject[] playerText;
    public GameObject[] readyText;
    public GameObject startButton;
    private bool readyState = false;

    public void Start()
    {
        PhotonNetwork.automaticallySyncScene = true;
        playerProperties.Add("PlayerReady", readyState);
        playerProperties.Add("SelCharacter", null);
        PhotonNetwork.player.SetCustomProperties(playerProperties);
       

    }
    public void Update()
    {
        if (allPlayersReady() && PhotonNetwork.isMasterClient)
        {
            startButton.SetActive(true);
        }
        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
        {
            playerText[i].SetActive(true);
            Debug.Log(PhotonNetwork.player.ID);
            if ((bool)PhotonNetwork.playerList[i].CustomProperties["PlayerReady"])
            {
                readyText[PhotonNetwork.playerList[i].ID - 1].SetActive(true);
            }
            else
            {
                readyText[PhotonNetwork.playerList[i].ID - 1].SetActive(false);
            }
        }
    }
    public void aPress()
    {
        sel.selection = "alexis";
        playerProperties["SelCharacter"]="alexis";
        PhotonNetwork.player.SetCustomProperties(playerProperties);
        
    }
    public void cPress()
    {
        sel.selection = "chubs";
        playerProperties["SelCharacter"] = "chubs";
        PhotonNetwork.player.SetCustomProperties(playerProperties);
    }
    public void jPress()
    {
        sel.selection = "john";
        playerProperties["SelCharacter"] = "john";
        PhotonNetwork.player.SetCustomProperties(playerProperties);
    }
    public void startGame()
    {
        if (PhotonNetwork.isMasterClient)
        {
            Debug.Log("load level");
            PhotonNetwork.LoadLevel("map1");
        }
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
