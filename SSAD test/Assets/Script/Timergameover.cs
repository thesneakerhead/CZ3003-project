using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timergameover : MonoBehaviour
{
    public int countDownStartValue;
    public Text timerUI;
    public Text finalText;

    public float enemyscore;
    public float playerscore;

    public Text PlayerScore;
    private PlayerScorescript playerScoreScript;
    public GameObject EnemyScore;
    private Scorepersec enemyScoreScript;

    public GameObject gameOverUI;

    //public int currentTime;
    // Start is called before the first frame update
    void Start()
    {
        countDownTimer();
        // Find the Scorepersec script attached to "EnemyScore"
        enemyScoreScript = EnemyScore.GetComponent<Scorepersec>();
        // Find the PlayerScorescript attached to "PlayerScore"
        playerScoreScript = PlayerScore.GetComponent<PlayerScorescript>();

 
    }
    
    void Update()
    {
        playerscore = playerScoreScript.scoreValue;
        enemyscore = enemyScoreScript.scoreAmount;
    }

    void countDownTimer()
    {
        //currentTime = countDownStartValue;
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue);
            timerUI.text = "Timer: " + spanTime.Minutes + " : " + spanTime.Seconds;
            
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f);

            if (enemyscore == 15)
            {
                finalText.text = "You lost! Enemy Wins! Select RETRY";
                countDownStartValue = 0;
                gameOverUI.SetActive(true);
            }

            if (playerscore == 15)
            {
                finalText.text = "Player Wins! Select CONTINUE";
                countDownStartValue = 0;
                gameOverUI.SetActive(true);
            }

        }
        else
        {
            
            if (enemyscore > playerscore)
            {
                finalText.text = "You lost! Enemy Wins! Select RETRY";
                gameOverUI.SetActive(true);
            }
            else if (playerscore > enemyscore)
            {
                finalText.text = "Player Wins! Select CONTINUE";
                gameOverUI.SetActive(true);
            }
            else
            {
                finalText.text = "It's a draw! Select CONTINUE";
                gameOverUI.SetActive(true);
            }


        }
        
    }

    //endGame(userID, substageID, finalPscore)
    //{
      //  substageId = 1;
        //userID = 1;
        //finalPscore = playerscore;
        //return;
    //}

}
