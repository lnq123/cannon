using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;


public class VelocityShooter2 : MonoBehaviour {
	
	GameObject lost;
	GameObject fire;
	GameObject prefab;
	public int varVelocity;
	private string var = "0";
	private int lengthOfText = 3;
	
	/*public Text VelocityText;
	public Text DistanceText;
	public Text DistanceTraveledText;*/
	
	public float distance;
	public GameObject target;
	public float distanceTraveled;
	public float varTime;
	public int attempts;
	
	private bool showPopUp = false;
	private bool showPopUp2 = false;
	private bool showTutorial = true;
	private bool showLose = false;
	private int var_h = 200;
	private int var_w = 420;
	private int box_h = 280;
	private int box_w = 420;
	public Rect windowRect = new Rect(50, 50, 50, 50);
	public Rect windowRect2 = new Rect (50, 50, 50, 50);
	
	public float startTime;
	public float ellapsedTime;
	
	public Camera cam;
	public Camera cam2;
	
	// Load projectiles and text 
	void Start () {
		prefab = Resources.Load ("rocket") as GameObject;
		varVelocity = 0;
		attempts = 3;
		//SetVelocityText ();
		target = GameObject.Find ("Target");
		lost = GameObject.Find ("Lost");
		lost.SetActive (false);
		//SetDistanceText ();
		cam.enabled = true;
		cam2.enabled = false;
		fire = Resources.Load ("Fire") as GameObject;
		distance = Mathf.Abs(transform.position.x - target.transform.position.x);
		distance = distance * 49;
		varTime = 2.74f;
	}
	
	// Displays windows 
	void OnGUI(){
		// Displays a box for users to input variables (only accepts integers)
		//var = GUI.TextField (new Rect (Screen.width - 1420, Screen.height - 663, 150, 35), var, lengthOfText);
		//var = Regex.Replace (var, "[^0-9]", "");
		windowRect = GUI.Window (34, new Rect ((Screen.width - box_w)/16, (Screen.height - box_h) - 70 , box_w, box_h), DoMyWindow3, "Variables (Velocity : Hard)");
		
		if (showTutorial) {
			windowRect2 = GUI.Window (36, new Rect ((Screen.width - box_w) / 2, (Screen.height - box_h) / 2, box_w, box_h), DoMyWindow4, "Velocity Hard");
		}
		// Shows a window when player hits the target
		if (showPopUp) {
			windowRect = GUI.Window ( 30, new Rect((Screen.width - var_w)/2, (Screen.height - var_h)/2, var_w, var_h), DoMyWindow, 
			                         "You Got It! Next Challenge?");
		}
		if (showPopUp2) {
			windowRect = GUI.Window (32, new Rect ((Screen.width - var_w) / 2, (Screen.height - var_h) / 2, var_w, var_h), DoMyWindow2, "Egyptian Shooter");
		}
		if (showLose) {
			windowRect = GUI.Window (38, new Rect ((Screen.width - var_w) / 2, (Screen.height - var_h) / 2, var_w, var_h), DoMyWindow5, "You Lost");
		}
	}
	
	// Part of the win window screen, has options for continue or stay
	/*void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (100, 50, 220, 20), "Next Phase (Velocity-Easy)")) {
			Application.LoadLevel ("Velocity");
		}
		
		if (GUI.Button (new Rect (100, 90, 250, 20), "Remain in this Phase (Velocity-Tutorial)")) {
			Application.LoadLevel ("begin for Velocity");
		}
	}*/
	
	void DoMyWindow(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.white;
		
		GUI.Label (new Rect (70, 40, 300, 70), "Your Velocity training is complete! Now we will move on to changing the Angle. Are you ready?", myStyle);
		
		if (GUI.Button (new Rect (45, 135, 150, 20), "Angle Tutorial")) {
			Application.LoadLevel("AngleTutorial");
		}
		if (GUI.Button (new Rect (235, 135, 150, 20), "Replay Hard")) {
			Application.LoadLevel ("VelocityHard");
		}
	}
	
	void DoMyWindow2(int windowID) {
		if (GUI.Button (new Rect (150, 50, 150, 20), "Main Menu")) {
			Application.LoadLevel ("TitleScreen");
		}
		
		if (GUI.Button (new Rect (150, 90, 150, 20), "Restart Phase")) {
			Application.LoadLevel ("VelocityHard");
		}
		
		if (GUI.Button (new Rect (150, 130, 150, 20), "Exit Game?")) {
			Application.Quit ();
		}
	}
	
