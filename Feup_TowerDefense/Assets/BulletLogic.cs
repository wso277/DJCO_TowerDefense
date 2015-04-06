using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	public GameObject target;
	public float speed = 4.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(target != null) {
			var translation = target.transform.position - transform.position;
			transform.Translate(translation * speed * Time.deltaTime);
		}
	}


}
