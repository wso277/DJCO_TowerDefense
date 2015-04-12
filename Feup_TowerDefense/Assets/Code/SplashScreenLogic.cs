using UnityEngine;
using System.Collections;

public class SplashScreenLogic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Restart")) {
			Application.LoadLevel("scene");
		}
	}
}
