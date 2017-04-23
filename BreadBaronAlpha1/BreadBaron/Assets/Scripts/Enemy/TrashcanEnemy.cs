using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashcanEnemy : MonoBehaviour {
    //setting it up
    public float attackRate;
    public int attackDamage;

    
    Animator anim;
   GameObject player;
   public   PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool playerInRange;
    float timer;

	// Hi Josh
    // Hi Daniel 
	void Start () {
       player = GameObject.FindGameObjectWithTag("Player");
        //playerHealth = GetComponent<PlayerHealth>();
        //animations
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
		if (playerInRange == true && timer >= attackRate)
        {
            TrashAttack();
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject== player)
        {
            Debug.Log("I wonder if this will work");
            playerInRange = true;
            anim.SetBool("PlayerInRange", playerInRange);
        }

    }
    void OnTriggerExit (Collider coll)
    {
        if (coll.gameObject == player)
        {
            playerInRange = false;
        }

    }

    void TrashAttack()
    {
        Debug.Log("DO you GET here");
        timer = 0f;

        playerHealth.TakeDamage(attackDamage);
        Debug.Log("One last");
        
    }
}
