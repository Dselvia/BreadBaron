using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidDamage : MonoBehaviour
    {
    EnemyHealth enemyHealth;
    public int damagePerShot = 50;


    void Awake()
    {
        EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Pigeon(clone)")
        {
            Debug.Log("Collided");
            Destroy(collision.gameObject);
            Debug.Log("In Range Commander");
        }
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
           // Debug.Log("Collided PD");
            //Destroy(other.gameObject);
            //newHealth();
            //enemyHealth.TakeDamage(damagePerShot);
            //enemyHealth.TakeDamage2(damagePerShot);
          //  Debug.Log("Please work");
            /* if (enemyHealth != null)
             {

                 enemyHealth.TakeDamage2(damagePerShot);
                 Debug.Log("enemy took polaroid damage! :D");
             }
             */
        }

    }

    void newHealth()
    {
        Debug.Log("Just a test");
        EnemyHealth enemyHealth = GetComponent<EnemyHealth>();
        // enemyHealth.currentHealth -= damagePerShot;
        //enemyHealth.TakeDamage(damagePerShot);
        Debug.Log("enemy took polaroid damage! :D");
    }
}
