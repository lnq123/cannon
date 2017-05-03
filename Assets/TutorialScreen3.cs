using UnityEngine;
using System.Collections;

public class TutorialScreen3 : MonoBehaviour {
	
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
		GUI.Label (new Rect (170, 250, 600, 70), "The main equations needed to understand projectile motion is" + 
		           "\n\n" + "Horizontal_Distance = Velocity * Cos(Angle) * Time" + "\n" + "Vertical_Distance = Velocity * Sin(Angle) * Time" +
		           "\n\nEgyptian Shooter focuses mainly on the Horizontal Distance, but do keep Vertical Distance in mind!", myStyle);
		
		if (GUI.Button (new Rect (250, 430, 150, 20), "Back")) {
			Application.LoadLevel("TutorialScreen2");
		}
		if (GUI.Button (new Rect (500, 430, 150, 20), "Next")) {
			Application.LoadLevel("TutorialScreen4");
		}
	}
}
