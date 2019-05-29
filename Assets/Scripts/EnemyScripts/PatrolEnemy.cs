using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : DepressionEnemy
{
    public Transform[] path; //2 point path
    public int currentPoint; //current point enemy is at
    public Transform currentGoal; //Point enemy is directing towards
    public float roundingDistance; 

    public override void CheckDistance() //Check distance between enemy and player and change enemy state depending on distance
    {
        if (Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            if (currentState == EnemyState.idle || currentState == EnemyState.walk && currentState != EnemyState.stagger)
            {

                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, EnemySpeed * Time.deltaTime);

                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);

                
                myAnim.SetBool("startWalking", true);
            }
        }

        //If in chasing distance of player, move towards player
        else if (Vector3.Distance(target.position, transform.position) > chaseRadius)
        {
            if (Vector3.Distance(transform.position, path[currentPoint].position) > roundingDistance)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, path[currentPoint].position, EnemySpeed * Time.deltaTime);
                changeAnim(temp - transform.position);
                myRigidbody.MovePosition(temp);
            }
            else

            // If following path and goal point reached, go to second point
            {
                ChangeGoal();
            }
        }
    }

    private void ChangeGoal() //If enemy has got to first point, +1 to current point and move towards
    {
        if (currentPoint == path.Length - 1)
        {
            currentPoint = 0;
            currentGoal = path[0];
        }
        else
        {
            currentPoint++;
            currentGoal = path[currentPoint];
        }
    }
}
