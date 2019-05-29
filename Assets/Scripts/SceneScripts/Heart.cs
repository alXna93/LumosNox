using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : PowerUp {

    public FloatValue playerHealth;
    public float amountToIncrease;
    public FloatValue heartContainers;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerHealth.RuntimeValue += amountToIncrease;
            if(playerHealth.initialValue > heartContainers.RuntimeValue * 2)
            {
                playerHealth.initialValue = heartContainers.RuntimeValue * 2f;
            }
            powerUpSignal.Raise();
            Destroy(this.gameObject);
        }
    }
}

