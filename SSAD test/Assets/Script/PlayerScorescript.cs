using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScorescript : MonoBehaviour

{
    public static int scoreValue = 0;
    Text pscore;
    // Start is called before the first frame update
    void Start()
    {
        pscore = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pscore.text = $"PlayerScore: {scoreValue}";
        
    }
}
