using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buffScript : MonoBehaviour
{

    public PolaroidProjectile polaroidProjectile;
    public ShotgunScript shotgunScript;
    public GameObject damageOn;
    public EnemyHealth enemyHealth;
    public bool damageItem = false;
    public float timer = 5.0f;
    Time time;
    public bool timerUp = false;
   
    public Text buffText;
    public Renderer rend;
    bool objDestroyed;
	bool hasPlayed = false;
    public GameObject empty;
    public GameObject AttBuff;
    //public GameObject DefBuff;
    //public GameObject ScoreBuff;
    //public GameObject DashBuff;

    public bool attBuffOn;
    public AudioSource BuffAudio;
	public ParticleSystem ps;
   

    private IEnumerator coroutine;
    
    void Start()
    {
        //enemyHealth = GetComponent<EnemyHealth>();
    }
    
    void Update()
    {
        //setBuffAlert();
        
            
        if (damageItem == true)
        {
            attBuffOn = true;
            AttBuff.SetActive(true);

        }

        if (objDestroyed == true && timerUp == false)
        {
           
            //enemyHealth.polaroidDamageAmount = 1000;
           // polaroidProjectile.timeBetweenBullets = .001f;
            Debug.Log("Were in the poon");
            timer -= Time.deltaTime;
            //Mathf.Round(timer);
            //Debug.Log(timer);
            //Debug.Log("This shit works");
            //StartCoroutine(NoDamage());
            if (timer < 0 && timerUp == false)
            {
                Debug.Log("Timer up");

                enemyHealth.polaroidDamageAmount = 25;
               // polaroidProjectile.timeBetweenBullets = .15f;
                attBuffOn = false;
                polaroidProjectile.damageBuffed = false;
                shotgunScript.damageBuffed = false;
                timer = 5.0f;
                timerUp = true;
                AttBuff.SetActive(false);
                empty.SetActive(true);

                
                
                damageItem = false;
                // playerHealth.healthBuffed = false;
                //setBuffAlert();
            }

        }





    }

  

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {


            GameObject damageOn = GameObject.Find("damageOn");
            
            //playerHealth.currentHealth = 100;
            damageItem = true;
			//BuffAudio.Play ();
            //NoDamage();


            Debug.Log("Stuff worked");
           // Debug.Log(damageItem);
            polaroidProjectile.damageBuffed = true;
            shotgunScript.damageBuffed = true;
            objDestroyed = true;
            if (objDestroyed == true)
            {
                rend = GetComponent<Renderer>();
                this.rend.enabled = false;
            }

            //setBuffAlert();
			Destroy(ps);
        }


    }
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			if (hasPlayed == false) {
				BuffAudio.Play ();
				hasPlayed = true;

			}

		}
	}
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buffScript : MonoBehaviour
{

    public PlayerShooting playerShooting;
    public int buffItem;
    public Text DamageBuff;
    bool buffUsed;
    public float waitTime = 5.0f;

    private IEnumerator coroutine;

    void Start()
    {
        Buff();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {

            Debug.Log("X pressed");
        }
        //setDamageText();

    }

    void setDamageText()
    {
        while (buffItem == 1){
            DamageBuff.text = buffItem.ToString();
            DamageBuff.text = "Damage Buff : On";
        }

    }


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && buffUsed == false)
        {

            GameObject GunBarrelEnd = GameObject.Find("GunBarrelEnd");
            PlayerShooting playerShooting = GunBarrelEnd.GetComponent<PlayerShooting>();
            Buff();
            
            buffItem += 1;
            Debug.Log(playerShooting.damagePerShot);
            if (buffItem == 1)
            {
                Debug.Log(playerShooting.damagePerShot);
                StartCoroutine(Buff());
            }
            //Debug.Log(playerShooting.damagePerShot);
            Debug.Log("5 Seconds later hopefully");

           
        }


    }


    private IEnumerator Buff()
    {
        Debug.Log("bufffffffffff");
        // GameObject.Find("player_test").GetComponent("PlayerHealth").enabled = false;
        playerShooting.damagePerShot += 100;
        Debug.Log("damage up");
        yield return new WaitForSeconds(waitTime);
        Debug.Log("this waited 5 seconds");
        playerShooting.damagePerShot -= 100;
        buffUsed = true; 
    }

}
*/