using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : MonoBehaviour {

    //Movement script for NPC with bounds in HubLevel
    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    public Collider2D bounds;
    private bool isMoving; //Is the NPC moving
    public bool playerInRange; 
    public float minMoveTime;
    public float maxMoveTime;
    private float moveTimeSeconds;
    public float minWaitTime;
    public float maxWaitTime;
    private float waitTimeSeconds;

	// Use this for initialization
	void Start () {
        moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);
        waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        ChangeDirection();
	}
	
	// Update is called once per frame
	void Update () {

        if (isMoving)
        {
            moveTimeSeconds -= Time.deltaTime;
            if (moveTimeSeconds <= 0)
            {
                moveTimeSeconds = Random.Range(minMoveTime, maxMoveTime);

                isMoving = false;
                
               
            }
            if (!playerInRange)
            {
                Move();
            }
        }
        else
        {
            waitTimeSeconds -= Time.deltaTime;
            if(waitTimeSeconds <= 0)
            {
                ChooseDifferentDirection();
                isMoving = true;
                waitTimeSeconds = Random.Range(minWaitTime, maxWaitTime);
            }
        }
 
       
        
	}

    private void ChooseDifferentDirection() //Make direction appear to be more random
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while (temp == directionVector && loops < 100)
        {
            loops++; //Dont get into an infinite loop
            ChangeDirection(); //Change direction
        }

    }

    private void Move() //Move the NPC 
    {
        Vector3 temp = myTransform.position + directionVector * speed * Time.deltaTime;
        if (bounds.bounds.Contains(temp))
        {
            myRigidbody.MovePosition(temp);
        }
        else
        {
            ChangeDirection();
        }
    }

    void ChangeDirection() //Change the direction by using 4 different cases, one for each direction
    {
        int direction = Random.Range(0, 4);
        switch (direction)
        {
            case 0:
                //Walking right
                directionVector = Vector3.right;
                break;
            case 1:
                //walking up
                directionVector = Vector3.up;
                break;
            case 2:
                //Walking left
                directionVector = Vector3.left;
                break;
            case 3:
                //walking down
                directionVector = Vector3.down;
                break;
            default:
                break;
        }

        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        myAnim.SetFloat("moveX", directionVector.x);
        myAnim.SetFloat("moveY", directionVector.y);
    }

    private void OnCollisionEnter2D(Collision2D other) //If NPC collides start moving again in different direction
    {
        ChooseDifferentDirection();
    }

    private void OnTriggerEnter2D(Collider2D other) //If colliding with player then player in range = true
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            playerInRange = true;
         
        }
    }

    private void OnTriggerExit2D(Collider2D other) //When player isnt in range anymore
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            playerInRange = false;            
        }
    }
}
