using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public Arena arenaPrefab;

	Arena arenaInstance;


	// Use this for initialization
	void Start () {
		BeginGame();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void BeginGame () {
		arenaInstance = Instantiate(arenaPrefab) as Arena;
		arenaInstance.Generate();
	}
}
