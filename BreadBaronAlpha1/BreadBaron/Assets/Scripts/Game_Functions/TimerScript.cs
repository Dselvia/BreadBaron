using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
	float timeLeft = 120.0f;
   
	public Text text;
    
   public bool levelOneDone;




	void Update()
	{
		timeLeft -= Time.deltaTime;
		text.text = "Time Left:  " + Mathf.Round(timeLeft);
        if (timeLeft < 0 )
        {
            LevelCompleted(levelOneDone);
            SceneManager.LoadScene("ComicNarrative2");


        }
        
	}
  bool LevelCompleted(bool levelOneDone)
    {
        levelOneDone = true;
        return levelOneDone;
    }
}
