using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

	public GameObject bowMoblinEnemy1, bowMoblinEnemy2, spearMoblinEnemy;

    public float spawnTime = 10f;
    public float sleepBetweenSpawn = 3f;
    public float endSpawnTime = 10f;
	public float sleepBetweenEachEnemy = 0.2f;

    public delegate void Spawn();

	public GameLogic logicScript;

    // Use this for initialization
    void Start()
    {
		logicScript = GameObject.Find ("GameLogic").GetComponent<GameLogic> ();
		InitialWave();
        StartCoroutine(TimeDecreaser(spawnTime));
		StartCoroutine(InvokeRepeatingRange(NewBowMoblinEnemy1, spawnTime, 0, endSpawnTime));
		StartCoroutine(InvokeRepeatingRange(NewBowMoblinEnemy2, spawnTime, 0, endSpawnTime));
		StartCoroutine(InvokeRepeatingRange(NewSpearMoblinEnemy, spawnTime, 0, endSpawnTime));
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator TimeDecreaser(float timeUntilStart)
    {
        if (spawnTime > 1f)
        {
            yield return new WaitForSeconds(timeUntilStart);
            if (endSpawnTime < 15)
            {
                endSpawnTime += 0.5f;
            }
            spawnTime -= 0.5f;
            if (sleepBetweenSpawn > 1f)
            {
                sleepBetweenSpawn -= 0.75f;
            }
			logicScript.towerCharges += 1 + (int) (10-spawnTime)*1;
            StartCoroutine(TimeDecreaser(spawnTime));
        }
    }

	// This function is invoked after timeUntilStart seconds, and it spawns a wave of enemies, where the enemy type is specified via the spawner function
    IEnumerator InvokeRepeatingRange(Spawn spawner, float timeUntilStart, float initTime, float endTime)
    {
        float currentTime = endTime;
        yield return new WaitForSeconds(timeUntilStart);
        if (spawnTime > 1f)
        {
            StartCoroutine(InvokeRepeatingRange(spawner, spawnTime, 0, endSpawnTime));
        }
        while (currentTime > initTime && sleepBetweenSpawn > 0)
        {
            spawner();
            currentTime -= sleepBetweenSpawn;
			yield return new WaitForSeconds(sleepBetweenEachEnemy);
        }
    }

	//Spawns the initial wave -> 1 enemy of each kind
	void InitialWave() {
		NewBowMoblinEnemy1();
		NewBowMoblinEnemy2();
		NewSpearMoblinEnemy();
	}

	//Instatiates a bow moblin enemy
	void NewBowMoblinEnemy1()
    {
		GameObject newEnemy = Instantiate(bowMoblinEnemy1) as GameObject;
		newEnemy.tag = "Enemy";
        MovementScript movScript = newEnemy.GetComponent("MovementScript") as MovementScript;
        movScript.active = true;
        newEnemy.GetComponent<CircleCollider2D>().enabled = true;
    }

	//Instatiates a bow moblin enemy, with a different path from number 1
	void NewBowMoblinEnemy2()
    {
		GameObject newEnemy = Instantiate(bowMoblinEnemy2) as GameObject;
		newEnemy.tag = "Enemy";
        MovementScript movScript = newEnemy.GetComponent("MovementScript") as MovementScript;
        movScript.active = true;
        newEnemy.GetComponent<CircleCollider2D>().enabled = true;
    }

	//Instatiates a spear moblin enemy
	void NewSpearMoblinEnemy()
    {
		GameObject newEnemy = Instantiate(spearMoblinEnemy) as GameObject;
		newEnemy.tag = "Enemy";
        MovementScript movScript = newEnemy.GetComponent("MovementScript") as MovementScript;
        movScript.active = true;
        newEnemy.GetComponent<CircleCollider2D>().enabled = true;
    }
}
