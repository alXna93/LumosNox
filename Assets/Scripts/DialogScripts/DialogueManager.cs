﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {


    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine;

    private bool justStarted;

    public static DialogueManager instance;

	// Use this for initialization
	void Start () {

        instance = this;
        //dialogText.text = dialogLines[currentLine];
	}
	
	// Update is called once per frame
	void Update () {
		
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;

                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);

                        GameManager.instance.dialogActive = false;
                    }
                    else
                    {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }

                }
                else
                {
                    justStarted = false;
                }
            }
        }

	}

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;

        GameManager.instance.dialogActive = true;

        nameBox.SetActive(isPerson);


    }

    public void CheckIfName()
    {
        if(dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }


    }
}
