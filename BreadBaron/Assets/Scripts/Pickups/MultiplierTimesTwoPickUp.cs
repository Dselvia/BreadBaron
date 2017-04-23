using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplierTimesTwoPickUp : MonoBehaviour {
    public EnemyHealth enemyHealth;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Times Two PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
