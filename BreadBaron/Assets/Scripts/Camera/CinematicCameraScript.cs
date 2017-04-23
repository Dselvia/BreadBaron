using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicCameraScript : MonoBehaviour {

    // Use this for initialization
    public Camera[] cameras;
    private int activeCamera = 0;
    private int counter = 0;
    public float timer;
    void Start()
    {
        counter = cameras.Length;
        Switch(0);
        timer = 5.0f;
        
    }

		
	
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;

        if (timer < 0) 
        {
            Debug.Log("Next Cam");
            //Camera1.GetComponent<Camera>();
            activeCamera++;
            if (activeCamera == counter)
                activeCamera = 0;
            timer = 5.0f;
            Switch(activeCamera);
        }
            
        }


    void Switch(int activeCamera)
    {
        for(int i = 0; i<counter; i++)
        {
            if(i != activeCamera)
            {
                cameras[i].enabled = false;
            }
            else
            {
                cameras[i].enabled = true;
            }
        }
    }
    }

