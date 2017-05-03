using UnityEngine;
using System.Collections;

public class TutorialScreen4 : MonoBehaviour {
	
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
		GUI.Label (new Rect (200, 250, 500, 70), "We'll begin your training by focusing only on the Velocity for now. You may shoot an infinite amount " +
			"of missiles in the tutorial. As you progress through the level, you will begin to get easy, medium, and hard challenges!"
		           + "\n\n" + "Easy : 8 Attempts to Hit Target"
		           + "\n" + "Medium : 5 Attempts to Hit Target"
		           + "\n" + "Hard : 3 Attempts to Hit Target", myStyle);
		
		if (GUI.Button (new Rect (250, 430, 150, 20), "Back")) {
			Application.LoadLevel("TutorialScreen3");
		}
		if (GUI.Button (new Rect (500, 430, 150, 20), "Next")) {
			Application.LoadLevel("VelocityTutorial");
		}
	}
}
