using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clue : MonoBehaviour {

    public GameObject clue;
    public bool clueActive = false;

    public void ChangeClue()
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
