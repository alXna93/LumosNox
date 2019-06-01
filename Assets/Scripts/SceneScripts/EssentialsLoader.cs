using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour {

    //Holds the essentials for every level
    
    public GameObject UIScreen; 
    public GameObject player;
    public GameObject gameMan;
    
	// Use this for initialization
	void Start () {
		if (UIFade.instance == null)
        {

            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>(); //fading screen

        }

        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>(); // initialise player character
            PlayerController.instance = clone;
        }

        if(GameManager.instance == null)
        {
            Instantiate(gameMan);
        }

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
