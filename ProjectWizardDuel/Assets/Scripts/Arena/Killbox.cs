using UnityEngine;
using System.Collections;

public class Killbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Destroy anything that collides with the killbox
	void OnTriggerExit (Collider collider) {
		switch (collider.gameObject.tag) {
			case "Player":
				// TODO: player must lose game if collided with killbox
				break;
			default:
				Destroy (collider.gameObject);
				break;
		}
	}
}
