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
    private bool isMultiplayer;
    private GameObject mainMenuScript;
    public GameObject displayText;

    private void Awake()
    {
        mainMenuScript = GameObject.Find("MainMenuScript");
        isMultiplayer = mainMenuScript.GetComponent<MainMenu>().isMultiplayer;
        Debug.Log("is multi = " + isMultiplayer);
    }
    public void Start()
    {
        
        PhotonNetwork.automaticallySyncScene = true;
        //playerProperties.Add("PlayerReady", readyState);
        playerProperties.Add("SelCharacter", null);
        PhotonNetwork.player.SetCustomProperties(playerProperties);
        if (isMultiplayer)
        {
            for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
            {
                playerProperties["PlayerReady"] = false;
                PhotonNetwork.player.SetCustomProperties(playerProperties);
            }
        }


    }
    public void Update()
    {
        if (allPlayersReady() && PhotonNetwork.isMasterClient)
        {
            startButton.SetActive(true);
        }
        if (isMultiplayer)
        {
            for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
            {
                playerText[i].SetActive(true);
                //Debug.Log("character selection "+ PhotonNetwork.player.ID);
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
        switch (sel.selection)
        {
            case "alexis":
                displayText.GetComponent<UnityEngine.UI.Text>().text = "Alexis";

                break;

            case "chubs":
                displayText.GetComponent<UnityEngine.UI.Text>().text = "Chubs";

                break;
            case "john":
                displayText.GetComponent<UnityEngine.UI.Text>().text = "John Cena";

                break;
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
        if (!isMultiplayer)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.maxPlayers = 2;
            PhotonNetwork.JoinOrCreateRoom("single", roomOptions, TypedLobby.Default);
            PhotonNetwork.LoadLevel("Level_select");
        }
        else
        {
            if (PhotonNetwork.isMasterClient)
            {
                Debug.Log("load level");

                PhotonNetwork.LoadLevel("Level_select");
            }
            
        }
        
    }
    public void readyClick()
    {
        if (isMultiplayer)
        {
            playerProperties["PlayerReady"] = true;
            PhotonNetwork.player.SetCustomProperties(playerProperties);
        }
        else
            startButton.SetActive(true);

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
