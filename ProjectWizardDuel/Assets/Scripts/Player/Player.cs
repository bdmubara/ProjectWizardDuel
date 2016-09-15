using UnityEngine;
using UnityEngine.Networking;
using System.Collections;


public class Player : NetworkBehaviour {

	public Material [] playerMaterials;

	// Use this for initialization
	void Start () {
		if (isLocalPlayer) {
			this.transform.Find("Camera").gameObject.SetActive(true);
			this.GetComponent<CharacterController>().enabled = true;
			this.GetComponent<FirstPersonController>().enabled = true;
			this.GetComponent<PlayerStatController>().enabled = true;
			this.GetComponent<SpellController>().enabled = true;
		}

		if (playerMaterials != null && playerMaterials.Length > 0) {
			this.transform.Find("Player Model").Find("Capsule").GetComponent<MeshRenderer>().material = (isLocalPlayer) ? playerMaterials[0] : playerMaterials[1];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
