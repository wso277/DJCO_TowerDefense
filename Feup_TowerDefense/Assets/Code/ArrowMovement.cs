using UnityEngine;
using System.Collections;

public class ArrowMovement : MonoBehaviour {

	private Transform waypoint;
	
	public float movementSpeed = 3f;

	public string pathName = "Tower1";

	public bool active = true;

	private TowerLife towerLifeScript;
	
	// Use this for initialization
	void Start () 
	{
		waypoint = GameObject.Find (pathName).transform;
		towerLifeScript = GameObject.Find(pathName).GetComponent<TowerLife>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.Find(pathName) == null) {
			Destroy(gameObject);
		}
	}
	
	// Fixed update
	void FixedUpdate()
	{
		if (active)
			handleWalkWaypoints();
	}
	
	// Handle walking the waypoints
	private void handleWalkWaypoints()
	{
		Vector3 relative = waypoint.position - transform.position;
		Vector3 movementNormal = Vector3.Normalize(relative);
		float distanceToWaypoint = relative.magnitude;
		float targetAngle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90;
		
		if (distanceToWaypoint < 0.1)
		{
				// Inform level script that a unit has reached the last waypoint
				Destroy(gameObject);
				towerLifeScript.TakeDamage(1);
				return;
		}
		else
		{
			// Walk towards waypoint
			GetComponent<Rigidbody2D>().AddForce(new Vector2(movementNormal.x, movementNormal.y) * movementSpeed);
		}
		
		// Face walk direction
		transform.rotation = Quaternion.Euler(0, 0, targetAngle);
	}
}
