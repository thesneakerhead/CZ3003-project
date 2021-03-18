using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorepersec : MonoBehaviour
{
    public Text scoreText;
    public float scoreAmount;
    public float pointIncreased;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        scoreAmount = 0f;
        pointIncreased = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        scoreText.text = $"EnemyScore: {(int)scoreAmount}";
        if (timer > 5f)
        {
            scoreAmount += pointIncreased;
            scoreText.text = scoreText.ToString();
            timer = 0;
        }
       
          
        
    }
}
