using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text.RegularExpressions;

public class VelocityShoot : MonoBehaviour {

	GameObject prefab;
	public int varVelocity;
	private string var = "";
	private int lengthOfText = 4;
	//public Text VelocityText;

	// Use this for initialization
	void Start () {
		prefab = Resources.Load ("Projectile") as GameObject;
		varVelocity = 0;
		//SetVelocityText ();
	}
	void OnGUI(){
		//GUI.Label (new Rect (0, 10, 100, 100), "vara34ye5 rehtrfdhfdhdfhadefh45 heafhd g");
		var = GUI.TextField (new Rect (100, 50, 150, 35), var, lengthOfText);
		var = Regex.Replace (var, "[^0-9]", "");
		//GUI.Label (new Rect (500, 500, 500, 500), var);
	}
	// Update is called once per frame
	public void Fire() {
		//if (Input.GetKeyDown(KeyCode.Return)) {
			GameObject Projectile = Instantiate (prefab) as GameObject;
			Projectile.transform.position = transform.position;
			Rigidbody rb = Projectile.GetComponent<Rigidbody> ();
			rb.AddForce(transform.forward * varVelocity);
			//rb.velocity = transform.eulerAngles = new Vector3(varVelocity, 90, 0);
			//transform.TransformDirection(Vector3.forward) * varVelocity) + 
			
			Destroy (Projectile.gameObject, 3);
		}


	/*void SetVelocityText() {
		VelocityText.text = "Velocity: " + varVelocity.ToString ();
	}*/

}
