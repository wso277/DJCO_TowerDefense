using UnityEngine;
using System.Collections;

public class Attacking : MonoBehaviour {

	public GameObject arrow;
	private GameObject newArrow;

    public Animator anim;

	private string currentTowerName;

	private MovementScript moblinMovScript;

	private ArrowMovement movScript;

	private Transform arrowTransform;

	private bool alreadyAttacking;

	private float targetAngle;

	private Vector3 relative;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
		alreadyAttacking = false;
		moblinMovScript = gameObject.GetComponent("MovementScript") as MovementScript;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find (currentTowerName) == null) {
			currentTowerName = "";
			alreadyAttacking = false;
			anim.Play("bowMoblinWalk");
			moblinMovScript.movementSpeed = 10;
            moblinMovScript.rotate = true;
		}
	}
	
	void InstantiateArrow(Collider2D collider) {
		if (collider != null) {
			newArrow = Instantiate (arrow) as GameObject;
			arrowTransform = newArrow.transform;
			// Set the arrow position to be just in front of the moblin, according to the moblin and the tower position
			arrowTransform.position = new Vector3 (transform.position.x + (Mathf.Cos ((collider.transform.position.x - transform.position.x)) * 0.5f), transform.position.y + (Mathf.Sin ((collider.transform.position.y - transform.position.y)) * 0.2f), transform.position.z);
			// Set the path the arrow has to follow
			relative = collider.gameObject.transform.position - transform.position;
			targetAngle = Mathf.Atan2 (relative.y, relative.x) * Mathf.Rad2Deg - 90;
			transform.rotation = Quaternion.Euler (0, 0, targetAngle);
			moblinMovScript.rotate = false;
			movScript = newArrow.GetComponent ("ArrowMovement") as ArrowMovement;
			movScript.pathName = collider.gameObject.name;
			movScript.active = true;
		} else {
			anim.Play ("bowMoblinWalk");
			moblinMovScript.movementSpeed = 10;
			alreadyAttacking = false;
			moblinMovScript.rotate = true;
		}
	}

	// Repeatedly attacks the tower with whom he has collided
	IEnumerator StayAndAttack(Collider2D collider) {
		alreadyAttacking = true;
		if (currentTowerName != "") {
			if (GameObject.Find (currentTowerName) != null) {
				anim.Play ("bowMoblinAttack");
				moblinMovScript.movementSpeed = 2;
				InstantiateArrow (collider);
				yield return new WaitForSeconds (1f);
				StartCoroutine (StayAndAttack (collider));
			} else {
				anim.Play ("bowMoblinWalk");
				moblinMovScript.movementSpeed = 10;
				alreadyAttacking = false;
				moblinMovScript.rotate = true;
			}
		} else {
			anim.Play ("bowMoblinWalk");
			moblinMovScript.movementSpeed = 10;
			alreadyAttacking = false;
			moblinMovScript.rotate = true;
		}
	}

	// Collision detection
    void OnTriggerEnter2D(Collider2D collider)
    {
		// if it collided with a tower
        if (collider.transform.parent != null && collider.transform.parent.name == "Towers")
        {
			currentTowerName = collider.gameObject.name;
			if (!alreadyAttacking) 
			StartCoroutine(StayAndAttack(collider));
        }

    }

	
}
