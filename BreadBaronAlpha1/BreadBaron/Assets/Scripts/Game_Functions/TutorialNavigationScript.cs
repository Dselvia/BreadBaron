using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialNavigationScript : MonoBehaviour
{


    public void OnStartGame()
    {
        // GameObject MenuChoice = GameObject.Find("MenuScript");
        // TimerScript timerScript = MenuChoice.GetComponent<TimerScript>();
        // timerScript = GetComponent<TimerScript>();
        //if(timerScript.levelOneDone==false)
        SceneManager.LoadScene("Level1");
        // else if (timerScript.levelOneDone == true)
        //SceneManager.LoadScene("Level2");


        Debug.Log("Starting The Game.");
    }

    public void Proceed1()
    {
        Time.timeScale = 0.0f;
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("HomeScreen");
        Debug.Log("Taking you home");
    }

    public void Proceed2()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Taking you to the main menu");
    }
    public void Proceed3()
    {
        SceneManager.LoadScene("ComicNarrative1");
    }
    public void Proceed4()
    {
        SceneManager.LoadScene("Cinematic Level");
    }
    public void Proceed5()
    {
        SceneManager.LoadScene("TutorialScreen");
    }
    public void Proceed6()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
}
