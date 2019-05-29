﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : Interactables {

    public string[] lines;

    private bool canActivate;

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(canActivate && Input.GetButtonDown("Fire1") && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            DialogueManager.instance.ShowDialog(lines, isPerson);
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
