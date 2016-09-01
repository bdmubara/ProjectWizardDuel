using UnityEngine;
using System.Collections;

// IMPORTANT NOTE: Temporary class until functionality can be distributed amongst proper scripts
public class PlayerStatController : MonoBehaviour {

	[SerializeField]
	private Stat shortMana;
	[SerializeField]
	private Stat longMana;
	[SerializeField]
	private Stat health;

	private void Awake () {
		shortMana.Initialize();
		longMana.Initialize();
		health.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			shortMana.CurVal -= 10;
		}
	}
}
