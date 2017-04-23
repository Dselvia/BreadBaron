using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolaroidProjectile : MonoBehaviour {

    public int damagePerShot = 25;
    public float timeBetweenBullets = 0.15f;
    EnemyHealth enemyHealth;
    public AudioSource gunAudio;
	public AudioClip something;
    public bool damageBuffed= false;
    //Timer keeps things in synch.
    float timer;

    //Polaroid Emitter game object.
    public GameObject Polaroid_Emitter;

    public GameObject gma;
    public Animator anim;

    //Polaroid Prefab.
    public GameObject BreadBaron_Polaroid;

    //Polaroid Speed.
    public float Polaroid_Forward_Force=700f;

	// Update is called once per frame
	void Update () {

        timer += Time.deltaTime;
        
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            AnimatedThrow();
			gunAudio.Play();
            timer = 0f;
            //Instantiate the Polaroid.
            GameObject Tempoarary_Polaroid_Handler;

            if (damageBuffed == true)
            {
               // damagePerShot = damagePerShot * 2;
                timeBetweenBullets = .075f;
            }
            else if(damageBuffed== false)
            {
                timeBetweenBullets = .15f;
            }
            Tempoarary_Polaroid_Handler = Instantiate(BreadBaron_Polaroid, Polaroid_Emitter.transform.position, Polaroid_Emitter.transform.rotation) as GameObject;
           

            //Rotation adjustment for Polaroid projectile happens here.
            //Might be able to remove this line.
            Tempoarary_Polaroid_Handler.transform.Rotate(Vector3.left * 90);
   
            //Retrieve the Rigidbody component from the instantiated Bullet and control it. 
            Rigidbody Temporary_RigidBody;
  
            Temporary_RigidBody = Tempoarary_Polaroid_Handler.GetComponent<Rigidbody>();

            //Tells Polaroid to move forward based on Polaroid_Forward_Force.
         
            Temporary_RigidBody.AddForce(transform.forward * Polaroid_Forward_Force);
 
            //Destroy bullets after 3 seconds.
            Destroy(Tempoarary_Polaroid_Handler, 3.0f);
           
            gunAudio.PlayOneShot (something);
        }
        AnimatedThrowEnd();
	}

    public void AnimatedThrow()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim.SetBool("isThrowing", true);
    }

    public void AnimatedThrowEnd()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim.SetBool("isThrowing", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           // Debug.Log("Cjhhjollided");
            
            // Destroy(collision.gameObject);
            //Debug.Log("In Range Commander");

            if (enemyHealth != null)
            {

                //enemyHealth.TakeDamage(damagePerShot);
                //enemyHealth.currentHealth = enemyHealth.currentHealth - damagePerShot;
                Debug.Log("Shouldve taken damage");
            }
        }
    }
    
}
