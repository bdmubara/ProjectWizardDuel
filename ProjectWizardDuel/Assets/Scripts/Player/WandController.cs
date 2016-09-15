using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class WandController : NetworkBehaviour {

	public Wand wandPrefab;
	public Spell spellPrefab;
	public float wandDistanceFromPlayer = 0.8f;
	public float wandRightOffset = 0.5f;
	public float wandDownOffset = 0.3f;


	Wand wandInstance;
	GameObject playerCamera;

	// Use this for initialization
	void Start () {
		playerCamera = this.transform.Find("Camera").gameObject;

		wandInstance = Instantiate(wandPrefab) as Wand;
		wandInstance.transform.parent = transform;
		UpdateWandPosition();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateWandPosition();
		if (Input.GetButtonDown("Fire1") && isLocalPlayer) {
			wandInstance.FireSpell(spellPrefab);
		}
	}

	void UpdateWandPosition () {
		wandInstance.transform.position = playerCamera.transform.position + (playerCamera.transform.forward * wandDistanceFromPlayer) + (playerCamera.transform.right * wandRightOffset) + (playerCamera.transform.up * -wandDownOffset);
		wandInstance.transform.localRotation = playerCamera.transform.localRotation;
	}
}
