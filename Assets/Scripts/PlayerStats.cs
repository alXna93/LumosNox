using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats: MonoBehaviour {

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
    public int strength;
    public int defence;
    public int armourPower;
    public Sprite playerImage;


    // Use this for initialization
    void Start () {

        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = startEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 2.50f);
        }
   

	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.E))
        {
            AddExp(500);
        }
	}

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if (currentEXP > expToNextLevel[playerLevel])
        {
            currentEXP -= expToNextLevel[playerLevel];

            playerLevel++;
        }
    }
}
