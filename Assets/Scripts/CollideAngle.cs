using UnityEngine;
using System.Collections;

public class CollideAngle : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Target")) {
			Destroy(gameObject);
			other.gameObject.SetActive (false);
			//showPopUp = true;
		} else {
			Destroy (gameObject);
		}
	}
	
	void Update () {
		
	}
}