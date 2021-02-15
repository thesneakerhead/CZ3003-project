﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public GameObject heart;
    public Text QuestionTxt;
    private int numCorrect = 0;
    public Text ScoreTxt;

    // Start is called before the first frame update
    void Start()
    {
        heart.SetActive(false);
        generateQuestion();
    }

    void Update()
    {
        ScoreTxt.text = numCorrect + "/" + QnA.Count;
        if (currentQuestion >= QnA.Count)
        {
            QuestionTxt.text = "Completed";
            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetActive(false);
            }

        }

    }
    public void correct()
    {
        heart.SetActive(true);
        Debug.Log("heart active");
        numCorrect++;
        currentQuestion++;
        if (currentQuestion < QnA.Count)
         {
             //QnA.RemoveAt(currentQuestion);  
             generateQuestion();
         }       
    }

    public void wrong()
    {
        currentQuestion++;
        if (currentQuestion < QnA.Count)
        {
            //QnA.RemoveAt(currentQuestion);
            generateQuestion();
        }
    }
    
    void generateQuestion()
    {
        heart.SetActive(false);
        //currentQuestion = Random.Range(0, QnA.Count);
        QuestionTxt.text = QnA[currentQuestion].Questions;

        SetAnswers();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Answer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<Answer>().isCorrect = true;
            }
        }
    }
}
