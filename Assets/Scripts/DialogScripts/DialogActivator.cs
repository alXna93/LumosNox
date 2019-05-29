using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : Interactables {

    public string[] lines;
    
    
   

    // Use this for initialization
    void Start () {
        canActivate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(canActivate && Input.GetButtonDown("Fire1") && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            DialogueManager.instance.ShowDialog(lines, isPerson);
        }
       
           
	}




}
