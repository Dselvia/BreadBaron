using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    //This is what the enemy moves towards.
    Transform player;
    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    public int currentWallHealth=2;
    GameObject DentureMine;
    public UnityEngine.AI.NavMeshAgent agent;
    WallDropScript wallDropScript;
    float timer;
    float stunTimer = .09f;
    float tempSpeed;
    Stun stun;

    //Finds the player. Transform updates where the player is.
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stun = GetComponent<Stun>();
        tempSpeed = agent.speed;
    }

    //Track the player and head towards them.
    void Update()
    {
        timer += Time.deltaTime;
        stunTimer -= Time.deltaTime;
        //Checks to see if the player is still alive.
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            agent.SetDestination(player.position);
        }
         else if (stun.timerUp == true)
        {
            Debug.Log(tempSpeed);
            agent.speed = tempSpeed;
        }
        else
        {
            agent.enabled = false;
        }
        
        


    }
    void OnTriggerEnter(Collider other)
    {
        {
           
            if (other.gameObject.CompareTag("Stun"))
            {

                agent.speed = 0;


            }
            else
                agent.speed = tempSpeed;
            
        }

    }


    /*public void DamageWall(int amount)
    {

        currentWallHealth = currentWallHealth - amount;

        //Locates where the object was hit and moves the particle effect to that location

        {
            if (currentWallHealth <= 0)
            {

                DentureMine.gameObject.SetActive(false);


            }
        }
    }*/
}
    



   
