using UnityEngine;
using System.Collections;

public class CollideVelocity : MonoBehaviour {
	
	private bool showPopUp = false;
	public Rect windowRect = new Rect(100, 100, 120, 50);
	//private Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		//rb = GetComponent<Rigidbody> ();
	}
	
	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Target")) {
			//Destroy(other.gameObject);
			other.gameObject.SetActive (false);
			showPopUp = true;
		}
	}
	
	void OnGUI(){
		if (showPopUp) {
			windowRect = GUI.Window (100, windowRect, DoMyWindow, "Do you want to go to the next phase?");
		}
	}
	
	
	void DoMyWindow(int windowID) {
		if (GUI.Button (new Rect (60, 20, 150, 20), "Next Phase (Angle)")) {
			Application.LoadLevel (1);
			showPopUp = false;
		}
		
		if (GUI.Button (new Rect (60, 50, 220, 20), "Remain in this Phase (Velocity)")) {
			Application.LoadLevel (0);
			showPopUp = false;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}


