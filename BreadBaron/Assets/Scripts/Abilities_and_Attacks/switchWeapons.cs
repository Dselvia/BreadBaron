using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeapons : MonoBehaviour {

    //For additional weapons add more public variables to manipulate in the inspector.
    public GameObject weapon01;
    public GameObject weapon02;
    public GameObject weapon03;


    void Start()
    {
        weapon01.SetActive(true);
        weapon02.SetActive(false);
        weapon03.SetActive(false);
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Switch")) 
        {
            SwitchWeaponsPlease();
            Debug.Log("You switched weapons");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchWeaponsPlease2();
            Debug.Log("You switched for a polaroid.");
        }
	}

    
    void SwitchWeaponsPlease()
    {
        Debug.Log("You switched weapons and it went to the function");
        //If weapon 1 is showing and button 1 is pressed weapon 1 is turned off and weapon 2 is turned on.
        if (weapon01.activeSelf)
        {
            weapon01.SetActive(false);
            weapon02.SetActive(true);
            Debug.Log("Weapon 2 is now on");
        }
        else
        {
            weapon01.SetActive(true);
            weapon02.SetActive(false);
            Debug.Log("Weapon 1 is now on");
        }
    }

    void SwitchWeaponsPlease2()
    {
        Debug.Log("You switched weapons and it went to the function");
        //If weapon 1 is showing and button 1 is pressed weapon 1 is turned off and weapon 2 is turned on.
        if (weapon01.activeSelf)
        {
            weapon01.SetActive(false);
            weapon02.SetActive(false);
            weapon03.SetActive(true);
            Debug.Log("Weapon 2 is now on");
        }
        else
        {
            weapon01.SetActive(true);
            weapon02.SetActive(false);
            weapon03.SetActive(false);
            Debug.Log("Weapon 1 is now on");
            Debug.Log("Fuck you, it doesnt work");
        }
    }


}
