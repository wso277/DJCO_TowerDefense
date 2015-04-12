using UnityEngine;
using System.Collections;

public class Tower1Spawner : MonoBehaviour
{
    private Vector3 mousePosition;

    public float moveSpeed = 1f;

    public Transform TowerPrefab;

	private GameLogic logicScript;

    Ray ray;
    RaycastHit2D hit;

    // Use this for initialization
    void Start()
    {
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
    }

    // Update is called once per frame
    void Update() {
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
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity, LayerMask.GetMask("Zone"));
            if (hit.collider != null && hit.collider.gameObject.transform.parent.name == "TowerZone")
            {
				if (logicScript.towerCharges >= 1) {
                	hit.collider.gameObject.GetComponent<Collider2D>().enabled = false;
                	hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                
					Transform tower = (Transform)Instantiate (TowerPrefab, this.transform.position, this.transform.rotation);

					tower.parent = GameObject.Find("Towers").transform;
                	tower.GetComponent<TowerLife>().coll = hit.collider.gameObject.GetComponent<Collider2D>();
					logicScript.currentTower++;
					logicScript.towerCharges--;
					tower.gameObject.name = "Tower" + "" + logicScript.currentTower;
					Destroy(gameObject);
				}
	        }
		}
	}
}
