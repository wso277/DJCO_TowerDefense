using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour
{

    // Use this for initialization

    private GameLogic logicScript;
    private Rect healthTextArea;
    private string healthText;
    private GUIStyle style;

    private Rect chargeTextArea;
    private string chargeText;
    private GUIStyle chargestyle;

    void Start()
    {
        logicScript = GameObject.Find("GameLogic").GetComponent<GameLogic>();
        healthTextArea = new Rect(30, 30, Screen.width, Screen.height);
        style = new GUIStyle();
        style.fontSize = 20;
        chargeTextArea = new Rect(700, 20, Screen.width, Screen.height);
        chargestyle = new GUIStyle();
        chargestyle.fontSize = 20;
        chargestyle.normal.textColor = Color.red;
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
