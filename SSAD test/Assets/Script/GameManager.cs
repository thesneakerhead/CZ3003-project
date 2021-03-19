using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameCanvas;
    public GameObject sceneCamera;
    public Text pingText;

    private void Awake()
    {
        //gameCanvas.SetActive(true);
        //spawnPlayer();
    }
    private void Start()
    {
        Debug.Log("GameManager start");
        spawnPlayer();
    }
    public void Update()
    {
        pingText.text = "Ping:" + PhotonNetwork.GetPing();
        
    }
    public void spawnPlayer()
    {
        Debug.Log("Spawn Player");
        float random = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(player.name, new Vector2(0,0), Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        sceneCamera.SetActive(true);
    }
}
