using UnityEngine;
using System.Collections;

public class Tower2Selector : MonoBehaviour {
	
	public Sprite normal;
	public Sprite hover;
	
	public Transform SpawnerPrefab;
	
	private SpriteRenderer spriteRenderer;
	
	private GameLogic logicScript; 
	
	// Use this for initialization
	void Start () {
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
		
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = normal;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseOver () {
		if (logicScript.towerCharges >= 3)
			spriteRenderer.sprite = hover;
	}
	
	void OnMouseExit () {
		if (logicScript.towerCharges >= 3)
			spriteRenderer.sprite = normal;
	}
	
	void OnMouseUp () {
		if (logicScript.towerCharges >= 3)
			Instantiate (SpawnerPrefab, this.transform.position, this.transform.rotation);
	}
}
