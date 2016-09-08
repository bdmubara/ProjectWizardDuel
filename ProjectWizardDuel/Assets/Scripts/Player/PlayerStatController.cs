using UnityEngine;
using System.Collections;

// IMPORTANT NOTE: Temporary class until functionality can be distributed amongst proper scripts
public class PlayerStatController : MonoBehaviour {

	[SerializeField]
	private PlayerStat shortMana;
	[SerializeField]
	private PlayerStat longMana;
	[SerializeField]
	private PlayerStat health;

	private bool shortTermRecharge = false;

	private void Awake () {
		shortMana.Initialize();
		longMana.Initialize();
		health.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			shortTermRecharge = false;
			StopCoroutine("Delay");
			shortMana.CurVal -= 10;
			StartCoroutine("Delay");
		}

		// Start recharging short mana bar from long mana
		if(shortTermRecharge) {
			shortMana.CurVal += 0.25f;
			longMana.CurVal -= 0.25f;

			// Stop charging if mana bar full or long term mana empty
			if(shortMana.CurVal == shortMana.MaxVal || longMana.CurVal == 0.0f) {
				shortTermRecharge = false;
			}
		}

		// Increase long term mana if it is below 100
		if(longMana.CurVal < 100) {
			longMana.CurVal += 0.05f;
		}
	}

	IEnumerator Delay() {
		yield return new WaitForSeconds(0.5f);
		shortTermRecharge = true;
	}
}
