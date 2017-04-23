using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    //Time between attacks and damage. Needs to be adjusted for each enemy.
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    Animator anim;
    GameObject player;
    //Refers to the players health.
    PlayerHealth playerHealth;
    //Refers to the EnemyHealth script
    EnemyHealth enemyHealth;

    bool playerInRange;
    //Timer keeps attacks in synch.
    float timer;


    void Awake()
    {
        //Locates player on scene start.
        player = GameObject.FindGameObjectWithTag("Player");
        //Pull player health off player and store reference.
        playerHealth = player.GetComponent<PlayerHealth>();
        //Sets enemy health on start.
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }


    //When the enemy collides with an object. Checks if the object is a player and if so is in range to attack.
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            //Debug.Log("Does this actually work");
            playerInRange = true;
        }
    }


    //Detects if player is no longer in the trigger zone.
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        //Checks to see if the player is in range and if it has been enough time since last attack. AND checks if the enemy is still alive by seeing if health is greater than 0. If both are true, enemy attacks.
        if(timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0)
        {
            Attack();
        }

        if(playerHealth.currentHealth <= 0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }


    void Attack()
    {
        //timer is reset.
        timer = 0f;

        if(playerHealth.currentHealth >= 0)
        {
           // Debug.Log("Attacking");
            playerHealth.TakeDamage(attackDamage);
        }
    }

}
