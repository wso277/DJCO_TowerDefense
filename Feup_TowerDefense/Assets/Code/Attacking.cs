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

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("collision");
        if (collider.transform.parent != null && collider.transform.parent.name == "Towers")
        {
            //Debug.Log("Tower");
            anim.Play("bowMoblinAttack");
            MovementScript moblinMovScript = gameObject.GetComponent("MovementScript") as MovementScript;
            moblinMovScript.movementSpeed = 0.5f;
            GameObject newArrow = Instantiate(arrow) as GameObject;
            Transform arrowTransform = newArrow.transform;
			arrowTransform.position = new Vector3(transform.position.x + (Mathf.Cos((collider.transform.position.x - transform.position.x))*0.5f), transform.position.y + (Mathf.Sin((collider.transform.position.y - transform.position.y))*0.2f), transform.position.z);
            MovementScript movScript = newArrow.GetComponent("MovementScript") as MovementScript;
            Debug.Log(collider.gameObject.name);
            movScript.pathName = collider.gameObject.name;
            movScript.active = true;
            moblinMovScript.movementSpeed = 10;
        }
        else
        {
            Debug.Log("collision");
        }
    }

}
