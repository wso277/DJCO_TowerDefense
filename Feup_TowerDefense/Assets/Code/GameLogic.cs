﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public static GameLogic instance;

	public int currentLifePoints;
	public int totalLifePoints = 100;
	public int currentTower = 2;
	public int towerCharges = 2;

	public Image healthBar;

	public GameObject[] enemies;

	private static int score = 5000;
	public static int Score{
		get {return score;} 
		set { score = value; }
	}
    public float timescale = 0;

	public Spawner spawner;

	void Awake(){
		DontDestroyOnLoad (this);
	}

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

		// Win condition
		if (enemies.Length == 3 && currentLifePoints > 0 && spawner.spawnTime == 1f) {
			score = score + (currentLifePoints * 5) - (currentTower * 50);
			Application.LoadLevel("winScene");
		}
	}

	public void TakeDamage(int amount) {
		currentLifePoints -= amount;
		healthBar.fillAmount -= (float) amount * 0.01f;
	}
	
}
