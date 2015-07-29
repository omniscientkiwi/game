using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		print ("triggerEnter");
		// Find out what hit the hole
		GameObject collidedWith = collider.gameObject;
		// if it's a character or an enemy destroy it
		if (collidedWith.CompareTag ("character")) {
			print("collided with character");
			Destroy(collidedWith);
		}
		if (collidedWith.CompareTag ("enemy")) {
			print("collided with enemy");
			Destroy(collidedWith);
	}
}
}
