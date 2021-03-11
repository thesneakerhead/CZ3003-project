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
        gameCanvas.SetActive(true);
    }

    public void Update()
    {
        pingText.text = "Ping:" + PhotonNetwork.GetPing();
        
    }

    public void spawnPlayer()
    {
        float random = Random.Range(-1f, 1f);
        PhotonNetwork.Instantiate(player.name, new Vector2(this.transform.position.x * random, this.transform.position.y * random), Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        sceneCamera.SetActive(true);
    }
}
