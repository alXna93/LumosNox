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

    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float EnemySpeed;
    public GameObject destroyEnemy;

    // Use this for initialization
    void Start()
    {
        if (health <= 0)
        {
            Destroy(destroyEnemy);
        }

    }





    // Update is called once per frame
    void Update()
    {



    }
}