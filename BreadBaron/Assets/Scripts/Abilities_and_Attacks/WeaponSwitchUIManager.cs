using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitchUIManager : MonoBehaviour
{

    //For additional weapons add more public variables to manipulate in the inspector.
    public GameObject weaponCard1;
    public GameObject weaponCard2;
    public GameObject weaponCard3;


    void Start()
    {
        weaponCard1.SetActive(true);
        weaponCard2.SetActive(false);
        weaponCard3.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SwitchCard();
            Debug.Log("the old UI switcheroo!");
        }
       
    }


    void SwitchCard()
    {

        if (weaponCard1.activeSelf)
        {
            weaponCard1.SetActive(false);
            weaponCard2.SetActive(true);
           
        }
        else
        {
            weaponCard1.SetActive(true);
            weaponCard2.SetActive(false);
            
        }
    }

 

}