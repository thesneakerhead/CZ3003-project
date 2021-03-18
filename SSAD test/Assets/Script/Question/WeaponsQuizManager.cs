using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsQuizManager : AbstractQuizManager
{
    public List<QuestionAndAnswer> QnA1;
    /*public List<QuestionAndAnswer> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public Text QuestionTxt;
    private int numCorrect = 0;
    public Text ScoreTxt;*/
    public Toggle[] toggle;
    public ToggleGroup toggleGroup;
    public QuestionAndAnswer[] questions = new QuestionAndAnswer[4];

    // Start is called before the first frame update
    void Start()
    {
        questions[0]= new QuestionAndAnswer("Choose A", new string[4] { "A", "B", "C", "D" }, 0);
        questions[1] = new QuestionAndAnswer("Choose B", new string[4] { "A", "B", "C", "D" }, 1);
        questions[2] = new QuestionAndAnswer("Choose C", new string[4] { "A", "B", "C", "D" }, 2);
        questions[3] = new QuestionAndAnswer("Choose D", new string[4] { "A", "B", "C", "D" }, 3);
        for(int i =0;i<4;i++)
        {
            QnA.Add(questions[i]);
        }
        //QnA1.Add(questions);
        Debug.Log(QnA.Count);
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
        else
        {
            //SetAnswers();
            checkAns();
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
    public void checkAns()
    {
        int correct = QnA[currentQuestion].CorrectAnswer;
        for (int i = 0; i < toggle.Length; i++)
        {
            if (toggle[correct].isOn)
                options[0].GetComponent<WeaponAnswer>().isCorrect = true;
            else if(!toggle[correct].isOn)
                options[0].GetComponent<WeaponAnswer>().isCorrect = false;
        }

    }
    

    public override void SetAnswers()
    {
        
        options[0].GetComponent<WeaponAnswer>().isCorrect = false;
        for (int i = 0; i < toggle.Length; i++)
        {
            toggle[i].transform.GetChild(1).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];            
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
