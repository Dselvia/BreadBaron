using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunScript : MonoBehaviour
{

    public int damagePerShot = 80;
    public float timeBetweenBullets = 0.9f;
    EnemyHealth enemyHealth;
    public AudioSource gunAudio;
    public AudioClip something;
    public bool damageBuffed = false;
    //Timer keeps things in synch.
    float timer;

	//public ParticleSystem ps;
    //Polaroid Emitter game object.
    public GameObject maceParticle;
    public GameObject ShotgunProjectile;

    public GameObject Grandma;
    public Animator anim;

    //Polaroid Prefab.
    public GameObject BreadBaron_Polaroid;
    int shotgunNum;

    //Polaroid Speed.
    public float Polaroid_Forward_Force = 50f;

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (damageBuffed == true)
        {
            // damagePerShot = damagePerShot * 2;
            timeBetweenBullets = .45f;
        }
        else if (damageBuffed == false)
        {
            timeBetweenBullets = .9f;
        }

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            shotgunNum = Random.Range(2, 6);
            AnimatedThrow();
            //gunAudio.Play();
            timer = 0f;
            //Instantiate the Polaroid.
            GameObject Tempoarary_Polaroid_Handler;
            GameObject Tempoarary_Polaroid_Handler2;
            GameObject Tempoarary_Polaroid_Handler3;
            GameObject Tempoarary_Polaroid_Handler4;
            GameObject Tempoarary_Polaroid_Handler5;
            Rigidbody Temporary_RigidBody;
            Rigidbody Temporary_RigidBody2;
            Rigidbody Temporary_RigidBody3;
            Rigidbody Temporary_RigidBody4;
            Rigidbody Temporary_RigidBody5;
            if (shotgunNum == 2)
            {
                Tempoarary_Polaroid_Handler = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler2 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;

                Tempoarary_Polaroid_Handler.transform.Rotate(Vector3.left * 90);
                Tempoarary_Polaroid_Handler2.transform.Rotate(Vector3.right * 45);

                Temporary_RigidBody = Tempoarary_Polaroid_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody2 = Tempoarary_Polaroid_Handler2.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody2.AddForce(transform.forward * Polaroid_Forward_Force);
                

                Destroy(Tempoarary_Polaroid_Handler, .75f);
                Destroy(Tempoarary_Polaroid_Handler2, .65f);
                gunAudio.PlayOneShot(something);

            }

            if (shotgunNum == 3)
            {
                Tempoarary_Polaroid_Handler = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler2 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler3 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;

                Tempoarary_Polaroid_Handler.transform.Rotate(Vector3.left * 90);
                Tempoarary_Polaroid_Handler2.transform.Rotate(Vector3.right * 45);
                Tempoarary_Polaroid_Handler3.transform.Rotate(Vector3.left * 45);

                Temporary_RigidBody = Tempoarary_Polaroid_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody2 = Tempoarary_Polaroid_Handler2.GetComponent<Rigidbody>();
                Temporary_RigidBody3 = Tempoarary_Polaroid_Handler3.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody2.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody3.AddForce(transform.forward * Polaroid_Forward_Force);

                Destroy(Tempoarary_Polaroid_Handler, .75f);
                Destroy(Tempoarary_Polaroid_Handler2, .65f);
                Destroy(Tempoarary_Polaroid_Handler3, .65f);
                gunAudio.PlayOneShot(something);

            }

            if (shotgunNum == 4)
            {
                Tempoarary_Polaroid_Handler = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler2 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler3 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler4 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;

                Tempoarary_Polaroid_Handler.transform.Rotate(Vector3.left * 90);
                Tempoarary_Polaroid_Handler2.transform.Rotate(Vector3.right * 45);
                Tempoarary_Polaroid_Handler3.transform.Rotate(Vector3.left * 45);
                Tempoarary_Polaroid_Handler4.transform.Rotate(Vector3.left * 45);

                Temporary_RigidBody = Tempoarary_Polaroid_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody2 = Tempoarary_Polaroid_Handler2.GetComponent<Rigidbody>();
                Temporary_RigidBody3 = Tempoarary_Polaroid_Handler3.GetComponent<Rigidbody>();
                Temporary_RigidBody4 = Tempoarary_Polaroid_Handler4.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody2.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody3.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody4.AddForce(transform.forward * Polaroid_Forward_Force);

                Destroy(Tempoarary_Polaroid_Handler, .75f);
                Destroy(Tempoarary_Polaroid_Handler2, .65f);
                Destroy(Tempoarary_Polaroid_Handler3, .65f);
                Destroy(Tempoarary_Polaroid_Handler4, .65f);
                gunAudio.PlayOneShot(something);

            }
            if (shotgunNum == 5)
            {
                Tempoarary_Polaroid_Handler = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler2 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler3 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler4 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
                Tempoarary_Polaroid_Handler5 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;

                Tempoarary_Polaroid_Handler.transform.Rotate(Vector3.left * 90);
                Tempoarary_Polaroid_Handler2.transform.Rotate(Vector3.right * 45);
                Tempoarary_Polaroid_Handler3.transform.Rotate(Vector3.left * 45);
                Tempoarary_Polaroid_Handler4.transform.Rotate(Vector3.left * 45);
                Tempoarary_Polaroid_Handler5.transform.Rotate(Vector3.left * 45);

                Temporary_RigidBody = Tempoarary_Polaroid_Handler.GetComponent<Rigidbody>();
                Temporary_RigidBody2 = Tempoarary_Polaroid_Handler2.GetComponent<Rigidbody>();
                Temporary_RigidBody3 = Tempoarary_Polaroid_Handler3.GetComponent<Rigidbody>();
                Temporary_RigidBody4 = Tempoarary_Polaroid_Handler4.GetComponent<Rigidbody>();
                Temporary_RigidBody5 = Tempoarary_Polaroid_Handler5.GetComponent<Rigidbody>();

                Temporary_RigidBody.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody2.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody3.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody4.AddForce(transform.forward * Polaroid_Forward_Force);
                Temporary_RigidBody5.AddForce(transform.forward * Polaroid_Forward_Force);

                Destroy(Tempoarary_Polaroid_Handler, .75f);
                Destroy(Tempoarary_Polaroid_Handler2, .65f);
                Destroy(Tempoarary_Polaroid_Handler3, .65f);
                Destroy(Tempoarary_Polaroid_Handler4, .65f);
                Destroy(Tempoarary_Polaroid_Handler5, .65f);
                gunAudio.PlayOneShot(something);

            }
            /*Tempoarary_Polaroid_Handler = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
             Tempoarary_Polaroid_Handler2 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;
             Tempoarary_Polaroid_Handler3 = Instantiate(BreadBaron_Polaroid, ShotgunProjectile.transform.position, ShotgunProjectile.transform.rotation) as GameObject;

            //Rotation adjustment for Polaroid projectile happens here.
            //Might be able to remove this line.
            Tempoarary_Polaroid_Handler.transform.Rotate(Vector3.left * 90);
            Tempoarary_Polaroid_Handler2.transform.Rotate(Vector3.right * 45);
            Tempoarary_Polaroid_Handler3.transform.Rotate(Vector3.left * 40);
            //Retrieve the Rigidbody component from the instantiated Bullet and control it. 
            //Rigidbody Temporary_RigidBody;
            // Rigidbody Temporary_RigidBody2;
           // Rigidbody Temporary_RigidBody3;
            Temporary_RigidBody = Tempoarary_Polaroid_Handler.GetComponent<Rigidbody>();
             Temporary_RigidBody2 = Tempoarary_Polaroid_Handler2.GetComponent<Rigidbody>();
             Temporary_RigidBody3 = Tempoarary_Polaroid_Handler3.GetComponent<Rigidbody>();
            //Tells Polaroid to move forward based on Polaroid_Forward_Force.

            Temporary_RigidBody.AddForce(transform.forward * Polaroid_Forward_Force);
            Temporary_RigidBody2.AddForce(transform.forward * Polaroid_Forward_Force);
            Temporary_RigidBody3.AddForce(transform.forward * Polaroid_Forward_Force);
            //Destroy bullets after 1.5 seconds.
            Destroy(Tempoarary_Polaroid_Handler, .75f);
            Destroy(Tempoarary_Polaroid_Handler2, .65f);
            Destroy(Tempoarary_Polaroid_Handler3, .75f);
            gunAudio.PlayOneShot(something);*/
			
        }
        AnimatedThrowEnd();
    }

    public void AnimatedThrow()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim.SetBool("isThrowing", true);
		//ps.Play ();

    }

    public void AnimatedThrowEnd()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        anim.SetBool("isThrowing", false);
		//ps.Stop ();
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
                enemyHealth.currentHealth = enemyHealth.currentHealth - damagePerShot;
                Debug.Log("Shouldve taken damage");
            }

        }
    }


}
