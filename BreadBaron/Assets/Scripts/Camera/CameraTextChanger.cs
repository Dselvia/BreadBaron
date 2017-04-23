using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraTextChanger : MonoBehaviour {

	// Use this for initialization
    public Text[] texts;
    private int activeText = 0;
    private int counter = 0;
    public float timer;
    void Start()
    {
        counter = texts.Length;
        Switch(0);
        timer = 5.0f;
        
    }

		
	
	
	// Update is called once per frame
	void Update () {
        
        timer -= Time.deltaTime;

        if (timer < 0) 
        {
            Debug.Log("Next Text");
            //Camera1.GetComponent<Camera>();
            activeText++;
            if (activeText == counter)
                activeText = 0;
            timer = 5.0f;
            Switch(activeText);
        }
            
        }


    void Switch(int activeText)
    {
        for(int i = 0; i<counter; i++)
        {
            if(i != activeText)
            {
                texts[i].enabled = false;
            }
            else
            {
                texts[i].enabled = true;
            }
        }
    }
    }

