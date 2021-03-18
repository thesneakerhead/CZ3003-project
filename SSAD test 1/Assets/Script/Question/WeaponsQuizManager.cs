using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsQuizManager : AbstractQuizManager
{
    /*public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    private int numCorrect = 0;
    public Text ScoreTxt;*/

    // Start is called before the first frame update
    void Start()
    {
        generateQuestion();
    }

    void Update()
    {
        ScoreTxt.text = numCorrect + "/" + QnA.Count;
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
            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetActive(false);
            }

        }

    }
    /*public void correct()
    {
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
    
    public void generateQuestion()
    {
        //currentQuestion = Random.Range(0, QnA.Count);
        Debug.Log(currentQuestion);
        QuestionTxt.text = QnA[currentQuestion].Questions;

        SetAnswers();
    }
    */
    public override void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<WeaponAnswer>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                options[i].GetComponent<WeaponAnswer>().isCorrect = true;
            }
        }
    }
    
    /*public int getNumCorrect()
    {
        return numCorrect;
    }
    public void setNumCorrect(int num)
    {
        numCorrect = num;
    }*/
}
