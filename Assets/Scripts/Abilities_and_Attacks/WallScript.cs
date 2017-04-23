using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public int startingWallHealth = 100;
    public float timeBetweenAttacks = 0.7f;
    public int currentWallHealth;
    public GameObject DentureMine;
    float timer;
    bool wallAttacked = false;
    int timesAttacked;

    void Update()
    {
        currentWallHealth = startingWallHealth;
        if (wallAttacked == false)
        {
            
        }
        if (timer < timeBetweenAttacks && wallAttacked == true)
        {
            DamageWall(25*timesAttacked);
            timer = 0;
        }
    }
    void OnTriggerEnter(Collider other)
    {

        //destory on collide
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            //Debug.Log("Boom2222");
            wallAttacked = true;
            timesAttacked++;
        }
    }

    public void DamageWall(int amount)
    {

        currentWallHealth = currentWallHealth - amount;

        //Locates where the object was hit and moves the particle effect to that location

        {
            if (currentWallHealth < 750 && currentWallHealth > 499)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
            }
            if (currentWallHealth < 500 && currentWallHealth > 249)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            if (currentWallHealth < 250 && currentWallHealth > 0)
            {
                this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
            if (currentWallHealth <= 0 )
            {

                DentureMine.gameObject.SetActive(false);


            }
        }
    }
   
}



