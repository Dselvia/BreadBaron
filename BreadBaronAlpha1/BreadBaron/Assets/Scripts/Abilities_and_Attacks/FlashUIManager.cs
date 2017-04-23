using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashUIManager : MonoBehaviour
{

    public int getWallCount;
    public GameObject Player;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject wall3;
    public GameObject wall4;

    // Use this for initialization
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject Player = GameObject.FindWithTag("Player");
       PlayerMovement playerMovement = Player.GetComponent<PlayerMovement>();
        getWallCount = playerMovement.dashesLeft;
        if (getWallCount > 3)
        {
            wall1.SetActive(true);
            wall2.SetActive(true);
            wall3.SetActive(true);
            wall4.SetActive(true);
        }
        else if (getWallCount == 3)
        {
            wall1.SetActive(false);
            wall2.SetActive(true);
            wall3.SetActive(true);
            wall4.SetActive(true);
        }
        else if (getWallCount == 2)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(true);
            wall4.SetActive(true);
        }
        else if (getWallCount == 1)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
            wall4.SetActive(true);
        }
        else if (getWallCount == 0)
        {
            wall1.SetActive(false);
            wall2.SetActive(false);
            wall3.SetActive(false);
            wall4.SetActive(false);
        }
    }
}
