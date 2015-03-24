using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour {

	public int currentLifePoints;
	public int totalLifePoints = 100;
	public int score = 0;
	public Image healthBar;

	// Use this for initialization
	void Start () {
		currentLifePoints = totalLifePoints;
	}
	
	// Update is called once per frame
	void Update () {	
		if (currentLifePoints <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}

	}

	public void TakeDamage(int amount) {
		currentLifePoints -= amount;
		healthBar.fillAmount -= (float) amount * 0.01f;
	}
}
