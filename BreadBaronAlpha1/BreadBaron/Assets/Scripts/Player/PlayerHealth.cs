using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    //Health at start.
    public int startingHealth = 100;
    public float currentHealth;
    //may need to be HealthUI
    public Slider healthSlider;
    public Slider healthSliderExtra;
    //Red flash that appears when player takes damage.
    public Image damageImage;
    public AudioClip deathClip;
    //How quickly the death image appears on screen.
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public bool healthBuffed = false;
    public bool levelOneCheckpoint;
    public TimerScript timerScript;
    Time time;
    float timer= 4f;
	public bool playEmit = false;

    Animator anim;
    AudioSource playerAudio;
    //Refers to player Movement script I wrote for the player.
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
	public ParticleSystem ps;

    //bools are used to determine if something is TRUE or FALSE
    bool isDead;
    bool damaged;
	bool hasPlayed = false;


    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponentInChildren<PlayerShooting>();
        //Sets current health to MAX VALUE at game start.
        currentHealth = startingHealth;
		ps = GetComponent<ParticleSystem> ();
    }

    void Update()
    {
        if(isDead == true)
            timer -= Time.deltaTime;
        // Debug.Log(timer);
        if (timer <= 0f)
            if (Application.loadedLevelName == "Level1") 
                SceneManager.LoadScene("LoseGame");
            else if (Application.loadedLevelName == "Level2") 
                SceneManager.LoadScene("CheckpointScreen");
        
        if (damaged)
        {
            damageImage.color = flashColor;
        }
        else
        {
            //Lerp moves from the flashcolor to invisible again in a smooth transition.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed = Time.deltaTime);
        }
        damaged = false;
        
    }


    //int amount is how much damage the player has taken.
    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        healthSlider.value = currentHealth;

        //Slider adjusts with current health. This is established by values put on slider in editor.
        playerAudio.Play();

       /* if(currentHealth > 100)
        {
            healthSliderExtra.enabled = true;
            healthSliderExtra.maxValue = 1000;
        }
        */

        if(currentHealth <= 0 && isDead== false)
        {
            
            Death();
        }
		ps.Play ();
		//playEmit = false;

    }


    void Death()
    {
        isDead = true;
        Debug.Log("Should die");
        //playerShooting.DisableEffects();
        
        //Activates the death animation for the character.
        anim.SetTrigger("Die");
        
		if(hasPlayed == false){
			playerAudio.clip = deathClip;
			hasPlayed = true;
		}
       	

        //Player is no longer able to move. 
        playerMovement.enabled = false;

        // playerShooting.enabled = false;
        
        
    }

}
