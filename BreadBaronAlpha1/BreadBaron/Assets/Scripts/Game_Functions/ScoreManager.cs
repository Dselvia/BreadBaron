using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    //Static belongs to class itself not just instance. ScoreManagerType.score
    public static int score;
    public static int multiplier;
    public static int finalScore;
    WallDropScript wallDropScript;

    
    Text text;

    void Awake()
    {
        //Gets the reference to the text.
        text = GetComponent<Text>();
        //Brings the score to 0 at the start of a game.
        score = 0;
    } 

    void FixedUpdate()
    {
        //Writes Score and places the updated value after the word.
        text.text = "Score: " + score;

        //Multiplies score by Multiplier.
        //finalScore = score * multiplier;


    }


}
