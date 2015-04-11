using UnityEngine;
using System.Collections;

public class Attacking : MonoBehaviour {

	public GameObject arrow;
	private GameObject newArrow;

    public Animator anim;

	private string currentTowerName;

	private MovementScript moblinMovScript;

	private Transform arrowTransform;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void InstantiateArrow(Collider2D collider) {
		newArrow = Instantiate(arrow) as GameObject;
		arrowTransform = newArrow.transform;
		// Set the arrow position to be just in front of the moblin, according to the moblin and the tower position
		arrowTransform.position = new Vector3(transform.position.x + (Mathf.Cos((collider.transform.position.x - transform.position.x))*0.5f), transform.position.y + (Mathf.Sin((collider.transform.position.y - transform.position.y))*0.2f), transform.position.z);
		// Set the path the arrow has to follow
		ArrowMovement movScript = newArrow.GetComponent("ArrowMovement") as ArrowMovement;
		movScript.pathName = collider.gameObject.name;
		movScript.active = true;
	}

	// Repeatedly attacks the tower with whom he has collided
	IEnumerator StayAndAttack(Collider2D collider) {
		if (currentTowerName != "") {
			if (GameObject.Find (currentTowerName) != null) {
				anim.Play("bowMoblinAttack");
				InstantiateArrow(collider);
				yield return new WaitForSeconds(1f);
				StartCoroutine(StayAndAttack(collider));
			} else {
                anim.Play("bowMoblinWalk");
				moblinMovScript.movementSpeed = 10;
			}
		}
	}

	// Collision detection
    void OnTriggerEnter2D(Collider2D collider)
    {
		// if it collided with a tower
        if (collider.transform.parent != null && collider.transform.parent.name == "Towers")
        {
			currentTowerName = collider.gameObject.name;
			//change animation to attack the tower
            anim.Play("bowMoblinAttack");
            moblinMovScript = gameObject.GetComponent("MovementScript") as MovementScript;
            moblinMovScript.movementSpeed = 2f;
			InstantiateArrow(collider);
			// Make it so that the enemy starts focusing the tower and shooting at it repeatedly
			StartCoroutine(StayAndAttack(collider));
        }

    }

	
}
