using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    

    public bool dialogActive, fadingBetweenScenes;
   

	// Use this for initialization
	void Start () {

        instance = this;

        DontDestroyOnLoad(gameObject);

	}

    // Update is called once per frame
    void Update()
    {
        if (dialogActive || fadingBetweenScenes)
        {
            PlayerController.instance.canMove = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
        }

    }

   
}
