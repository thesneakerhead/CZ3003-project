using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAndAnswer
{
    public string Questions;
    public string[] Answers;
    public int CorrectAnswer;

    public QuestionAndAnswer(string question, string[] answers, int correctAns)
    {
        Questions = question;
        Answers = answers;
        CorrectAnswer = correctAns;
    }
}