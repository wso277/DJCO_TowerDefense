﻿using UnityEngine;
using System.Collections;

public class Tower1Spawner : MonoBehaviour {

	private Vector3 mousePosition;

	public float moveSpeed = 1f;

	public Transform towerPrefab;
	private Transform tower;

	private GameLogic logicScript;

	// Use this for initialization
	void Start () {
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition.z = -7.84f;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		mousePosition.x = -mousePosition.x;
		mousePosition.y = -mousePosition.y + 3;
		mousePosition.z = 0;

		//transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
		transform.position = mousePosition;
		//Debug.Log ("x: " + mousePosition.x + " y: " + mousePosition.y + " z: " + mousePosition.z);

		if (Input.GetMouseButtonDown (0)) {
			if(mousePosition.x >= GameObject.Find("TowerZone").transform.position.x
			   && mousePosition.y <= GameObject.Find("TowerZone").transform.position.y
			   && mousePosition.x <= GameObject.Find("TowerZone2").transform.position.x
			   && mousePosition.y >= GameObject.Find("TowerZone2").transform.position.y
			   || mousePosition.x >= GameObject.Find("TowerZoneC1").transform.position.x
			   && mousePosition.y <= GameObject.Find("TowerZoneC1").transform.position.y
			   && mousePosition.x <= GameObject.Find("TowerZoneC2").transform.position.x
			   && mousePosition.y >= GameObject.Find("TowerZoneC2").transform.position.y
			   || mousePosition.x <= GameObject.Find("TowerZoneP4").transform.position.x
			   && mousePosition.y <= GameObject.Find("TowerZoneP4").transform.position.y
			   && mousePosition.y >= GameObject.Find("TowerZoneP5").transform.position.y
			   ){
				tower = (Transform)Instantiate (towerPrefab, this.transform.position, this.transform.rotation);
				tower.parent = GameObject.Find("Towers").transform;
				logicScript.currentTower++;
				tower.gameObject.name = "Tower" + "" + logicScript.currentTower;
				Destroy(gameObject);}
		}
	}
}
