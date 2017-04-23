using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreScript : MonoBehaviour
{

    // public PolaroidProjectile polaroidProjectile;
    public GameObject damageOn;
    //public EnemyHealth enemyHealth;
    public bool scoreItem;
    public float timer = 5.0f;
    float time;
    public bool startTimer;
    public bool timerUp = false;
    public bool qPressed = false;
    // public Text buffText;
    public Renderer rend;
    bool objDestroyed;
    bool hasPlayed = false;
    //public GameObject empty;
    // public GameObject AttBuff;
    // public GameObject DefBuff;
    public GameObject ScoreBuff;
    // public GameObject DashBuff;

    public bool attBuffOn;
    public AudioSource BuffAudio;
	public ParticleSystem ps;


    // private IEnumerator coroutine;

    void Start()
    {
        //enemyHealth = GetComponent<EnemyHealth>();
    }

    void FixedUpdate()
    {
        //setBuffAlert();
        //Debug.Log("wtf");

        if (startTimer == true)
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
                timerUp = true;
            if (timerUp == true)
            {
                ScoreBuff.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }



    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {


            GameObject damageOn = GameObject.Find("damageOn");

            //playerHealth.currentHealth = 100;
            scoreItem = true;
            //BuffAudio.Play ();
            //NoDamage();


            Debug.Log("Stuff worked");
            // Debug.Log(damageItem);
            //polaroidProjectile.damageBuffed = true;
            objDestroyed = true;
            if (objDestroyed == true)
            {
                rend = GetComponent<Renderer>();
                this.rend.enabled = false;
            }
            if (scoreItem == true && timerUp == false)
            {
                Debug.Log("Should show thing");
                ScoreBuff.SetActive(true);

            }
            if (scoreItem == true)
            {
                startTimer = true;
                Debug.Log("did it do this?");
            }

            //setBuffAlert();
			Destroy (ps);
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