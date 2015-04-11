using UnityEngine;
using System.Collections;

public class gameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Exit"))
        {
            Application.Quit();
        }
        if (Input.GetButtonDown("Restart"))
        {
            Application.LoadLevel("scene");
        }
	}
}
