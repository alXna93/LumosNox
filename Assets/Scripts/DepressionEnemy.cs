using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepressionEnemy : EnemyAI {

    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;

	// Use this for initialization
	void Start () {
        currentState = EnemyState.idle;
        target = GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        CheckDistance();
	}

    void CheckDistance()
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius) 
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

                transform.position = Vector3.MoveTowards(transform.position, target.position, EnemySpeed * Time.deltaTime);

                ChangeState(EnemyState.walk);
            }
        }
    }

    private void ChangeState(EnemyState newState)
    {

        if(currentState != newState)
        {
            currentState = newState;
        }

    }
}
