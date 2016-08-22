using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	float lifespan = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0) {
			Destroy(this.gameObject);
		}
	}

	// Called on collision with another rigidbody
	void OnCollisionEnter (Collision collision) {
		if (collision.gameObject.tag == "ArenaSurface") {
			Destroy(this.gameObject);
		}
	}
}
