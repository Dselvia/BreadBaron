using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    
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

    public void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        //SceneManager.LoadScene("HomeScreen");
        Debug.Log("Taking you home");
    }

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Taking you to the main menu");
    }
    public void OnComicView()
    {
        SceneManager.LoadScene("ComicNarrative1");
    }
    public void OnCinematicView()
    {
        SceneManager.LoadScene("Cinematic Level");
    }
    public void OnTutorialView()
    {
        SceneManager.LoadScene("TutorialScreen");
    }
    public void OnCreditsView()
    {
        SceneManager.LoadScene("CreditsScreen");
    }
}
