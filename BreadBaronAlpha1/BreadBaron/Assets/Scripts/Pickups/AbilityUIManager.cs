using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUIManager : MonoBehaviour {

    public GameObject multiCookie;
    public GameObject redCookie;
    public GameObject empty;
    public GameObject AttBuff;
    public GameObject DefBuff;
    public GameObject ScoreBuff;
    public GameObject DashBuff;

    // Use this for initialization
    void Start () {
        GameObject multiCookie = GameObject.FindWithTag("PowerUp");
        PowerUp PowerUpScript = multiCookie.GetComponent<PowerUp>();
        GameObject redCookie = GameObject.FindWithTag("Buff");
        buffScript BuffScript = redCookie.GetComponent<buffScript>();
    }

    // Update is called once per frame
    void Update () {
        GameObject multiCookie = GameObject.FindWithTag("PowerUp");
        PowerUp PowerUpScript = multiCookie.GetComponent<PowerUp>();
        GameObject redCookie = GameObject.Find("redvelvetcookieattackboost");
        buffScript BuffScript = redCookie.GetComponent<buffScript>();
        if (!gameObject.GetComponent <buffScript> ().attBuffOn && !gameObject.GetComponent<PowerUp>().defBuffOn)
        {
            empty.SetActive(true);
        }
        else if(gameObject.GetComponent<buffScript>().attBuffOn)
        {
            empty.SetActive(false);
            AttBuff.SetActive(true);
            DefBuff.SetActive(false);
        }
        else if (gameObject.GetComponent<PowerUp>().defBuffOn)
        {
            empty.SetActive(false);
            AttBuff.SetActive(false);
            DefBuff.SetActive(true);
        }
    }
}
