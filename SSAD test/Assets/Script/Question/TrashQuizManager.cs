using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashQuizManager : AbstractQuizManager
{
    public GameObject inputField;
    private string inputAns;

    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    void Update()
    {
        //display score
        ScoreTxt.text = numCorrect + "/" + QnA.Count;
        //display try again/mission completed at end of quiz depending on score
        if (currentQuestion >= QnA.Count)
        {
            if (numCorrect < QnA.Count)
            {
                QuestionTxt.text = "Try Again";
            }
            else
            {
                QuestionTxt.text = "Mission Completed";
                completed = true;
            }
            options[0].SetActive(false);
        }
        else
        {
            //check input for correct answer
            SetAnswers();
        }
    }

    public bool checkAns()
    {
        //check answer with inputfield
        inputAns = inputField.GetComponent<InputField>().text;
        if (inputAns.CompareTo(QnA[currentQuestion].Answers[0]) == 0)
        {
            Debug.Log(inputAns);
            Debug.Log(QnA[currentQuestion].Answers[0]);
            return true;
        }
        return false;
    }

    public override void SetAnswers()
    {
        //if answer correct, set button isCorrect to true
        if (checkAns())
        {
            options[0].GetComponent<TrashAnswer>().isCorrect = true;
        }
        else
        {
            options[0].GetComponent<TrashAnswer>().isCorrect = false;
        }
    }

}
