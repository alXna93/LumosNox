using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour {

    public GameObject clue; //Clue question mark
    public bool clueActive = false; 

    public void ChangeClue() //If clue isnt equal to true, set it to true
    {
        clueActive = !clueActive;
        if(clueActive)
        {
            clue.SetActive(true);
        }
        else
        {
            clue.SetActive(false);
        }
    }
}
