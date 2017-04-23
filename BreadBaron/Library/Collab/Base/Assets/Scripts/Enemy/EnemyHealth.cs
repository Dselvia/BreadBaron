using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth;
    //sinkSpeed is how fast the enemies fall through the floor after death.
    public float sinkSpeed = .5f;
    //Score needs adjustments per enemy.
    public int scoreValue = 10;
    //Score multiplies by two. Add behavior for when MultiplierTimesTwoPickUp is obtained by player.
    //public int doubleScore = scoreValue * 2; | Tabbed because not working code and so we can use the scene.
    public AudioClip deathClip;

    public GameObject PowerUp;
    public GameObject CookiePickUp;
     //public GameObject Buff;
    public GameObject[] items;
    public int polaroidDamageAmount = 25;
    public int ShotgunDamageAmount = 150;
     public buffScript buffScript;
    CaneSwing caneSwing;
    float timer = 3f;

    Animator anim;
    AudioSource enemyAudio;
    ParticleSystem hitParticles;
    CapsuleCollider capsuleCollider;
    Text text;
    public static int score;
    bool isDead;
    bool isSinking;
    public float deathAnimTimer =5.0f;
    public bool deathAnimating = false;
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        //Locates the particle sysytem that was assigned to each perfab as a child.
        hitParticles = GetComponentInChildren<ParticleSystem>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        caneSwing = GetComponent<CaneSwing>();
        currentHealth = startingHealth;
        
        //GameObject buff = GameObject.Find("buff");
        //buffScript buffscript = buff.GetComponent<buffScript>();
    }

    //Checks if the enemy is supposed to sink or not. If isDead == True then sink.

    void Update()
    {

        items = new GameObject[3];
        items[0] = GameObject.FindGameObjectWithTag("Pick Up");
        items[1] = GameObject.FindGameObjectWithTag("PowerUp");
        items[2] = GameObject.FindGameObjectWithTag("Buff");
     
        if (deathAnimating == true)
        {
            deathAnimTimer -= Time.deltaTime;
            if (deathAnimTimer < 0)
            {
                gameObject.SetActive(false);
                deathAnimTimer = 5.0f;
            }
        }




        if (isSinking== true)
        {
            //Moves in the negative up direction. IE down. Moves the body down per second instead of frame by using deltatime again.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }

    }

    //int amount is how much damage is taken. Hitpoint will locate position that the enemy is hit and emit particles from location.
    public void TakeDamage (int amount , Vector3 hitPoint)
    {
        //If enemy is dead. Exit function.
        if (isDead)
            return;

        enemyAudio.Play();
        //Subtract damage from current health.
        currentHealth -= amount;

        //Locates where the object was hit and moves the particle effect to that location.
       //hitParticles.transform.position = hitPoint;
        hitParticles.Play();
        if (currentHealth < 50)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (currentHealth <= 0)
        {
            Death();
            ScoreManager.score += scoreValue;
            text.text = "Score: " + score;
            Debug.Log("Score should be updated");
            
        
        }

        //if(currentHealth <= 0)
       // { }
    }

    //For MELEE DAMAGE
    public void TakeDamage2(int amount)
    {
        Debug.Log("Congrats you finally got into the fucking function");
        //If enemy is dead. Exit function.
        if (isDead)
            return;
       
        enemyAudio.Play();
        //Subtract damage from current health.
        currentHealth -= amount;
        if (currentHealth < 50)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }

        if (currentHealth <= 0)
        {
            Death();
            ScoreManager.score += scoreValue;
            text.text = "Score: " + score;
            Debug.Log("Score should be updated");
        }
    }

    public void MeleeDamage()
    {
        if(CaneSwing.caneAttack == true)
        {
            Debug.Log("Maybe it will work");
            Death();
            
        }
    }

    void Death()
    {
        
        isDead = true;
        //Enemy becomes a trigger so that Grandma(player) can move through the body.
        capsuleCollider.isTrigger = true;

        anim.SetTrigger("Dead");

       enemyAudio.clip = deathClip;

        enemyAudio.Play();
        deathAnimating = true;
        OnDeath();
        isSinking = true;
        //gameObject.SetActive(false);
    }

    void OnDeath()
    {
        Instantiate(items[UnityEngine.Random.Range(0, 2)], transform.position, transform.rotation);
      
    }

    //Animation Event. Starts on enemy Death. Needs to be messed with still in Unity to work.
    public void StartSinking()
    {
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        isSinking = true;

        //Adds the score vaue for each enemy killed. Works for different enemy score types since scoreValue is a public variable at the top of the script. 
        ScoreManager.score += scoreValue;

        Destroy(gameObject, 2f);
    }
    void OnTriggerEnter(Collider other)
    {

        //destory on collide

        if (other.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Is this how this works");

            // Debug.Log("Polaroid Shot");
            if (buffScript.damageItem == false)
            {
                //WORKING ENEMIES MASTER BUILD


                // hitParticles.Play();
                currentHealth -= polaroidDamageAmount;
                other.gameObject.SetActive(false);

            }

        }
        else if (other.gameObject.CompareTag("Projectile2"))
        {
            Debug.Log("Pleassseesdf");

            // Debug.Log("Polaroid Shot");
            if (buffScript.damageItem == false)
            {
                //WORKING ENEMIES MASTER BUILD


                // hitParticles.Play();
                Debug.Log("Pleassseesdf");
                currentHealth -= 80;
                other.gameObject.SetActive(false);

            }
        }
        else if (buffScript.damageItem == true)
        {


            //hitParticles.Play();
            currentHealth -= (1000);
            other.gameObject.SetActive(false);

        
            
                //currentHealth -= 1000;
                   // other.gameObject.SetActive(false);
            
        }
        else if (other.gameObject.CompareTag("Cane")  && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Should be colliding with the cane");
            currentHealth -= 300;
            bool cane = true;
            //Assigns to specific name "IsWalking" that we made in the animator.
            anim.SetBool("CaneAttack", cane);
            Debug.Log("Ran cane animation");

        }
        
        if (currentHealth < 50)
        {
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (currentHealth <= 0)
        {
            Death();
            ScoreManager.score += scoreValue;
            text.text = "Score: " + score;
            //Debug.Log("Score should be updated");


        }
    }



}
