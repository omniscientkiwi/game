using UnityEngine;
using System.Collections;

public class UI_Manager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void StartGame() {

		Application.LoadLevel("story_start");
	}

	public void TeamScene() {

		Application.LoadLevel ("teams");
	}

	public void LevelOne() {

		Application.LoadLevel ("level");
	}

	public void CloseGame() {
	
		Application.Quit ();
	}

	public void QuitToMenu() {

		Application.LoadLevel ("menu");

	}


}
