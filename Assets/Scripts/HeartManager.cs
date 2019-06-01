using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HeartManager : MonoBehaviour {

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite halfFullHeart;
    public Sprite emptyHeart;
    public FloatValue heartContainers;
    public FloatValue playerCurrentHealth;

    public static HeartManager instance;

    private FloatValue health;

    // Use this for initialization
    void Start () {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().currentHealth;
        InitHearts();
	}
	
	public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
            hearts[i].sprite = fullHeart;
        }
    }

    //update heart on UI by going through the players health
    public void UpdateHearts()
    {
        float tempHealth = health.RuntimeValue / 2;
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if (i <= tempHealth - 1)
            {
                //full heart
                hearts[i].sprite = fullHeart;
            }
            else if(i >= tempHealth)
                {
                //empty heart
                hearts[i].sprite = emptyHeart;
                }
            else
            {
                //half full heart
                hearts[i].sprite = halfFullHeart;
            }
        }
    }
}
