using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{
    private GameLogic logicScript;

	private Rect healthTextArea;
	private Rect chargeTextArea;

	private string healthText;
	private string chargeText;

    private GUIStyle style;
    private GUIStyle chargestyle;

    void Start()
    {
        logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        healthTextArea = new Rect(30, 30, Screen.width, Screen.height);
        style = new GUIStyle();
        style.fontSize = 20;
        chargeTextArea = new Rect(1070, 7, Screen.width, Screen.height);
        chargestyle = new GUIStyle();
        chargestyle.fontSize = 30;
        chargestyle.normal.textColor = Color.green;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        healthText = logicScript.currentLifePoints.ToString() + "/" + logicScript.totalLifePoints.ToString();
        GUI.contentColor = Color.gray;
        GUI.Label(healthTextArea, healthText, style);

        chargeText = logicScript.towerCharges.ToString();

        GUI.Label(chargeTextArea, chargeText, chargestyle);
    }
}
