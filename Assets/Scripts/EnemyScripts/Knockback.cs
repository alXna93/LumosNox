using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour {

    public float thrust; //knockback amount
    public float knockTime; //time since knockback
    public float damage; //damage dealth by knockback

    private void OnTriggerEnter2D(Collider2D other) //If enemy or player attacks one another, move rigidbody by adding thrust and impulse
    {

        if (other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
            if (hit != null)
            {
                Vector2 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.AddForce(difference, ForceMode2D.Impulse);

                //If enemy gets knocked back by player attacking change state and deal damage
                if (other.gameObject.CompareTag("enemy") && other.isTrigger)
                {
                    hit.GetComponent<EnemyAI>().currentState = EnemyState.stagger;
                    other.GetComponent<EnemyAI>().Knock(hit, knockTime, damage);
                }

                //If player gets knocked back by enemy attacking change state and deal damage
                if (other.gameObject.CompareTag("Player"))
                {
                    if (other.GetComponent<PlayerController>().currentState != PlayerState.stagger)
                    {

                        hit.GetComponent<PlayerController>().currentState = PlayerState.stagger;
                        other.GetComponent<PlayerController>().Knock(knockTime, damage);
                    }
                }
                         
                
            }
        }
    }
 
   
   
}
