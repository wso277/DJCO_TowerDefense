using UnityEngine;
using System.Collections;

public class MultiShotWeapon : Weapon {

	public float fireRate = 2;
	public float damage = 10;
	public int simultaneousShots = 3;
	public float range = 10;
	private float timeToFire = 0;
	private float distanceToEnemy;
	
	public Transform ProjectileFireLocation;
	public Transform BulletPrefab;
	public Transform bullet;
	
	public GameObject FireProjectileEffect;
	public GameObject TakeDamageEnemyEffect;
	public GameObject effect;
	private GameObject[] closestEnemies;
	
	private GameObject[] enemies;
	
	public AudioClip TowerShootSound;
	
	private Collider2D towerCollider;
	private Collider2D enemyCollider;
	
	private BulletLogic bulletLogicScript;


	private float firstClosest = float.PositiveInfinity;
	private float secondClosest = float.PositiveInfinity;
	private float thirdClosest = float.PositiveInfinity;

	void Start() {
		towerCollider = this.GetComponent<Collider2D> ();
	}

	// Update is called once per frame
	void Update () {
		closestEnemies = GetClosestEnemies ();

		if(closestEnemies[0] != null && Time.time > timeToFire) {
			timeToFire = Time.time + 1/fireRate;

			foreach (GameObject enemy in closestEnemies) {
				enemyCollider = enemy.GetComponent<Collider2D> ();
				if (towerCollider.bounds.Intersects (enemyCollider.bounds)) {
					Shoot(enemy);
				}
			}
		}

	}

	private void shiftRight(GameObject[] arr, int position) {
		for (int c = position; c < arr.Length - 1; c++) {
			arr[c+1] = arr[c];
		}
	}

	private void shiftRight(float[] arr, int position) {
		for (int c = position; c < arr.Length - 1; c++) {
			arr[c+1] = arr[c];
		}
	}

	// Returns the closest enemy to the tower
	GameObject[] GetClosestEnemies () {
		
		float smallestDistance = float.PositiveInfinity;
		GameObject[] result = new GameObject[simultaneousShots];

		float[] distances = new float[simultaneousShots];
		for (int d = 0; d < distances.Length; d++) {
			distances[d] = float.PositiveInfinity;
		}

		int enemyCounter = 0;
		enemies = GameLogic.instance.enemies;
		
		foreach (GameObject enemy in enemies) {
			if (enemy != null) {
				distanceToEnemy = Vector3.Distance (this.transform.position, enemy.transform.position);

				for(int d = 0; d < distances.Length; d++) {
					if (distanceToEnemy < distances[d]) {

						shiftRight(result, d);
						shiftRight(distances, d);
						result[d] = enemy;
						distances[d] = distanceToEnemy;
						break;
					}
				}
				/*if (distanceToEnemy < range) {
					result[enemyCounter] = enemy;
					enemyCounter++;

					if(enemyCounter == simultaneousShots) {
						break;
					}
				}*/
			}
		}
		return result;
	}
	
	// Shoots at the closest enemy
	void Shoot(GameObject enemy) {
		bullet = (Transform)Instantiate (BulletPrefab, this.transform.position, this.transform.rotation);
		bulletLogicScript = bullet.GetComponent<BulletLogic> ();
		bulletLogicScript.target = enemy;
		bulletLogicScript.tower = this.gameObject;
		
		/*Tower shoot sound*/
		AudioSource.PlayClipAtPoint (TowerShootSound, transform.position);
	}
}
