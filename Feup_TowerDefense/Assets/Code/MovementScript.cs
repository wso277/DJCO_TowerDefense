using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	private int _targetWaypoint = 0;
	private Transform _waypoints;
	
	public float movementSpeed = 3f;
    public string pathName = "Waypoints";
	public bool active = true;
	private GameLogic logicScript;
	
	// Use this for initialization
	void Start () 
	{
		_waypoints = GameObject.Find (pathName).transform;
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
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
		Transform targetWaypoint = _waypoints.GetChild(_targetWaypoint);
		Vector3 relative = targetWaypoint.position - transform.position;
		Vector3 movementNormal = Vector3.Normalize(relative);
		float distanceToWaypoint = relative.magnitude;
		float targetAngle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90;
		
		if (distanceToWaypoint < 0.1)
		{
			if (_targetWaypoint + 1 < _waypoints.childCount)
			{
				// Set new waypoint as target
				_targetWaypoint++;
			}
			else
			{
				// Inform level script that a unit has reached the last waypoint
				logicScript.lifePoints--;
				Destroy(gameObject);
				return;
			}
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