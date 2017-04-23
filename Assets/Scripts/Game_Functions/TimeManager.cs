using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

    //How much time is slowed down.
    public float slowdownFactor = .05f;
    //How long the slow down occurs.
    public float slowdownLength = 2f;


    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

    }

    void Slow()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            DoSlowmotion();
            Debug.Log("SlowMo activated");
        }
    }

    public void DoSlowmotion()
    {
        //timeScale determines how time is passing. 1 is normal speed.
        Time.timeScale = slowdownFactor;
        // 1 divided by .05 is 20. Moving 20 times slower.
        Time.fixedDeltaTime = Time.timeScale * .02f;
    }



}
