using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public PlayerHealth playerHealth;
    //reference to enemy prefab
    public GameObject enemy;
    //Spawn Timer
    public float spawnTime = 3f;
    //Array that holfs apwn points.
    public Transform[] spawnPoints;

    void Start()
    {
        //Waits 3 seconds to start spawning and then waits 3 seconds to spawn again.
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        //If player is still alive. Spawn another enemy.
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //Picks a spawn point and then spawns an enemy at that locaton.
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        //creates a spawn. Places it in the level using instantiate. Thing to spawn, where to spawn, and what location to have on spawn.
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }


}
