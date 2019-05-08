using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {


    public GameObject theMenu;
    private PlayerStats charStats;

    public Text nameText, hpText, mpText, lvlText, expText;
    public Slider expSlider;
    public Image playerImage;
    public GameObject playerStatHolder;

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
        charStats = GameManager.instance.charStats;
     
            if (charStats.gameObject.activeInHierarchy)
            {
                playerStatHolder.SetActive(true);
                nameText.text = charStats.playerName;
                hpText.text = "Health: " + charStats.currentHP + "/" + charStats.maxHP;
                mpText.text = "Power: " + charStats.currentPower + "/" + charStats.maxPower;
                lvlText.text = "Level: " + charStats.playerLevel;
                expText.text = charStats.currentEXP + "/" + charStats.expToNextLevel[charStats.playerLevel];
                expSlider.maxValue = charStats.expToNextLevel[charStats.playerLevel];
                expSlider.value = charStats.currentEXP;
                playerImage.sprite = charStats.playerImage;

            }
            else
            {
                playerStatHolder.SetActive(false);
            }
        
    }
}
