﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public PlayerStats[] playerStats;

	// Use this for initialization
	void Start () {

        instance = this;

        DontDestroyOnLoad(gameObject);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}