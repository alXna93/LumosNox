using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour {


    public string areaToLoad;
    private GameObject[] enemy;

    public string areaTransitionName;

    public AreaEntrance theEntrance;

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

	// Use this for initialization
	void Start () {
        theEntrance.transitionName = areaTransitionName;        
	}
	
	// Update is called once per frame
	void Update () {
        if (shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;

            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }
      
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        enemy = GameObject.FindGameObjectsWithTag("enemy"); //array of current enemies
        if (other.tag == "Player" && enemy.Length <=0)
        {
            //SceneManager.LoadScene(areaToLoad);
            shouldLoadAfterFade = true;
            GameManager.instance.fadingBetweenScenes = true;

            UIFade.instance.FadeToBlack();

            PlayerController.instance.areaTransitionName = areaTransitionName;
        }
    }
}
