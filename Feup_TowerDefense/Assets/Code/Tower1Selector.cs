using UnityEngine;
using System.Collections;

public class Tower1Selector : MonoBehaviour {

	public Sprite normal;
	public Sprite hover;
	public Transform SpawnerPrefab;

	private SpriteRenderer spriteRenderer; 

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();

		if (spriteRenderer.sprite == null) {
			spriteRenderer.sprite = normal;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		spriteRenderer.sprite = hover;
	}

	void OnMouseExit () {
		spriteRenderer.sprite = normal;
	}

	void OnMouseUp () {
		Instantiate (SpawnerPrefab, this.transform.position, this.transform.rotation);
	}
}
