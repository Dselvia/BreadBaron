using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallDropScript : MonoBehaviour
{
    public AudioSource mineAudio;
    public AudioClip BreadWallAudio;
    public GameObject DentureMine;
    ParticleSystem hitParticles;
    RaycastHit mineHit;
    public int mineDamage = 1000;
    public float spawnTime = 3f;
    float timer;
    public float timeBetweenMines = .2f;
   // public int initialWallCount = 3;
    public int wallCount=3;
    public Text wallText;
    public bool wallAdded = false;
    public Stun stun;
    int scoreAdded;
    int wallsUsed;
    bool wallUsed1 = false;
    bool wallUsed2 = false;
    bool wallUsed3 = false;
    bool wallUsed4 = false;
    public int startingWallHealth = 100;
    public int currentWallHealth;


    // Use this for initialization
    void Start()
    {
        currentWallHealth = startingWallHealth;
        setWallText();
        scoreAdded = ScoreManager.score;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButtonDown("Fire2")&& wallCount>0)
        {
            Instantiate(DentureMine, transform.position , transform.rotation);
            mineAudio.Play ();
            Debug.Log("Made a wall");
            wallsUsed++;
            //initialWallCount--;
            setWallText();
            wallCount--;
        }
        
        addWall();
    
    }
    public void WallDeath()
    {

        /*//destory on collide
        if (other.gameObject.CompareTag("Enemy"))
        {

            DamageWall(5);
        }
    }

    public void DamageWall(int amount)
    {
        
        currentWallHealth = currentWallHealth - amount;

        //Locates where the object was hit and moves the particle effect to that location

        {
            if (currentWallHealth <= 0)
            {
            */
              DentureMine.gameObject.SetActive(false);
                

            }
    void setWallText()
    {
        //wallText.text = wallCount.ToString();
        wallText.text = "Wall Count : " + wallCount.ToString() ; //+ stun.stunsLeft.ToString();
    }
    public void addWall()
    {
        if (ScoreManager.score >= 100  && ScoreManager.score <200&&wallUsed1 == false)
        {


            
            //wallAdded = true;
           // scoreAdded = ScoreManager.score / 100;
            Debug.Log(scoreAdded);
            wallUsed1 = true;
            wallCount++;
        }

        if (ScoreManager.score >= 100 && ScoreManager.score < 200 && wallUsed1 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
            Debug.Log(scoreAdded);
            wallUsed1 = true;
            wallCount++;
        }

        if (ScoreManager.score >= 200 && ScoreManager.score < 400 && wallUsed2 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
            Debug.Log(scoreAdded);
            wallUsed2 = true;
            wallCount++;
        }

        

        if (ScoreManager.score >= 400 && ScoreManager.score < 800 && wallUsed3 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
            Debug.Log(scoreAdded);
            wallUsed3 = true;
            wallCount++;
        }

        if (ScoreManager.score >= 800 && ScoreManager.score < 1600 && wallUsed4 == false)
        {



            //wallAdded = true;
            // scoreAdded = ScoreManager.score / 100;
            Debug.Log(scoreAdded);
            wallUsed4 = true;
            wallCount++;
        }

        

    }

}
    


    