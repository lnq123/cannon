using UnityEngine;
using System.Collections;

public class SceneChanger : MonoBehaviour {

	public void ChangeScene(string sceneToChangeTo){
		Application.LoadLevel (sceneToChangeTo);
	}

	public void QuitGame(){
		Application.Quit ();
	}
}
