using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

    //Player statistics
    public string playerName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 5;
    public int startEXP = 500;

    public int currentHP;
    public int maxHP = 100;
    public int currentPower;
    public int maxPower = 30;
    public int[] powerLvlBonus;
    public int strength;
    public int defence;
    public int armourPower;
    public Sprite playerImage;


    // Use this for initialization
    void Start () {

        //
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = startEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 2.50f);
        }
   

	}
	
	// Update is called once per frame
	void Update () {

		//test code for adding EXP
        if(Input.GetKeyDown(KeyCode.E) && playerLevel < maxLevel)
        {
            AddExp(1000);

        }
        else if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }

    //exp to add to player
    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;
        if (playerLevel < maxLevel)
        {
           
            if (currentEXP > expToNextLevel[playerLevel])
            {
                currentEXP -= expToNextLevel[playerLevel];

                playerLevel++;

                // Check whether to add to strength and defence based on odd or even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defence++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP;

              
                //maxPower += powerLvlBonus[playerLevel];
                //currentPower = maxPower;
            }
        }

       
    }
}
