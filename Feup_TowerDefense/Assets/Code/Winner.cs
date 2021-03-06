﻿using UnityEngine;
using System.Collections;

public class Winner : MonoBehaviour {

	private GameLogic logicScript;
	
	private Rect winTextArea;
	private Rect scoreTextArea;
	
	private string winText;
	private string scoreText;
	
	private GUIStyle style;
	private GUIStyle scorestyle;
	
	void Start()
	{
		winTextArea = new Rect(280, 30, Screen.width, Screen.height);
		style = new GUIStyle();
		style.fontSize = 60;
		style.normal.textColor = Color.white;
		scoreTextArea = new Rect(260, 100, Screen.width, Screen.height);
		scorestyle = new GUIStyle();
		scorestyle.fontSize = 30;
		scorestyle.normal.textColor = Color.white;
	}
	
	// Update is called once per frame
	void Update()
	{
		
	}

	void OnGUI()
	{
		winText = "You win!!";
		GUI.contentColor = Color.gray;
		GUI.Label(winTextArea, winText, style);
		
		scoreText = "Your score is: " + GameLogic.Score.ToString();
		
		GUI.Label(scoreTextArea, scoreText, scorestyle);
	}
}
