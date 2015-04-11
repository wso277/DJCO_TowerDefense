using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	public GameObject target;

	public float speed = 1000.5f;
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
			transform.position = Vector3.SmoothDamp (transform.position, target.transform.position, ref velocity, 0.1f);

			relative = target.transform.position - transform.position;
			distanceToEnemy = relative.magnitude;

			if (distanceToEnemy < 0.1) {
				enemyLifeScript = target.GetComponent<EnemyLife> ();
				enemyLifeScript.TakeDamage (1);
				Destroy (gameObject);
			}
		}
	}
}
