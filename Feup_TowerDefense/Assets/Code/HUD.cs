using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Use this for initialization

	private GameLogic logicScript;

	void Start () {
	
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Rect textArea = new Rect(0,0,Screen.width, Screen.height);
	
	void OnGUI() {
			GUI.Label(textArea,logicScript.lifePoints.ToString());
	}
}
