using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Use this for initialization

	private GameLogic logicScript;
	Rect healthTextArea, scoreTextArea; 
	string healthText, scoreText;
	GUIStyle style;

	void Start () {
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
		healthTextArea = new Rect(30,30,Screen.width, Screen.height);
		scoreTextArea = new Rect(Screen.width-180,20,Screen.width, Screen.height);
		style = new GUIStyle();
		style.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		healthText = logicScript.currentLifePoints.ToString() + "/" + logicScript.totalLifePoints.ToString();
		scoreText = "Score: " + logicScript.score.ToString();
		GUI.contentColor = Color.black;
		GUI.Label(healthTextArea,healthText,style);
		GUI.Label(scoreTextArea,scoreText,style);
	}
}
