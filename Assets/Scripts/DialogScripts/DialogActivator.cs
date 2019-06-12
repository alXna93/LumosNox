using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivator : Interactables {

    public string[] lines;

    private bool hasRead;

    [SerializeField]
    private GameObject exit;

    // Use this for initialization
    void Start () {
        canActivate = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(canActivate && Input.GetButtonDown("Fire1") && !DialogueManager.instance.dialogBox.activeInHierarchy)
        {
            DialogueManager.instance.ShowDialog(lines, isPerson);
            hasRead = true;
        }
       if(hasRead && exit != null) //if sign has been read then trigger box is active
        {
            exit.gameObject.SetActive(true);
        }
       else if (exit != null)
        { 
                exit.gameObject.SetActive(false);
        }

           
	}

}
