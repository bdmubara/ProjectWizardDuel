using UnityEngine;
using System.Collections;

public class SpellCollisionExplosion : MonoBehaviour {

	float lifespan;

	// Use this for initialization
	void Start () {
		lifespan = this.gameObject.transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().startLifetime + 0.05f; // Add time buffer to allow particle effect to complete
	}
	
	// Update is called once per frame
	void Update () {
		lifespan -= Time.deltaTime;
		if (lifespan <= 0) {
			Destroy(this.gameObject);
		}
	}
}
