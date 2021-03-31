using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScorescript : MonoBehaviour

{
    public int scoreValue = 0;
    Text pscore;

    public AbstractQuizManager MCQ1;
    public AbstractQuizManager MCQ2;
    public AbstractQuizManager MCQ3;
    public AbstractQuizManager SAQ1;
    public AbstractQuizManager SAQ2;

    private int MCQ1Score = 0;
    private int MCQ2Score = 0;
    private int MCQ3Score = 0;
    private int SAQ1Score = 0;
    private int SAQ2Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        pscore = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MCQ1.completed == true)
        {
            if (MCQ1Score == 3)
            {
                // do nothing
            }
            else
            {
                scoreValue += 3;
                MCQ1Score += 3;
            }
        }

        if (MCQ2.completed == true)
        {
            if (MCQ2Score == 3)
            {
                // do nothing
            }
            else
            {
                scoreValue += 3;
                MCQ2Score += 3;
            }
        }
        if (MCQ3.completed == true)
        {
            if (MCQ3Score == 3)
            {
                // do nothing
            }
            else
            {
                scoreValue += 3;
                MCQ3Score += 3;
            }
        }
        if (SAQ1.completed == true)
        {
            if (SAQ1Score == 3)
            {
                // do nothing
            }
            else
            {
                scoreValue += 3;
                SAQ1Score += 3;
            }
        }
        if (SAQ2.completed == true)
        {
            if (SAQ2Score == 3)
            {
                // do nothing
            }
            else
            {
                scoreValue += 3;
                SAQ2Score += 3;
            }
        }
        pscore.text = $"PlayerScore: {scoreValue}";

    }
}
