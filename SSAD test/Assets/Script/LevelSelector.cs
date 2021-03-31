using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public GameObject Master;
    public GameObject Client;
    public Button[] levelButtons;
    private void Awake()
    {
        if(PhotonNetwork.isMasterClient)
        {
            Master.SetActive(true);
            Client.SetActive(false);
        }
        else
        {
            Master.SetActive(false);
            Client.SetActive(true);
        }
    }
    void Start()
    {
        if(PhotonNetwork.isMasterClient)
        { int levelReached = PlayerPrefs.GetInt("levelReached", 1);
        Debug.Log(PlayerPrefs.GetInt("levelReached"));
        Debug.Log(levelReached);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
        }
        }
    }
    public void backButton()
    {
        PhotonNetwork.LoadLevel("Main Menu");
    }
    public void Select(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
