using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour {

    public Transform HUD;
    public Transform Player;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetButtonDown("Pause")))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (HUD.gameObject.activeInHierarchy == false)
        {
            HUD.gameObject.SetActive(true);
            
            Time.timeScale = 0;
           Player.GetComponent<PlayerShooting>().enabled = false;
            
            //Cursor.lockState = CursorLockMode.Locked;
           // Cursor.visible = false;
            Debug.Log("Time should have stopped");

            
        }
        else
        {
            HUD.gameObject.SetActive(false);
            Time.timeScale = 1;
            Player.GetComponent<PlayerShooting>().enabled = true;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void Restart()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        Pause();
        Debug.Log("You Restarted");
    }

    public void Quit()
    {
        //Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Taking you home");
    }

}
