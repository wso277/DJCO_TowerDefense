using UnityEngine;
using System.Collections;

public class TowerLife : MonoBehaviour {

	public int currentLifePoints;
	public int totalLifePoints = 10;
	
	// Use this for initialization
	void Start () {
		currentLifePoints = totalLifePoints;
	}
	
	// Update is called once per frame
	void Update () {
		if (currentLifePoints <= 0) {
			Destroy(gameObject);
		}
	}
	
	public void TakeDamage(int amount) {
		currentLifePoints -= amount;
	}
}
