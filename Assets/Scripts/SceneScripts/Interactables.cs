using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactables : MonoBehaviour {

    public bool isPerson = true; //Is collider a person
    public Signal clue; //Signal to raise clue
    protected bool canActivate; //Can the dialog be activated


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //if player collides with trigger, raise the signal to show question mark
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            clue.Raise();        
          
            canActivate = true; //activate dialog
       
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player" && !other.isTrigger)
        {
            clue.Raise();
             
            canActivate = false;
        }
    }
}
