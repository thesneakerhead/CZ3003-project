using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnswer : AbstractAnswer
{
    private string aimAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = new Animator[animObj.Length];
    }
    public override void playAnimation()
    {
        //play aim animation
        aimAnim = "aim" + quizManager.currentQuestion;
        anim[0] = animObj[0].GetComponent<Animator>();
        anim[0].Play(aimAnim);
        //play rock break animation
        anim[1] = animObj[1].GetComponent<Animator>();
        anim[1].Play("rock break");
    }
}
