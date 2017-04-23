using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour {

    public void OnStartGame()
    {
        SceneManager.LoadScene("VerticalSlice");
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

}
