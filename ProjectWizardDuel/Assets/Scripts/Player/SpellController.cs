using UnityEngine;
using System.Collections;
using System.Text;
using System;
using UnityEngine.Networking;

public class SpellController : NetworkBehaviour {
	//string key = "";
	public float inputTimer = 2f;
	public SpellObject currentSpell = new SpellObject();

	bool fire = false;
	bool correctSpell = true;
	string rune;
	float timer;


	TreeNode spellBook = new TreeNode();
	TreeNode currentRune = new TreeNode();

	
	//currentRune = SpellBook.GetChild("x").Parent;
	// Use this for initialization
	void Start () {
		timer = -1;
		// SpellBook.FillSpellbookFile();
		spellBook = SpellBook.GenerateSpellbook();
		// Debug.Log(spellBook.ToString());
		//currentRune = spellBook;
	}
	void FixedUpdate(){
		if(!isLocalPlayer){return;}
		timer -= Time.deltaTime;
		//Debug.Log(timer);
		if(timer <= 0 && timer > -1){
			stopTimer();
		}
	}
	// Update is called once per frame
	void Update () {
		//Spell Creation
		if (!isLocalPlayer) { return; }
		
		if(currentRune.Name == "Book"){
			correctSpell = false;
		}
		if(Input.GetKeyDown("q")){
			stopTimer();
		}
	 	if(currentRune.Name == null && fire == false){
			stopTimer();
			fire = false;
	 	}
		if(Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c")
		 || Input.GetKeyDown("v") || Input.GetKeyDown("b")){
			//Debug.Log(timer);
			timer = inputTimer;
			if(currentRune.isChild(Input.inputString)){
				currentRune = currentRune.GetChild(Input.inputString);
				correctSpell = currentRune.Correct;
				// Debug.Log(currentRune.Name);
			}
			else{
				correctSpell = false;
			}
			if(correctSpell)
				currentSpell = currentRune.Spell;
			
		}	

			
		if(Input.GetButtonDown("Fire1")){
			fire  = true;
			if(currentRune.Name == "Book"){
				//Debug.Log("No Spell Selected");
			}
			if(correctSpell){
				Debug.Log("Firing Spell " + currentRune.Name);
				currentRune = spellBook;
			}
			else{
				//Debug.Log("Incorrect Spell");
				currentRune = spellBook;
			}
			stopTimer();
		}
	}
	// static SpellObject castSpell(){
	// 	return currentRune.Spell;
	// }
	void stopTimer(){
		timer = -1;
		currentRune = spellBook;
		correctSpell = false;
		Debug.Log("Timer Finished");
	}


}
