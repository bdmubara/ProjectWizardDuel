using UnityEngine;
using System.Collections;
using System.Text;
using System;
using UnityEngine.EventSystems;

public class SpellController : MonoBehaviour {
	//string key = "";
	public float inputTimer = 10;

	StringBuilder spellRunes = new StringBuilder(10);
	bool fire = false;
	bool correctSpell = true;
	string rune;
	float timer;


	TreeNode spellBook = new TreeNode("Root", "Book", false){
		new TreeNode("x", "x", true){
			new TreeNode("x", "xx", true){
				new TreeNode("x", "xxx", true),
				new TreeNode("c", "xxc", true),
				new TreeNode("v", "xxv", true),
			},		
			new TreeNode("c", "xc", true){
				new TreeNode("x", "xcx", true),
				new TreeNode("c", "xcc", true),
				new TreeNode("v", "xcv", true),
			},
			new TreeNode("v", "xv", true){
				new TreeNode("x", "xvx", true),
				new TreeNode("c", "xvc", true),
				new TreeNode("v", "xvv", true),
			}
		},
		new TreeNode("c", "c", true){
			new TreeNode("x", "cx", true){
				new TreeNode("x", "cxx", true),
				new TreeNode("c", "cxc", true),
				new TreeNode("v", "cxv", true),
			},		
			new TreeNode("c", "cc", true){
				new TreeNode("x", "ccx", true),
				new TreeNode("c", "ccc", true),
				new TreeNode("v", "ccv", true),
			},
			new TreeNode("v", "cv", true){
				new TreeNode("x", "cvx", true),
				new TreeNode("c", "cvc", true),
				new TreeNode("v", "cvv", true),
			}
		}
	};

	TreeNode currentRune = new TreeNode();
	//currentRune = SpellBook.GetChild("x").Parent;
	// Use this for initialization
	void Start () {
		timer = -1;
		Debug.Log(currentRune.Name);
	}
	void FixedUpdate(){
		timer -= Time.deltaTime;
		//Debug.Log(timer);
		if(timer <= 0 && timer > -1){
			stopTimer();
		}
	}
	// Update is called once per frame
	void Update () {
		//Spell Creation

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
				//Debug.Log(currentRune.Correct);
			}
			else{
				correctSpell = false;
			}
			
		}	

			
		if(Input.GetButtonDown("Fire1")){
			fire  = true;
			if(currentRune.Name == "Book"){
				Debug.Log("No Spell Selected");
			}
			if(correctSpell){
				Debug.Log("Firing Spell " + currentRune.Name);
				currentRune = spellBook;
			}
			else{
				Debug.Log("Incorrect Spell");
				currentRune = spellBook;
			}
			stopTimer();
		}
	}
	void stopTimer(){
		timer = -1;
		currentRune = spellBook;
		correctSpell = false;
		Debug.Log("Reseting Timer");
	}

}
