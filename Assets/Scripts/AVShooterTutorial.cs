using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;


public class AVShooterTutorial : MonoBehaviour {
	
	// Use this for initialization
	GameObject fire;
	GameObject prefab;
	private float varAngle;
	private float varVelocity;
	private string var = "0";
	private string var2 = "0";
	private string var3 = "0";
	private int lengthOfAngleText = 2;
	private int lengthOfVelocityText = 3;
	//private int lengthOfTimeText = 4;
	
	public float distance;
	public GameObject target;
	public float distanceTraveled;
	public float varTime;
	public string attempts = "--";
	
	private bool winScreen = false;
	private bool exitScreen = false;
	private bool showTutorial = true;
	private int var_h = 200;
	private int var_w = 420;
	private int box_h = 280;
	private int box_w = 420;
	public Rect windowRect = new Rect(50, 50, 50, 50);
	public Rect windowRect2 = new Rect(50, 50, 50, 50);
	
	public float startTime;
	public float ellapsedTime;
	
	public Camera cam;
	public Camera cam2;
	
	void Start () {
		prefab = Resources.Load ("rocket") as GameObject;
		varAngle = 0;
		varVelocity = 0;
		target = GameObject.Find ("Target");
		cam.enabled = true;
		cam2.enabled = false;
		fire = Resources.Load ("Fire") as GameObject;
		distance = Mathf.Abs(transform.position.x - target.transform.position.x);
		distance = distance * 48;
	}
	
	void OnGUI(){
		windowRect = GUI.Window (4, new Rect ((Screen.width - box_w)/16, (Screen.height - box_h) - 70 , box_w, box_h), DoMyWindow3, "Variables (Angle-Velocity : Tutorial)");

		if (showTutorial) {
			windowRect2 = GUI.Window (6, new Rect ((Screen.width - box_w) / 2, (Screen.height - box_h) / 2, box_w, box_h), DoMyWindow4, "Angle-Velocity Tutorial");
		}
		if (winScreen) {
			//windowRect = GUI.Window (10, centeredRect, DoMyWindow, "You Got It! Next Challenge?");
			windowRect = GUI.Window ( 10, new Rect((Screen.width - var_w)/2, (Screen.height - var_h)/2, var_w, var_h), DoMyWindow, 
			                         "You Got It! Next Challenge?");
		}
		if (exitScreen) {
			windowRect = GUI.Window (12, new Rect ((Screen.width - var_w) / 2, (Screen.height - var_h) / 2, var_w, var_h), DoMyWindow2, "Egyptian Shooter");
		}

	}
	
	void DoMyWindow(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.white;
		int text_h = 80;
		int text_w = 50;
		GUI.Label (new Rect (70, 40, 300, 70), "You got it! You may now continue onto Angle-Velocity challenges, or remain here in the tutorial.", myStyle);
		
		if (GUI.Button (new Rect (45, 135, 150, 20), "Easy Challenge")) {
			Application.LoadLevel("AVEasy");
		}
		if (GUI.Button (new Rect (235, 135, 150, 20), "Remain in Tutorial")) {
			Application.LoadLevel ("AVTutorial");
		}
	}
	
	void DoMyWindow2(int windowID) {
		if (GUI.Button (new Rect (150, 50, 150, 20), "Main Menu")) {
			Application.LoadLevel ("TitleScreen");
		}
		
		if (GUI.Button (new Rect (150, 90, 150, 20), "Restart Phase")) {
			Application.LoadLevel ("AVTutorial");
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
		var = GUI.TextField (new Rect (210, 40, 80, 30), var, lengthOfVelocityText);
		var = Regex.Replace (var, "[^0-9]", "");
		GUI.Label (new Rect (300, 45, 80, 35), "Meters", myStyle);

		GUI.Label (new Rect (90, 90, 80, 35), "Angle (0 - 99): ", myStyle);
		var2 = GUI.TextField (new Rect (210, 90, 80, 30), var2, lengthOfAngleText);
		var2 = Regex.Replace (var2, "[^0-9]", "");
		GUI.Label (new Rect (300, 90, 80, 35), "Degrees", myStyle);
		
		//GUI.Label (new Rect (160, 80, 130, 30), "Angle: 45 Degrees", myStyle);
		//GUI.Label (new Rect (160, 110, 130, 30), "Time: 1.60 Seconds", myStyle);
		GUI.Label (new Rect (90, 130, 360, 30), "Approximate Distance Away: " + distance.ToString(), myStyle);
		GUI.Label (new Rect (40, 160, 360, 30), "Equation: Distance = Velocity(cos(Angle)) * Time", myStyle);
		//GUI.Label (new Rect (70, 200, 360, 30), "Distance Traveled after 1.60 seconds: " + distanceTraveled.ToString(), myStyle);
		GUI.Label (new Rect (160, 200, 360, 30), "Attempts Left: --", myStyle2);
	}

	void DoMyWindow4(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		//GUIStyle myStyle2 = new GUIStyle ();
		//myStyle2.fontSize = 20;
		//myStyle2.normal.textColor = Color.white;
		myStyle.normal.textColor = Color.white;
		int text_h = 80;
		int text_w = 50;
		GUI.Label (new Rect (70, 90, 300, 70), "Use your knowledge from the past challenges to figure out good values for both angle " +
			"and velocity. Good luck!", myStyle);
		
		if (GUI.Button (new Rect (145, 200, 150, 20), "Got it!")) {
			showTutorial = false;
		}
	}

	// Update is called once per frame
	void Update () {
		varAngle = Mathf.Clamp (varAngle, 0, 90);
		transform.rotation = Quaternion.Euler(-(varAngle), 90, 0);
		
		varAngle = int.Parse (var2);
		varVelocity = int.Parse (var);

		if (Input.GetKeyDown(KeyCode.Return)) {
			//attempts--;
			StartCoroutine(TimerStart ());
		}
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			cam.enabled = !cam.enabled;
			cam2.enabled = !cam2.enabled;
		}
		
		if (Input.GetKeyDown (KeyCode.Escape)){
			exitScreen = !exitScreen;
		}

		if (target.activeSelf == false) {
			ellapsedTime = Time.time - startTime;
			winScreen = true;
			GameObject Fire = Instantiate (fire) as GameObject;
			Fire.transform.position = target.transform.position;
		}
	}
	
	IEnumerator TimerStart(){
		//varTime = float.Parse (var3);
		GameObject Projectile = Instantiate (prefab) as GameObject;
		Projectile.transform.position = transform.position;
		Rigidbody rb = Projectile.GetComponent<Rigidbody> ();
		rb.AddForce(transform.forward* varVelocity);
		yield return new WaitForSeconds (varTime);
		distanceTraveled = Mathf.Abs(transform.position.x - rb.transform.position.x);
		distanceTraveled = (distanceTraveled * 50);
	}
	



}