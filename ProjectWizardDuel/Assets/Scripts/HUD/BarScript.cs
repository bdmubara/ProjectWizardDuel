using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarScript : MonoBehaviour {

	private float fillAmount;

	[SerializeField]
	private Image content;

	[SerializeField]
	private int lerpSpeed;

	public float MaxValue {
		get;
		set;
	}

	public float Value {
		set {
			fillAmount = Map(value, 0, MaxValue, 0, 1);
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		HandleBar();
	}

	private void HandleBar() {
		if(content.fillAmount != fillAmount){
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
		return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
	}
}
