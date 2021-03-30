using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject alexis;
    public GameObject chubs;
    public GameObject john;
    public GameObject gameCanvas;
    public GameObject sceneCamera;
    public Text pingText;
    public string selection;
    private GameObject sel;
    private GameObject character;
    float random;
    private void Awake()
    {

        sel = GameObject.Find("SelectedCharacter");
        SelectedCharacter s = sel.GetComponent<SelectedCharacter>();
        this.selection = s.selection;

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
        switch (this.selection)
        {
            case "alexis":
                Debug.Log("Spawn Player");
                random = Random.Range(-1f, 1f);
                PhotonNetwork.Instantiate(alexis.name, new Vector2(0, 0), Quaternion.identity, 0);

                gameCanvas.SetActive(false);
                sceneCamera.SetActive(true);

                break;

            case "chubs":
                Debug.Log("Spawn Player");
                random = Random.Range(-1f, 1f);
                PhotonNetwork.Instantiate(chubs.name, new Vector2(0, 0), Quaternion.identity, 0);
                gameCanvas.SetActive(false);
                sceneCamera.SetActive(true);
                //character = Instantiate(chubs) as GameObject;
                // character.transform.position = new Vector2(0f, 0f);
                break;
            case "john":
                Debug.Log("Spawn Player");
                random = Random.Range(-1f, 1f);
                PhotonNetwork.Instantiate(john.name, new Vector2(0, 0), Quaternion.identity, 0);
                gameCanvas.SetActive(false);
                sceneCamera.SetActive(true);
                //character = Instantiate(john) as GameObject;
                //character.transform.position = new Vector2(0f, 0f);
                break;
                //  }

        }

    }
}
   