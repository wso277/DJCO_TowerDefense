using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 2;
	public float damage = 10;
	public float range = 10;
	private float timeToFire = 0;
	private float distanceToEnemy;

	public Transform ProjectileFireLocation;
	public Transform BulletPrefab;
	public Transform bullet;
	
	public GameObject FireProjectileEffect;
	public GameObject TakeDamageEnemyEffect;
	private GameObject effect;
	private GameObject closestEnemy;

	private GameObject[] enemies;
	
	public AudioClip TowerShootSound;

	private Collider2D towerCollider;
	private Collider2D enemyCollider;

	public BulletLogic bulletLogicScript;
	
	//Transform firePoint;

	void Start() {
		towerCollider = this.GetComponent<Collider2D> ();
	}

	void Awake () {
		/*firePoint = transform.FindChild ("FirePoint");
		if(firePoint == null) {
			Debug.LogError ("No FirePoint ? What?!");
		}*/
	}

	// Update is called once per frame
	void Update () {

		closestEnemy = GetClosestEnemy ();
		if (closestEnemy != null && Time.time > timeToFire) {
			timeToFire = Time.time + 1/fireRate;
			
			enemyCollider = closestEnemy.GetComponent<Collider2D> ();

			if (towerCollider.bounds.Intersects (enemyCollider.bounds)) {
				Shoot(closestEnemy);
			}
		}
	}

	GameObject GetClosestEnemy () {

		float smallestDistance = float.PositiveInfinity;
		GameObject result = null;
		enemies = GameLogic.instance.enemies;

		foreach (GameObject enemy in enemies) {
			if (enemy != null) {
				distanceToEnemy = Vector3.Distance (this.transform.position, enemy.transform.position);
				if (distanceToEnemy < smallestDistance) {
					result = enemy;
					smallestDistance = Vector3.Distance (this.transform.position, enemy.transform.position);
				}
			}
		}
		return result;
	}

	void Shoot(GameObject enemy) {
		if (FireProjectileEffect != null) {
			if (TakeDamageEnemyEffect != null) {
				effect = (GameObject) Instantiate (TakeDamageEnemyEffect, enemy.transform.position, enemy.transform.rotation);
				effect.transform.parent = transform;
			}
			/*effect = (GameObject) Instantiate (FireProjectileEffect, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
			effect.transform.parent = transform;*/
		}

		bullet = (Transform)Instantiate (BulletPrefab, this.transform.position, this.transform.rotation);
		bulletLogicScript = bullet.GetComponent<BulletLogic> ();
		bulletLogicScript.target = enemy;

		/*Tower shoot sound*/
		AudioSource.PlayClipAtPoint (TowerShootSound, transform.position);
	}
}
