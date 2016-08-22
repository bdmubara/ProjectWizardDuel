using UnityEngine;
using System.Collections;

public class PlayerSpellcasting : MonoBehaviour {

	public Spell spellPrefab;
	public float spellSpeed = 20.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Camera playerCamera = Camera.main;
			Spell spellInstance = Instantiate(spellPrefab, playerCamera.transform.position , playerCamera.transform.rotation) as Spell;
			spellInstance.GetComponent<Rigidbody>().AddForce( playerCamera.transform.forward * spellSpeed, ForceMode.Impulse);
		}
	}
}
