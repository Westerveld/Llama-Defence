using UnityEngine;
using System.Collections;

public class buttonScript : MonoBehaviour {


	void OnGUI(){
		if (GUI.Button (new Rect(Screen.width / 5*2, Screen.height / 3, Screen.width / 4, Screen.height / 4), "Play Game")) {
			Application.LoadLevel ("Main");
		}
		if (GUI.Button (new Rect (Screen.width / 5*2, Screen.height / 3*2, Screen.width / 4, Screen.height / 4), "Exit")) {
			Application.Quit ();
		}
	}
}
