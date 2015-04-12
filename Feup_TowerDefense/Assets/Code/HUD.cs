using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	// Use this for initialization

	private GameLogic logicScript;
	private Rect healthTextArea;
	private string healthText;
	private GUIStyle style;

    private Rect chargeTextArea;
    private string chargeText;
    private GUIStyle chargestyle;

	void Start () {
		logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
		healthTextArea = new Rect(30,30,Screen.width, Screen.height);
		style = new GUIStyle();
		style.fontSize = 20;
        chargeTextArea = new Rect(700, 20, Screen.width, Screen.height);
        chargestyle = new GUIStyle();
        chargestyle.fontSize = 20;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI() {
		healthText = logicScript.currentLifePoints.ToString() + "/" + logicScript.totalLifePoints.ToString();
		GUI.contentColor = Color.black;
		GUI.Label(healthTextArea,healthText,style);
        if (logicScript.towerCharges == 1)
        {
            chargeText = "You can place " + logicScript.towerCharges + " tower";
        }
        else
        {
            chargeText = "You can place " + logicScript.towerCharges + " towers";
        }
        GUI.Label(chargeTextArea, chargeText, chargestyle);
	}
}
