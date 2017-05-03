using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject bullet;
	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {

		transform.position = bullet.transform.position + offset;
	}
//	public Transform target;
//	public float smooth=5.0f;
//	void Update(){
//		transform.position = Vector3.Lerp (transform.position, target.position, Time.deltaTime * smooth);
//	}
}
