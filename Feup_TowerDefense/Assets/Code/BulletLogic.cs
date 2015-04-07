using UnityEngine;
using System.Collections;

public class BulletLogic : MonoBehaviour {

	public GameObject target;
	public float speed = 1000.5f;
	private Vector3 velocity = Vector3.zero;

	// Update is called once per frame
	void Update () {
		if(target != null) {
			var translation = Vector3.Normalize(target.transform.position - transform.position);
			//transform.Translate(translation * speed * Time.deltaTime);

			//Vector3 point = camera.WorldToViewportPoint(target.position);
			//Vector3 delta = target.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			//Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp(transform.position, target.transform.position, ref velocity, 0.1f);
		}
	}
}
