using System.Collections;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;


public class AngleShooter2 : MonoBehaviour {
	
	// Use this for initialization
	GameObject lost;
	GameObject fire;
	GameObject prefab;
	private int varAngle;
	private string var = "0";
	private int lengthOfText = 2;
	
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
	public Rect windowRect2 = new Rect(50, 50, 50, 50);
	
	public float startTime;
	public float ellapsedTime;
	
	public Camera cam;
	public Camera cam2;
	
	void Start () {
		prefab = Resources.Load ("rocket") as GameObject;
		varAngle = 0;
		attempts = 3;
		target = GameObject.Find ("Target");
		lost = GameObject.Find ("Lost");
		lost.SetActive (false);
		cam.enabled = true;
		cam2.enabled = false;
		fire = Resources.Load ("Fire") as GameObject;
		distance = Mathf.Abs(transform.position.x - target.transform.position.x);
		distance = distance * 48;
		varTime = 1.85f;
	}
	
	void OnGUI(){
		windowRect = GUI.Window (15, new Rect ((Screen.width - box_w)/16, (Screen.height - box_h) - 70 , box_w, box_h), DoMyWindow3, "Angle (Angle : Hard)");
		
		/*if (showTutorial) {
			windowRect2 = GUI.Window (7, new Rect ((Screen.width - box_w) / 2, (Screen.height - box_h) / 2, box_w, box_h), DoMyWindow4, "Angle Easy");
		}*/
		// Shows a window when player hits the target
		if (showPopUp) {
			windowRect = GUI.Window ( 11, new Rect((Screen.width - var_w)/2, (Screen.height - var_h)/2, var_w, var_h), DoMyWindow, 
			                         "You Got It! Next Challenge?");
		}
		if (showPopUp2) {
			windowRect = GUI.Window (13, new Rect ((Screen.width - var_w) / 2, (Screen.height - var_h) / 2, var_w, var_h), DoMyWindow2, "Egyptian Shooter");
		}
		if (showLose) {
			windowRect = GUI.Window (19, new Rect ((Screen.width - var_w) / 2, (Screen.height - var_h) / 2, var_w, var_h), DoMyWindow5, "You Lost");
		}
	}
	
	void DoMyWindow(int windowID) {
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
		GUI.Label (new Rect (70, 40, 300, 70), "Spectacular! You've completed your Angle training. Now we will combine the two variables for you to change. Are you ready " +
			"for the hardest challenges?", myStyle);
		
		if (GUI.Button (new Rect (45, 135, 150, 20), "Angle-Velocity Tutorial")) {
			Application.LoadLevel("AVTutorial");
		}
		if (GUI.Button (new Rect (235, 135, 150, 20), "Replay Hard")) {
			Application.LoadLevel ("AngleHard");
		}
	}
	
	void DoMyWindow2(int windowID) {
		if (GUI.Button (new Rect (150, 50, 150, 20), "Main Menu")) {
			Application.LoadLevel ("TitleScreen");
		}
		
		if (GUI.Button (new Rect (150, 90, 150, 20), "Restart Phase")) {
			Application.LoadLevel ("AngleHard");
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
		GUI.Label (new Rect (90, 45, 80, 35), "Angle (0 - 99): ", myStyle);
		var = GUI.TextField (new Rect (200, 40, 80, 30), var, lengthOfText);
		var = Regex.Replace (var, "[^0-9]", "");
		GUI.Label (new Rect (290, 45, 80, 35), "Degrees ", myStyle);
		
		GUI.Label (new Rect (110, 80, 130, 30), "Velocity: 850 Meters Per Second", myStyle);
		GUI.Label (new Rect (160, 110, 130, 30), "Time: " + varTime.ToString() + " seconds: ", myStyle);
		GUI.Label (new Rect (90, 140, 360, 30), "Approximate Distance Away: " + distance.ToString(), myStyle);
		GUI.Label (new Rect (40, 170, 360, 30), "Equation: Distance = Velocity(cos(Angle)) * Time", myStyle);
		GUI.Label (new Rect (70, 200, 360, 30), "Distance Traveled after " + varTime.ToString() +  " seconds: " + distanceTraveled.ToString(), myStyle);
		GUI.Label (new Rect (160, 230, 360, 30), "Attempts Left: " + attempts.ToString(), myStyle2);
	}
	
	/*void DoMyWindow4(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.white;
		int text_h = 80;
		int text_w = 50;
		GUI.Label (new Rect (70, 90, 300, 70), "You are now in a challenge! In an easy challenge you only have 8 attempts to hit the target. " +
		           "Hit the target and move on to harder challenges! ", myStyle);
		
		if (GUI.Button (new Rect (145, 200, 150, 20), "Got it!")) {
			showTutorial = false;
		}
	}*/
	
	void DoMyWindow5(int windowID) {
		GUIStyle myStyle = new GUIStyle ();
		myStyle.fontSize = 17;
		myStyle.wordWrap = true;
		myStyle.alignment = TextAnchor.MiddleCenter;
		myStyle.normal.textColor = Color.white;
		
		GUI.Label (new Rect (70, 40, 300, 70), "You failed to hit the target.", myStyle);
		
		if (GUI.Button (new Rect (45, 135, 150, 20), "Try Again")) {
			Application.LoadLevel("AngleHard");
		}
		if (GUI.Button (new Rect (235, 135, 150, 20), "Main Menu")) {
			Application.LoadLevel ("TitleScreen");
		}
	}
	
	// Update is called once per frame
	void Update () {
		varAngle = Mathf.Clamp (varAngle, 0, 90);
		transform.rotation = Quaternion.Euler(-(varAngle), 90, 0);
		
		varAngle = int.Parse (var);
		if (Input.GetKeyDown(KeyCode.Return)) {
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
		Rigidbody rb = Projectile.GetComponent<Rigidbody> ();
		rb.AddForce(transform.forward*850);
		yield return new WaitForSeconds (varTime);
		distanceTraveled = Mathf.Abs(transform.position.x - rb.transform.position.x);
		distanceTraveled = (distanceTraveled * 50);
	}
	
	IEnumerator TimerStart2(){
		yield return new WaitForSeconds (varTime + 1.0f);
		if (target.activeSelf == true) {
			lost.SetActive (true);
			showLose = true;
		}
	}
	
}