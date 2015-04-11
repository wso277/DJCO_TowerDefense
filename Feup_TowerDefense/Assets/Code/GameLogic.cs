﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public static GameLogic instance;

	public int currentLifePoints;
	public int totalLifePoints = 100;
	public int score = 0;
	public Image healthBar;
	public GameObject[] enemies;
    public float timescale = 0;

	// Use this for initialization
	void Start () {
		currentLifePoints = totalLifePoints;

		instance = this;
	}
	
	// Update is called once per frame
	void Update () {	
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (currentLifePoints <= 0) {
            Application.LoadLevel("gameOver");
		}
        if (Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Restart"))
        {
            Application.LoadLevel("scene");
        }
        if (Input.GetButtonDown("Pause"))
        {
            float tmp = Time.timeScale;
            Time.timeScale = timescale;
            timescale = tmp;
        }

	}

	public void TakeDamage(int amount) {
		currentLifePoints -= amount;
		healthBar.fillAmount -= (float) amount * 0.01f;
	}
	
}