	void DoMyWindow3(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 16;
		GUIStyle myStyle2 = new GUIStyle ();
		myStyle2.fontSize = 20;
		myStyle2.normal.textColor = Color.white;
		myStyle.normal.textColor = Color.white;
		GUI.Label (new Rect (80, 45, 80, 35), "Velocity (0 - 999): ", myStyle);
		var = GUI.TextField (new Rect (210, 40, 80, 30), var, lengthOfText);
		var = Regex.Replace (var, "[^0-9]", "");
		GUI.Label (new Rect (300, 45, 80, 35), "Meters ", myStyle);
		
		GUI.Label (new Rect (160, 80, 130, 30), "Angle: 45 Degrees", myStyle);
		GUI.Label (new Rect (160, 110, 130, 30), "Time: " + varTime.ToString() + " Seconds", myStyle);
		GUI.Label (new Rect (90, 140, 360, 30), "Approximate Distance Away: " + distance.ToString(), myStyle);
		GUI.Label (new Rect (40, 170, 360, 30), "Equation: Distance = Velocity(cos(Angle)) * Time", myStyle);
		GUI.Label (new Rect (70, 200, 360, 30), "Distance Traveled after " + varTime.ToString() +  " seconds: " + distanceTraveled.ToString(), myStyle);
		GUI.Label (new Rect (160, 230, 360, 30), "Attempts Left: " + attempts.ToString(), myStyle2);
	}
	
	void DoMyWindow4(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.white;
		int text_h = 80;
		int text_w = 50;
		GUI.Label (new Rect (70, 90, 300, 70), "You are now in a challenge! In a hard challenge you only have 3 attempts to hit the target. " +
		           "Hit the target and move on to the angle challenges! ", myStyle);
		
		if (GUI.Button (new Rect (145, 200, 150, 20), "Got it!")) {
			showTutorial = false;
		}
	}
	
	void DoMyWindow5(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.white;
		
		GUI.Label (new Rect (70, 40, 300, 70), "You failed to hit the target.", myStyle);
		
		if (GUI.Button (new Rect (45, 135, 150, 20), "Try Again")) {
			Application.LoadLevel("VelocityHard");
		}
		if (GUI.Button (new Rect (235, 135, 150, 20), "Main Menu")) {
			Application.LoadLevel ("TitleScreen");
		}
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler((-45), 90, 0);
		
		//SetDistanceText();
		
		varVelocity = int.Parse (var);
		
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (attempts > 0){
				startTime = Time.time;
				attempts--;
				StartCoroutine (TimerStart ());
				if (attempts == 0) {
					StartCoroutine (TimerStart2 ());
				}
			}
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			cam.enabled = !cam.enabled;
			cam2.enabled = !cam2.enabled;
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)){
			showPopUp2 = !showPopUp2;
		}
		
		//SetVelocityText();
		if (target.activeSelf == false) {
			ellapsedTime = Time.time - startTime;
			showPopUp = true;
			GameObject Fire = Instantiate (fire) as GameObject;
			Fire.transform.position = target.transform.position;
		}
	}
	
	IEnumerator TimerStart(){
		GameObject Projectile = Instantiate (prefab) as GameObject;
		Projectile.transform.position = transform.position;
		//Projectile.transform.parent = GameObject.Find ("Projectile").transform;
		Rigidbody rb = Projectile.GetComponent<Rigidbody> ();
		//rb.AddForce (transform.up * 400);
		rb.AddForce(transform.forward* varVelocity);
		yield return new WaitForSeconds (varTime);
		distanceTraveled = Mathf.Abs(transform.position.x - rb.transform.position.x);
		distanceTraveled = (distanceTraveled * 50);
		
	}
	
	IEnumerator TimerStart2(){
		yield return new WaitForSeconds (3.75f);
		if (target.activeSelf == true) {
			lost.SetActive (true);
			showLose = true;
		}
	}
	
	/*void SetDistanceTraveledText(){
		DistanceTraveledText.text = "Distance Traveled after " + varTime.ToString () + " seconds: " + distanceTraveled.ToString();
	}
	
	void SetVelocityText() {
		VelocityText.text = "Velocity (0 - 999): " + varVelocity.ToString () + " Meters Per Second";
	}
	
	
	void SetDistanceText() {
		distance = distance * 48;
		DistanceText.text = "Approximate Distance Away: " + distance.ToString () + " Meters";
	}*/
}