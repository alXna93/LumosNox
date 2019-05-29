using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp {

    public FloatValue playerHealth; //Value of players health
    public float amountToIncrease; //How much to increase by
    public FloatValue heartContainers; //Amount of hearts appearing on UI
    private sfxManager sfxMan;

    // Use this for initialization
    void Start () {
        sfxMan = FindObjectOfType<sfxManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
        //If player collides with a heart, add to player health, play effect and destory heart
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 2)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            }
            powerUpSignal.Raise();
            sfxMan.powerUpGain.Play();
            Destroy(this.gameObject);
        }
    }
}

