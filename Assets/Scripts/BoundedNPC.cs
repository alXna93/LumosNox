using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedNPC : MonoBehaviour {

    private Vector3 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;
    public Collider2D bounds;
    public bool playerInRange;


	// Use this for initialization
	void Start () {

        myTransform = GetComponent<Transform>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        ChangeDirection();
	}
	
	// Update is called once per frame
	void Update () {
        if (!playerInRange)
        {
            Move();
        }
	}

    private void Move()
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

    void ChangeDirection()
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 temp = directionVector;
        ChangeDirection();
        int loops = 0;
        while(temp == directionVector && loops < 100)
        {
            loops++;
            ChangeDirection();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.isTrigger)
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerInRange = false;
        }
    }
}
