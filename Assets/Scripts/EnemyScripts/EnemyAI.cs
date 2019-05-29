using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    idle,
    walk,
    attack,
    stagger
}

public class EnemyAI : MonoBehaviour
{
    public FloatValue maxHealth; 
    public EnemyState currentState; //the current state the enemy is in
    public float health; //health for enemies
    public string enemyName;   
    public float EnemySpeed;
    public int baseAttack;
    public GameObject deathEffect;
    private sfxManager sfxMan;

    private void Awake()
    {
        health = maxHealth.initialValue; //starting function for enemies
        sfxMan = FindObjectOfType<sfxManager>(); //
    }



    private void TakeDamage(float damage)
    {
        health -= damage;     //If enemy has taken damage, decrease health by the amount of damage
        if (health <= 0)
        {
            DeathEffect(); //Play effect animation
            sfxMan.enemyDeath.Play(); //Play sound effect
            this.gameObject.SetActive(false); //Set enemy in scene to false
        }
    }


    //if enemy has been killed play death animation 
    private void DeathEffect()
    {
        if (deathEffect != null)
        {
            GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity); //create an instance of the effect
            Destroy(effect, 1f); //destroy the effect
                
        }
    }

   
    public void Knock(Rigidbody2D myRigidbody, float knockTime, float damage)
    {
        StartCoroutine(KnockCo(myRigidbody, knockTime));
        TakeDamage(damage);
    }

    //Coroutine for changing enemy state if they have been knocked back
    private IEnumerator KnockCo(Rigidbody2D myRigidBody, float knockTime)
    {
        if (myRigidBody != null)
        {
            yield return new WaitForSeconds(knockTime);
            myRigidBody.velocity = Vector2.zero;
            currentState = EnemyState.idle;
            myRigidBody.velocity = Vector2.zero;
        
        }
    }
}