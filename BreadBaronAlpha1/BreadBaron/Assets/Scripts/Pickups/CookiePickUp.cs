using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookiePickUp : MonoBehaviour {

	// Use this for initialization
	public AudioSource cookie;

	void OnTriggerEnter(Collider other)
	{
		cookie.Play ();

	}
}
