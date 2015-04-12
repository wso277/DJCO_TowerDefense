using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	public GameObject target;
    public GameObject tower;

	public float speed = 2000f;
	public float distanceToEnemy;

	private Vector3 velocity;
	public Vector3 relative;

	public EnemyLife enemyLifeScript;

	public void Start() {
		velocity = Vector3.zero;
	}

	// Update is called once per frame
	void Update () {

		if (target != null) {
			transform.position = Vector3.SmoothDamp (transform.position, target.transform.position, ref velocity, 0.05f);

			relative = target.transform.position - transform.position;
			distanceToEnemy = relative.magnitude;

			// If it has reached its target then display the take damage effect, decrease the enemy's life and destroy the bullet
			if (distanceToEnemy < 0.1) {
				enemyLifeScript = target.GetComponent<EnemyLife> ();
				if (tower != null && (tower.GetComponent<Weapon>().TakeDamageEnemyEffect != null || tower.GetComponent<MultiShotWeapon>().TakeDamageEnemyEffect != null))
                {
					Weapon weapon;
					if(tower.GetComponent<Weapon>().TakeDamageEnemyEffect != null) {
						weapon = tower.GetComponent<Weapon>();
					}
					else
						weapon = tower.GetComponent<MultiShotWeapon>();

                    weapon.effect = (GameObject)Instantiate(weapon.TakeDamageEnemyEffect, target.transform.position, target.transform.rotation);
                    weapon.effect.transform.parent = tower.transform;
                }

				enemyLifeScript.TakeDamage(1);
				
                Destroy (gameObject);
			}
		} else {
			Destroy (gameObject);
		}
	}
}
