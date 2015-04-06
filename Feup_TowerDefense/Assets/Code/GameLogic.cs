using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public static GameLogic instance;

	public int currentLifePoints;
	public int totalLifePoints = 100;
	public int score = 0;
	public Image healthBar;
	public GameObject[] enemies;

	// Use this for initialization
	void Start () {
		currentLifePoints = totalLifePoints;

		instance = this;
	}
	
	// Update is called once per frame
	void Update () {	
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (currentLifePoints <= 0) {
			//Application.LoadLevel(Application.loadedLevel);
		}

	}

	public void TakeDamage(int amount) {
		currentLifePoints -= amount;
		healthBar.fillAmount -= (float) amount * 0.01f;
	}
	
}
