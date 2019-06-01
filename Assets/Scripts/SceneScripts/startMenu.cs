using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void NewGame() //If player clicks on new game, load Hublevel scene
    {
        SceneManager.LoadScene("HubLevel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
  
}
