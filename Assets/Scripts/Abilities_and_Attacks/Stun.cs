using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stun : MonoBehaviour {

    public GameObject StunAbil;
     EnemyMovement enemyMovement;
    Transform player;
    public int stunsLeft = 3;
    public bool stunDisabled = false;
    public Text stunText;
    public bool timerUp;
    public Renderer rend;
    public Collider coll;
    bool stunUsed1 = false;
    bool stunUsed2 = false;
    bool stunUsed3 = false;
    bool stunUsed4 = false;

    public float timer = 15.0f;
    // Use this for initialization
    void Start () {
        setStunText();
    }

    // Update is called once per frame
    void Update()
    {
        addStun();
        timer -= Time.deltaTime;
        //Debug.Log(timer);
        if (Input.GetButtonDown("Jump") && stunsLeft >= 1 && timerUp == false)
        {
           
            Instantiate(StunAbil, transform.position, transform.rotation);
            //StartTimer();
            stunsLeft--;
            setStunText();
           
            
           // Debug.Log(timer);
            
            // setWallText();
        }
        if (timer <= 0 && timerUp == false)
        {
           // Debug.Log("Timer up");
            if (this.gameObject.CompareTag("Stun"))
            {
                stunDisabled = true;
                timerUp = true;
                //StunAbil.gameObject.SetActive(false);
                rend = GetComponent<Renderer>();
                rend.enabled = false;
                coll = GetComponent<Collider>();
                coll.enabled = false;


            }
        }

        }
    public void StartTimer()
    {
        //timer -= Time.deltaTime;
    }
    void setStunText()
    {
        //stunText.text = stunCount.ToString();
        stunText.text = "Stun Count: " + stunsLeft.ToString(); //+ stun.stunsLeft.ToString();
    }
    public void addStun()
    {
        if (ScoreManager.score >= 100 && ScoreManager.score < 200 && stunUsed1 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
            //Debug.Log(scoreAdded);
            stunUsed1 = true;
            stunsLeft++;
        }

        if (ScoreManager.score >= 100 && ScoreManager.score < 200 && stunUsed1 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
            //Debug.Log(scoreAdded);
            stunUsed1 = true;
            stunsLeft++;
        }

        if (ScoreManager.score >= 200 && ScoreManager.score < 400 && stunUsed2 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
           // Debug.Log(scoreAdded);
            stunUsed2 = true;
            stunsLeft++;
        }



        if (ScoreManager.score >= 400 && ScoreManager.score < 800 && stunUsed3 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
          // Debug.Log(scoreAdded);
            stunUsed3 = true;
            stunsLeft++;
        }

        if (ScoreManager.score >= 800 && ScoreManager.score < 1600 && stunUsed4 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
           // Debug.Log(scoreAdded);
            stunUsed4 = true;
            stunsLeft++;
        }



    }
}
