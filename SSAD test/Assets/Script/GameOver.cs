using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public int nextSceneLoad;
    public int subSceneLoad;
    public int level;

    void Start()
    {

        subSceneLoad = SceneManager.GetActiveScene().buildIndex;
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        level = PlayerPrefs.GetInt("levelReached", 1);
    }

    

    public void Continue ()
    {
        if (level == 15)
        {
            Debug.Log("YOU WIN GAME");
            PlayerPrefs.DeleteAll();
        }
        else
        {
            if (level % 3 == 0)
            {
                SceneManager.LoadScene(nextSceneLoad);
                level += 1;
            }
            else
            {
                SceneManager.LoadScene(subSceneLoad);
                level += 1;
            }
            

            if (level > PlayerPrefs.GetInt("levelReached"))
            {
                PlayerPrefs.SetInt("levelReached", level);
            }
        }

    }

    public void Quit ()
    {
        SceneManager.LoadScene("Level_select");
    }
}
