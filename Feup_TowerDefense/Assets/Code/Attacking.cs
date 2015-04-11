using UnityEngine;
using System.Collections;

public class Attacking : MonoBehaviour {

    public GameObject arrow;
    public Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	// Collision detection
    void OnTriggerEnter2D(Collider2D collider)
    {
		// if it collided with a tower
        if (collider.transform.parent != null && collider.transform.parent.name == "Towers")
        {
			//change animation to attack the tower
            anim.Play("bowMoblinAttack");
            MovementScript moblinMovScript = gameObject.GetComponent("MovementScript") as MovementScript;
            moblinMovScript.movementSpeed = 0.5f;
            GameObject newArrow = Instantiate(arrow) as GameObject;
            Transform arrowTransform = newArrow.transform;
			// Set the arrow position to be just in front of the moblin, according to the moblin and tower position
			arrowTransform.position = new Vector3(transform.position.x + (Mathf.Cos((collider.transform.position.x - transform.position.x))*0.5f), transform.position.y + (Mathf.Sin((collider.transform.position.y - transform.position.y))*0.2f), transform.position.z);
            // Set the path the arrow has to follow
			ArrowMovement movScript = newArrow.GetComponent("ArrowMovement") as ArrowMovement;
            movScript.pathName = collider.gameObject.name;
            movScript.active = true;
            moblinMovScript.movementSpeed = 10;
        }
        else
        {
        }
    }

}
