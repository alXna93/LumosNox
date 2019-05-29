using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour {

    public AudioSource playerAttack; //attacing sound
    public AudioSource powerUpGain; //Heart collected sound
    public AudioSource enemyDeath; //enemy death sound

    private static bool sfxManExists;

	// Use this for initialization
	void Start () {
        if (!sfxManExists) //If SFXman doesnt exist, SFXman is true
        {
            sfxManExists = true;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
             Destroy(gameObject); //If duplicated, destroy duplicate
        }
        

        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
