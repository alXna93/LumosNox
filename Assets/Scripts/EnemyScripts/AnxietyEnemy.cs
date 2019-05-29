using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyEnemy : EnemyAI {


    public Transform target; //Target enemy will move toward
    public float chaseRadius; //Radius to figure out when to chase
    public float attackRadius; //Attacking radius
    public Transform homePosition; //Original position before chasing begain
    public Animator myAnim; //my animation
    public Rigidbody2D myRigidbody; //enemy rigidbody


    // Use this for initialization
    void Start()
        
        //Starting values, set state to idle, find player by its tag and transform to their position
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
        myAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();

    }

    void CheckDistance() //Check distance between enemy and player and change enemy state depending on distance and change state
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, EnemySpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);

                ChangeState(EnemyState.walk);
                myAnim.SetBool("startWalking", true);
            }
        }

        //If player isn within radius, begin walking state
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            myAnim.SetBool("startWalking", false);
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        myAnim.SetFloat("moveX", setVector.x);
        myAnim.SetFloat("moveY", setVector.y);
    }

    private void changeAnim(Vector2 direction) //Change animation depending on direction
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }

        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void ChangeState(EnemyState newState) //If current state isnt equal to new state then make current state, new state
    {

        if (currentState != newState)
        {
            currentState = newState;
        }

    }


}
