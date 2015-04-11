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
	}
	
	public void TakeDamage(int amount) {
        GameObject effect = (GameObject) Instantiate (this.gameObject.GetComponent<Weapon>().FireProjectileEffect, this.gameObject.GetComponent<Weapon>().ProjectileFireLocation.position, this.gameObject.GetComponent<Weapon>().ProjectileFireLocation.rotation);
		effect.transform.parent = transform;
		currentLifePoints -= amount;

		
		if (currentLifePoints <= 0) {
			Destroy(gameObject);
		}
	}
}
