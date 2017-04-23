using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {



    public enum Weapon
    {
        gun=0,
        cane,
        mace
    };

    //Set damage, bullet speed, and range.
    public int damagePerShot = 25;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;
    public string myWeaponState;
    //public bool damageBuffed = false;



    //Timer keeps things in synch.
    float timer;
    //Ray is the raycast that detects what has been hit. 
    Ray shootRay;
    RaycastHit shootHit;

    //Only can hit shootable things.
    int shootableMask;
    //patricle effects on gun.
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    //How long the effect stays on screen.
    float effectsDisplayTime = 0.2f;

    void Awake()
    {
        //Number on shootable layer.
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
    }

    //Function to check if its time to shoot.
    void Update()
    {
        
        timer += Time.deltaTime;
        //Fire 1 is left mouse button. Makes sure it has been enough time since the last bullet was shot.
        //1 is gun, 2 is cane
        if (Input.GetKeyDown("1")){
            myWeaponState = "gun";
        }
        if (Input.GetKeyDown("2")){
            myWeaponState = "cane";
        }
        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }
        

        //After enough time has passed from a firing of the gun it will turn off.
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }

    }


    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    //Physics function for firing bullet.
    void Shoot()
    {
        //reset timer per bullet.
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        //Ends and restarts particles for each time the gun is shot.
        gunParticles.Stop();
        gunParticles.Play();

        //Turns on line renderer. 
        //Set position is the start of the gun, and start of the line.
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        //Sends the line forward. Straight on the Z axis.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        //out shoothit gives info on what was hit. Range is specified at top. Can only hit things that are shootable. 
        if(Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            //Gets enemy health. Finds where the object was hit.
            EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
              
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
           

            //Ends the line created by the ray. Line ends on where the object was hit. 
            gunLine.SetPosition(1, shootHit.point);
        }

        //Else the line goes until the range and then ends. Range becomes default line end location.
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }

    }

}
