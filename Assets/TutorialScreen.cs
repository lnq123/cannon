using UnityEngine;
using System.Collections;

public class TutorialScreen : MonoBehaviour {

	private int box_h = 600;
	private int box_w = 900;
	public Rect windowRect = new Rect(50, 50, 50, 50);

	void OnGUI(){
		windowRect = GUI.Window (14, new Rect ((Screen.width - box_w)/2, (Screen.height - box_h)/2 , box_w, box_h), DoMyWindow3, "Welcome to Egyptian Shooter!");
	}
	
	void DoMyWindow3(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 23;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		//GUIStyle myStyle2 = new GUIStyle ();
		//myStyle2.fontSize = 20;
		//myStyle2.normal.textColor = Color.white;
		myStyle.normal.textColor = Color.white;
		int text_h = 80;
		int text_w = 50;
		GUI.Label (new Rect (200, 250, 500, 70), "Welcome to Egyptian Shooter! The goal of this game is to teach you" +
			"," + "\n\n"+ "The Great Egyptian Guardian" + "\n\nthe laws of projectile motion in Physics.", myStyle);

		if (GUI.Button (new Rect (250, 430, 150, 20), "Main Menu")) {
			Application.LoadLevel("TitleScreen");
		}
		if (GUI.Button (new Rect (500, 430, 150, 20), "Next")) {
			Application.LoadLevel("TutorialScreen2");
		}
	}
}
