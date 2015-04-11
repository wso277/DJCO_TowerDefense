using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Use this for initialization

	private GameLogic logicScript;
	private Rect healthTextArea;
	private string healthText;
	private GUIStyle style;

	void Start () {
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
		healthTextArea = new Rect(30,30,Screen.width, Screen.height);
		style = new GUIStyle();
		style.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		healthText = logicScript.currentLifePoints.ToString() + "/" + logicScript.totalLifePoints.ToString();
		GUI.contentColor = Color.black;
		GUI.Label(healthTextArea,healthText,style);
	}
}
