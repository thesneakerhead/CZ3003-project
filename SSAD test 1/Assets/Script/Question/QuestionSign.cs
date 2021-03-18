using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionSign : MonoBehaviour
{
    public AbstractQuizManager quizManager;
    public GameObject Event;
    public GameObject[] options;
    public GameObject[] animObj;
    private Animator[] anim;
    //public Text dialogText;
    //public string dialog;
    public bool playerInRange;
    public int correct;

    void Start()
    {
        anim = new Animator[animObj.Length];
    }

    // Update is called once per frame
    void Update()
    {
        correct = quizManager.getNumCorrect();
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange) //if player near sign and press spacebar
        {
            if (Event.activeInHierarchy) //if dialog box already active, disable dialog
            {
                Event.SetActive(false);
                for (int i = 0; i < options.Length; i++)
                {
                    options[i].SetActive(false);
                }
            }
            else                            //if dialog box is not active, enable dialog box
            {
                Event.SetActive(true);

                for (int i = 0; i < options.Length; i++)
                {
                    options[i].SetActive(true);
                }
                restartQuiz(quizManager);
                //dialogText.text = dialog;
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  //if sign's box collider collides with player's box collider (entering)
        {
            playerInRange = true;
            //Debug.Log("Player in range");
            restartQuiz(quizManager);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) //if sign's box collider collides with player's box collider (exiting)
        {
            playerInRange = false;
            //Debug.Log("Player left range");
            Event.SetActive(false);
            for (int i = 0; i < options.Length; i++)
            {
                options[i].SetActive(false);
            }
        }
    }

    public void restartQuiz(AbstractQuizManager quizManager)
    {
        //Debug.Log("correct = " + correct);
        //Debug.Log("qna = " + quizManager.QnA.Count);
        //if not all questions correct, restart quiz and animation
        if (correct < quizManager.QnA.Count)
        {
            //restart animation
            for (int i = 0; i < animObj.Length; i++)
            {
                anim[i] = animObj[i].GetComponent<Animator>();
                anim[i].Play("default");
                anim[i].Play("default"+i);
            }
            //restart quiz
            quizManager.setNumCorrect(0);
            quizManager.currentQuestion = 0;
            quizManager.generateQuestion();
        }
    }
}
