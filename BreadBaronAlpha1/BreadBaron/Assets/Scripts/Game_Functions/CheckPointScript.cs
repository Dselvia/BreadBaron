using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckPointScript : MonoBehaviour
{


    public void OnCheckPoint()
    {
     
        SceneManager.LoadScene("Level2");
        Debug.Log("Checkpoint BABY");
    }

   

    public void OnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Taking you to the main menu");
    }
    public void OnCinematicView()
    {
        SceneManager.LoadScene("CinematicLevel2");
    }
    public void OnGameOver()
    {
        SceneManager.LoadScene("gameOver");
    }
}