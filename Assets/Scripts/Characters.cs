using UnityEngine;
using System.Collections;

public class Characters : MonoBehaviour {

	public GameObject character;
	public Vector3 launchPos;
	public bool aimingMode;
	public GameObject launchPoint;
	public float velocityMult = 6f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// If the character is not in aiming mode, don't run this script
		if (!aimingMode)
			return;
		// Get the current mouse position in 2D screen coordinates
		Vector3 mousePos2D = Input.mousePosition;
		// Convert the mouse position to 3D world coordinates
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		// Find the delta from the launchPos to the mousePos3D
		Vector3 mouseDelta = mousePos3D - launchPos;
		// Limit mouseDelta to the radius of the character SphereCollider
		float maxMagnitude = this.GetComponent<CircleCollider2D> ().radius;
		if (mouseDelta.magnitude > maxMagnitude) {
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}
		// Move the character to this new position
		Vector3 projPos = launchPos + mouseDelta;
		character.transform.position = projPos;
		if (Input.GetMouseButtonUp(0))
		{
			// The mouse has been released
			aimingMode = false;
			character.GetComponent<Rigidbody2D>().isKinematic = false;
			character.GetComponent<Rigidbody2D>().velocity =
				-mouseDelta * velocityMult;
			character = null;
		}
	}

	void Awake() {
		Transform launchPointTrans =
			transform.Find ("launchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPos = launchPointTrans.position;
	}

	void OnMouseDown()
	{
		// The player has pressed the mouse utton while over character
		aimingMode = true;
		// Start it at the launch point
		character.transform.position = launchPos;
		// Set it to isKinematic for now
		character.GetComponent<Rigidbody2D>().isKinematic = true;
	}
}


