using UnityEngine;
using System.Collections;

public class Wand : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void FireSpell (Spell spellPrefab) {
			Vector3 spellSpawnPos = gameObject.transform.position + gameObject.transform.forward * gameObject.transform.GetChild(0).transform.localScale.z;
			
			Spell spellInstance = Instantiate(spellPrefab, spellSpawnPos, gameObject.transform.rotation) as Spell;
			spellInstance.transform.parent = null;

			spellInstance.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * spellInstance.spellSpeed, ForceMode.Impulse);
	}
}
