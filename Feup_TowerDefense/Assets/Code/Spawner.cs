using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject enemy1, enemy2, enemy3;
	public float spawnTime = 10f;
	public float sleepBetweenSpawn = 3f;
	public delegate void Spawn();

	// Use this for initialization
	void Start () {
		StartCoroutine (TimeDecreaser(spawnTime));
		StartCoroutine(InvokeRepeatingRange(NewEnemy1,spawnTime, 0, 10));
		StartCoroutine(InvokeRepeatingRange(NewEnemy2,spawnTime, 0, 10));
		StartCoroutine(InvokeRepeatingRange(NewEnemy3,spawnTime, 0, 10));
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator TimeDecreaser(float timeUntilStart) {
		if (spawnTime > 0.5f) {
			yield return new WaitForSeconds (timeUntilStart);
			spawnTime -= 0.5f;
			if (sleepBetweenSpawn > 1f) {
				sleepBetweenSpawn -= 0.75f;
			}
			StartCoroutine (TimeDecreaser (spawnTime));
		}
	}

	IEnumerator InvokeRepeatingRange(Spawn spawner, float timeUntilStart, float initTime, float endTime) {
		float currentTime = endTime;
		yield return new WaitForSeconds (timeUntilStart);
		if (spawnTime > 0.5f) {
			StartCoroutine (InvokeRepeatingRange (spawner, spawnTime, 0, 10));
		}
		while (currentTime > initTime && sleepBetweenSpawn > 0) {
			spawner ();
			currentTime -= sleepBetweenSpawn;
			Debug.Log (currentTime);
			Debug.Log (sleepBetweenSpawn);
			yield return new WaitForSeconds (0.15f);
		}
	}

	void  NewEnemy1() {
		GameObject newEnemy = Instantiate (enemy1) as GameObject;
		MovementScript movScript = newEnemy.GetComponent ("MovementScript") as MovementScript;
		movScript.active = true;
	}

	void  NewEnemy2() {
		GameObject newEnemy = Instantiate (enemy2) as GameObject;
		MovementScript movScript = newEnemy.GetComponent ("MovementScript") as MovementScript;
		movScript.active = true;
	}

	void  NewEnemy3() {
		GameObject newEnemy = Instantiate (enemy3) as GameObject;
		MovementScript movScript = newEnemy.GetComponent ("MovementScript") as MovementScript;
		movScript.active = true;
	}
}
