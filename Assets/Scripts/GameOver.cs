using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public string mainMenuScene;
    public string loadGameScene;
    public GameObject player;

    // Use this for initialization
    void Start () {
        PlayerController.instance.gameObject.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void QuitToMain() //If player clicks on quit, quit the application
    {
        Destroy(GameManager.instance.gameObject);
        Destroy(PlayerController.instance.gameObject);
       
        SceneManager.LoadScene("startMenu");
    }

    public void RestartGame()
    {
        Destroy(GameManager.instance.gameObject);
        Destroy(PlayerController.instance.gameObject);
       

        SceneManager.LoadScene("HubLevel");
        

    }
}
