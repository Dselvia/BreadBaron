using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{

    public PlayerHealth playerHealth;
    int healthItem;
     float timer = 5.0f;
    Time time;
    public bool timerUp = false;
    //public bool qPressed = false;
    //public Text buffText;
    public bool defBuffOn;
    public Renderer rend;
    bool objDestroyed;
	bool hasPlayed = false;
    //public GameObject empty;
    //public GameObject AttBuff;
    public GameObject DefBuff;
    //public GameObject ScoreBuff;
    //public GameObject DashBuff;


    public AudioSource PickupSound;
	public ParticleSystem ps;
    private IEnumerator coroutine;
    /*
    void Start()
    {
       NoDamage();
    }
    */
    void Update()
    {
        //setBuffAlert();
       
           
                if ( healthItem ==1 && timerUp == false)
                {
                    defBuffOn = true;
                    DefBuff.SetActive(true);
                    //empty.SetActive(false);
                    playerHealth.currentHealth = 1000;
            
            timer -= Time.deltaTime;
                    Mathf.Round(timer);
                    //Debug.Log(timer);
                    //Debug.Log("This shit works");
                    //StartCoroutine(NoDamage());
                    if (timer < 0 && timerUp == false)
                    {
                        Debug.Log("Timer up");
                        timerUp = false;
                //playerHealth.healthBuffed = false;
                healthItem--;
                playerHealth.currentHealth = 100;
                        timer = 5.0f;
                        defBuffOn = false;
                        DefBuff.SetActive(false);
                        //gameObject.SetActive(false);
                        //empty.SetActive(true);
                        //timerUp = true;
                        // qPressed = true;
                        // playerHealth.healthBuffed = false;
                        setBuffAlert();
                     }

                }
                
           
        
            
            
        

        
    }

    void setBuffAlert()
    {
        bool healthBeenBuffed = false;
        if (playerHealth.healthBuffed == true && healthBeenBuffed == false)
        {
           // buffText.text = "Health Buffed "; //+ stun.stunsLeft.ToString();
            healthBeenBuffed = true;
        }
        else if ( playerHealth.healthBuffed == false) {
           // buffText.text = "";
        } }

    void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject.CompareTag ("Player")&& healthItem ==0) {

			GameObject Grandma = GameObject.Find ("Grandma");
			PlayerHealth playerHealth = Grandma.GetComponent<PlayerHealth> ();
			//playerHealth.currentHealth = 100;
			healthItem++;
			//NoDamage();

			//AudioSource.PlayClipAtPoint(PickupSound, transform.position);

			Debug.Log ("Stuff worked");
			//Debug.Log (healthItem);
			//playerHealth.healthBuffed = true;
			objDestroyed = true;

			if (objDestroyed == true) {

				rend = GetComponent<Renderer> ();
				rend.enabled = false; 

			}

			setBuffAlert ();
			Destroy (ps);
		}

	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			if (hasPlayed == false) {
				PickupSound.Play ();
				hasPlayed = true;

			}

		}
	}

 



    /*
         private IEnumerator NoDamage()
        {
            Debug.Log("No Damage is active");
            // GameObject.Find("player_test").GetComponent("PlayerHealth").enabled = false;
            playerHealth.currentHealth += 1000;
            //timer -= Time.deltaTime;
            yield return new WaitForSeconds(.5f);
           // if (timer <= 0f)
            //{

             //   Debug.Log("this waited 5 seconds");
              //  playerHealth.currentHealth -= 1000;
            }

        }

        */
}
