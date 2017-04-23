using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TimerScriptLevel2 : MonoBehaviour
{
    float timeLeft = 150.0f;

    public Text text;





    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left:  " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {

            SceneManager.LoadScene("ComicNarrative3");

        }

    }
}
