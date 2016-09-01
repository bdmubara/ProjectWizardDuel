using UnityEngine;
using System.Collections;

public class Spell : MonoBehaviour {

	public SpellCollisionExplosion collisionExplosionPrefab;
	public float spellSpeed = 20.0f;

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
		if (collision.gameObject.tag == "Opponent") {
			// TODO: opponent should be affected by spell
			DestroyWithExplosion();
		}
		else if (collision.gameObject.tag == "ArenaSurface") {
			DestroyWithExplosion();
		}
	}

	void DestroyWithExplosion () {
		// Create spell explosion before destroying spell
		SpellCollisionExplosion explosion = Instantiate(collisionExplosionPrefab) as SpellCollisionExplosion;
		explosion.transform.position = transform.position;

		Destroy(this.gameObject);
	}
}
