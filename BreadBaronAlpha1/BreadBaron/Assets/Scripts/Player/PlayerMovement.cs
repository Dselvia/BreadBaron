using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    Vector3 movement;

    Animator anim;

    public Rigidbody playerRigidbody;

    public float speed = 6f;
    public bool isSprinting;
    public int sprint;
    float sprintTimeLeft = .5f;
    public Renderer rend;
    public PowerUp powerUp;
	public AudioSource walkingSound;
    public int dashesLeft = 3;
   // public GameObject dashsLeft;
    public Text dashText;

    public bool useController;

    public Text sprintText;

    int floorMask;
    //Sets the distance for how far the raycasting will go.
    float camRayLength = 100f;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        //AddDash();
        //Keeps player on the horizontal axis which is mapped to the "a" and "d" keys. Left is negative. Right is positive.
        float h = Input.GetAxisRaw("Horizontal");
        //Keeps player on the vertical axis in this case z space. "w" and "s" but does not allow for y space movement which would be a jump.
        float v = Input.GetAxisRaw("Vertical");

        //Calls the functions
        Move (h, v);
        //Rotate with mouse.
        if (!useController)
        {
            Turning();
        }
        //Rotate with controller.
        if (useController){
            TurningController();
        }
        Animating (h, v);

        if (Input.GetButtonDown("Fire3"))
        {
            Dash(h,v);
        }
        setDashText();
/*
        if ((Input.GetKeyDown(KeyCode.LeftShift) && isSprinting != true) || (Input.GetButtonDown("Fire3") && isSprinting !=true))
        {
           sprintTimeLeft -= Time.deltaTime;
            //sprintText.text = "Time Left:  " + Mathf.Round(sprintTimeLeft);
            Debug.Log(sprintTimeLeft);
            //speed += 10f;
            playerRigidbody.AddForce(transform.forward * 5);
            isSprinting = true;
            if (sprintTimeLeft <= 0)
            {
                isSprinting = false;
                //speed -= 10;
                Debug.Log("Screw Sprinting I disabled it for you ");
				walkingSound.Play ();
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) && isSprinting != false)
        {
            Debug.Log("Is no longer SPrinting");
            speed -= 10f;
            isSprinting = false;
			walkingSound.Play ();
        }
        */
    }

    //Taking in the movement intputs of WASD
    void Move (float h, float v)
    {
        movement.Set(h, 0f, v);

        //Prevents speed advantage that a player would get by moving diagonal.
        //Delta time is time update between each call. 
       
        movement = movement.normalized * speed * Time.deltaTime;


        playerRigidbody.MovePosition(transform.position + movement);
        
        
    }
    void Dash(float h, float v)
    {
        if (dashesLeft > 0)
        {
            movement.Set(h, 0f, v);

            //Prevents speed advantage that a player would get by moving diagonal.
            //Delta time is time update between each call. 

            movement = movement.normalized * (speed * 20) * Time.deltaTime;


            playerRigidbody.MovePosition(transform.position + movement);
            dashesLeft--;
        }

    }


    //Finds point under mouse if it hits the floor quad.
    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit floorHit;

        if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            //Quaternion is a way to store rotations and also a class.
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            //makes player to mouse the forward function.
            playerRigidbody.MoveRotation(newRotation);

        }
    }

    //Turn with controller.
    void TurningController()
    {
        Vector3 playerDirection = Vector3.right * Input.GetAxisRaw("RHorizontal") + Vector3.forward * -Input.GetAxisRaw("RVertical");
        if(playerDirection.sqrMagnitude > 0.0f)
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
        }
    }


    void setDashText()
    {
        //wallText.text = wallCount.ToString();
        dashText.text = "Dash Count : " + dashesLeft.ToString(); //+ stun.stunsLeft.ToString();
    }
    void Animating(float h, float v)
    {
        // determines if h or v is not equal to 0. If either is pressed then the player is walking.
        bool walking = h != 0f || v != 0f;
        //Assigns to specific name "IsWalking" that we made in the animator.
        anim.SetBool("IsWalking", walking);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pick Up"))
        {
            //other.gameObject.SetActive(false);
            ScoreManager.score += 50;

        }

        if (other.gameObject.CompareTag("PowerUp"))
        {
           // rend = powerUp.rend;
          // powerUp.rend.enabled = false;
            //Debug.Log("PowerUp Disabled?");
        }

        if (other.gameObject.CompareTag("Buff"))
        {
            //other.gameObject.SetActive(false);
           // Debug.Log("Buff Disabled?");
        }
    }


  /* void AddDash()
    {
        bool dashUsed1 = false;
        bool dash1Added = false;
        if (ScoreManager.score >= 100 && ScoreManager.score < 200 && dashUsed1 == false && dash1Added == false)
        {



            dash1Added = true;
            // scoreAdded = ScoreManager.score / 100;
            //Debug.Log(scoreAdded);
            dashUsed1 = true;
            dashesLeft++;
        }
    }*/
}
