using UnityEngine;
using System.Collections;

public class WandController : MonoBehaviour {

	public Wand wandPrefab;
	public Spell spellPrefab;
	public float wandDistanceFromPlayer = 0.8f;
	public float wandRightOffset = 0.5f;
	public float wandDownOffset = 0.3f;


	Wand wandInstance;

	// Use this for initialization
	void Start () {
		wandInstance = Instantiate(wandPrefab) as Wand;
		wandInstance.transform.parent = transform;
		UpdateWandPosition();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWandPosition();
		if (Input.GetButtonDown("Fire1")) {
			wandInstance.FireSpell(spellPrefab);
		}
	}

	void UpdateWandPosition () {
		wandInstance.transform.position = Camera.main.transform.position + (Camera.main.transform.forward * wandDistanceFromPlayer) + (Camera.main.transform.right * wandRightOffset) + (Camera.main.transform.up * -wandDownOffset);
		wandInstance.transform.localRotation = Camera.main.transform.localRotation;
	}
}
