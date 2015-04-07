using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 2;
	public float damage = 10;
	public float range = 10;
	public LayerMask whatToIt;
	
	public Transform BulletTrailPrefab;
	public Transform MuzzleFlashPrefab;
	
	public GameObject FireProjectileEffect;
	public Transform ProjectileFireLocation;
	
	public AudioClip TowerShootSound;
	
	float timeToFire = 0;
	float timeToSpawnEffect;
	public float effectSpawnRate  = 0;

	public Transform BulletPrefab;
	
	Transform firePoint;

	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if(firePoint == null) {
			Debug.LogError ("No FirePoint ? What?!");
		}
	}

	// Update is called once per frame
	void Update () {

		GameObject closestEnemy = GetClosestEnemy ();
		if (closestEnemy != null && Time.time > timeToFire) {
			timeToFire = Time.time + 1/fireRate;
			Shoot(closestEnemy);
		}
	}

	GameObject GetClosestEnemy () {

		float smallestDistance = float.PositiveInfinity;
		GameObject result = null;
		GameObject[] enemies = GameLogic.instance.enemies;

		foreach (GameObject enemy in enemies) {
			float distanceToEnemy = Vector3.Distance (this.transform.position, enemy.transform.position);
			if (distanceToEnemy < smallestDistance) {
				result = enemy;
				smallestDistance = Vector3.Distance (this.transform.position, enemy.transform.position);
			}
		}
		return result;
	}

	void Shoot(GameObject enemy) {
		if (FireProjectileEffect != null) {
			var effect = (GameObject) Instantiate (FireProjectileEffect, ProjectileFireLocation.position, ProjectileFireLocation.rotation);
			effect.transform.parent = transform;
		}

		Transform bullet = (Transform) Instantiate (BulletPrefab, this.transform.position, this.transform.rotation);
		BulletLogic b = bullet.GetComponent<BulletLogic> ();
		b.target = enemy;

		/*Sons para accoes do jogador*/
		AudioSource.PlayClipAtPoint (TowerShootSound, transform.position);
	}
}
