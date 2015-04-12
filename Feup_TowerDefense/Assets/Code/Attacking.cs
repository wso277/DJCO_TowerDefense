using UnityEngine;
using System.Collections;

public class Attacking : MonoBehaviour {

	public GameObject arrow;
	private GameObject newArrow;

    public Animator anim;

	private string currentTowerName;

	private MovementScript moblinMovScript;

	private Transform arrowTransform;

	private bool alreadyAttacking;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		alreadyAttacking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find (currentTowerName) == null) {
			currentTowerName = "";
			alreadyAttacking = false;
			anim.Play("bowMoblinWalk");
			moblinMovScript.movementSpeed = 10;
		}
	}
	
	void InstantiateArrow(Collider2D collider) {
		newArrow = Instantiate(arrow) as GameObject;
		arrowTransform = newArrow.transform;
		// Set the arrow position to be just in front of the moblin, according to the moblin and the tower position
		arrowTransform.position = new Vector3(transform.position.x + (Mathf.Cos((collider.transform.position.x - transform.position.x))*0.5f), transform.position.y + (Mathf.Sin((collider.transform.position.y - transform.position.y))*0.2f), transform.position.z);
		// Set the path the arrow has to follow
		Vector3 relative = collider.transform.position - transform.position;
		float targetAngle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90;
		transform.rotation = Quaternion.Euler (0, 0, targetAngle);
		ArrowMovement movScript = newArrow.GetComponent("ArrowMovement") as ArrowMovement;
		movScript.pathName = collider.gameObject.name;
		movScript.active = true;
	}

	// Repeatedly attacks the tower with whom he has collided
	IEnumerator StayAndAttack(Collider2D collider) {
		alreadyAttacking = true;
		if (currentTowerName != "") {
			if (GameObject.Find (currentTowerName) != null) {
				anim.Play("bowMoblinAttack");
				InstantiateArrow(collider);
				yield return new WaitForSeconds(1f);
				StartCoroutine(StayAndAttack(collider));
			} else {
                anim.Play("bowMoblinWalk");
				moblinMovScript.movementSpeed = 10;
				alreadyAttacking = false;
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
			// Make it so that the enemy starts focusing the tower and shooting at it repeatedly
			if (!alreadyAttacking) 
			StartCoroutine(StayAndAttack(collider));
        }

    }

	
}
