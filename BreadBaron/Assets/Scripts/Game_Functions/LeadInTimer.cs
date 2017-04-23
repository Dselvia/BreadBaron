using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeadInTimer : MonoBehaviour {

    public float CountDownVar;
    public Text CountdownText;
	// Use this for initialization
	void Start () {
        if (CountdownText == null)
            Debug.Log("Whatcha doin son?!");		
	}
	
	// Update is called once per frame
	void Update () {
        
        float time = CountDownVar - Time.timeSinceLevelLoad;
        CountdownText.text = "Pigeons Spawn in: " + time.ToString("0");

        if (time <= 0f)
        {
            TimeUp();
        }

	}
    void TimeUp()
    {
        Destroy(gameObject);
    }
}
