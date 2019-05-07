using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {


    public GameObject theMenu;

    private PlayerStats[] playerStats;

    //public Text[] nameText, hpText, mpText, lvlText, expText;
    //public Slider[] expSlider;
    //public Image[] playerImage;
    //public GameObject[] playerStatHolder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire2"))
        {
            if(theMenu.activeInHierarchy)
            {
                theMenu.SetActive(false);
                GameManager.instance.gameMenuOpen = false;
            } else
            {
                theMenu.SetActive(true);
                UpdateMainStats();
                GameManager.instance.gameMenuOpen = true;
            }
        }
	}

    public void UpdateMainStats()
    {
        playerStats = GameManager.instance.playerStats;

        //for(int i = 0; i < playerStats.Length; i++)
        //{
        //    if (playerStats[i].gameObject.activeInHierarchy)
        //    {
        //        playerStatHolder[i].SetActive(true);

        //        nameText[i].text = playerStats[i].playerName;
        //        hpText[i].text = "Health: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
        //        mpText[i].text = "Power: " + playerStats[i].currentPower + "/" + playerStats[i].maxPower;
        //        lvlText[i].text = "Level: " + playerStats[i].playerLevel;
        //        expText[i].text = playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
        //        expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
        //        expSlider[i].value = playerStats[i].currentEXP;
        //        playerImage[i].sprite = playerStats[i].playerImage;

        //    }else
        //    {
        //        playerStatHolder[i].SetActive(false);

        //    }
        //}
    }
}
