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
	public GameObject effect;
	private GameObject closestEnemy;

	private GameObject[] enemies;
	
	public AudioClip TowerShootSound;

	private Collider2D towerCollider;
	private Collider2D enemyCollider;

	private BulletLogic bulletLogicScript;


	void Start() {
		towerCollider = this.GetComponent<Collider2D> ();
	}

	void Awake () {
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

	// Returns the closest enemy to the tower
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
