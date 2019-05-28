using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnxietyEnemy : EnemyAI {


    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    public Animator myAnim;
    public Rigidbody2D myRigidbody;


    // Use this for initialization
    void Start()
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

    void CheckDistance()
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

    private void changeAnim(Vector2 direction)
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

    private void ChangeState(EnemyState newState)
    {

        if (currentState != newState)
        {
            currentState = newState;
        }

    }


}
