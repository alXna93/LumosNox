using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

    public bool isPerson = true;
    public Signal clue;
    protected bool canActivate;



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            clue.Raise();        
            isPerson = true;
            canActivate = true;
       
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            clue.Raise();
            isPerson = false;
            canActivate = false;
        }
    }
}
