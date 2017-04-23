using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaneSwing : MonoBehaviour {

    public float speed = 5f;
    public int amount = 100;
    GameObject pigeon;
    //Refers to the EnemyHealth script
   EnemyHealth enemyHealth;
    AudioSource enemyAudio;
    public static bool caneAttack = false;
    bool enemyInRange;
    Animator anim;

    void Awake()
    {
        //Locates player on scene start.
        pigeon = GameObject.FindGameObjectWithTag("Enemy");
        //Sets enemy health on start.
        // enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();

    }

   

    //Checks and sees if a enemy is in range of the cane.
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") )
        {
           // Debug.Log("Collided");
            Attack();
            enemyInRange = true;
            Debug.Log("In Range Commander");


        }
        if (other.gameObject == pigeon )
        {
            Debug.Log("Collided #2");
            Attack();
            enemyInRange = true;
            Debug.Log("In Range Commander");

        }
    }

    //Detects if enemy is no longer in the trigger zone.
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == pigeon)
        {
            enemyInRange = false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetButtonDown("Fire1"))
        {
            transform.Rotate(90, 0, 0);
        }
        */
        

        //Checks to see if the player is in range and if it has been enough time since last attack. AND checks if the enemy is still alive by seeing if health is greater than 0. If both are true, enemy attacks.
        if (enemyInRange && Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Ememy Entered hitbox");
			//enemyAudio.Play ();
            Attack();

        }

    }


    void Attack()
    {

        // enemyHealth.TakeDamage2(amount);
        //enemyHealth.currentHealth -= 30;
        caneAttack = true;

        //Debug.Log("Hmmmm");
        enemyHealth.currentHealth -= 25;
        if (enemyHealth.currentHealth > 0)
        {
            Debug.Log("In attack function");
            enemyHealth.TakeDamage2(amount);
            Debug.Log("Enemy should take damage");
            anim.SetTrigger("CaneAttack");
        }
        
    }

}
