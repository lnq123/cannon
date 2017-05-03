using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public int varVelocity = 1;
	
	void Start () {
		
	}
	


	void FixedUpdate () {
		if (Input.GetButton ("Up")) {
			varVelocity++;
		}
		if (Input.GetButton ("Down")) {
			varVelocity--;
		}
	}

	void Update(){
		PlayerPrefs.SetInt ("varVelocity", varVelocity);
	}
}
