using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public PlayerStats charStats;

    public bool gameMenuOpen, dialogActive, fadingBetweenScenes;
    

	// Use this for initialization
	void Start () {

        instance = this;

        DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		if(gameMenuOpen || dialogActive || fadingBetweenScenes)
        {
            PlayerController.instance.canMove = false;
        } else
        {
            PlayerController.instance.canMove = true;
        }
	}
}
