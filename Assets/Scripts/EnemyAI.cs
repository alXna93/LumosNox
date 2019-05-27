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

public class EnemyAI : MonoBehaviour {

    public EnemyState currentState;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float EnemySpeed;
    public GameObject depEnemy;
	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		
	}
=======
        if (health <= 0)
        {
            Destroy(depEnemy);
        }
    }
>>>>>>> 1095441078d283cf4f4b93ab2f86fea750f44246
	
	// Update is called once per frame
	void Update () {
       
    }

  
}
