﻿using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public void OnGUI(){
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 3, Screen.width / 5, Screen.height / 10), "Play Game")) {
			Application.LoadLevel("scene");
		}
		if (GUI.Button (new Rect (Screen.width / 2.5f, Screen.height / 2, Screen.width / 5, Screen.height / 10), "Exit Game")) {
			Application.Quit ();
		}
	}
}
