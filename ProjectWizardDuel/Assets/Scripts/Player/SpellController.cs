using UnityEngine;
using System.Collections;
using System.Text;
using System;

public class SpellController : MonoBehaviour {
	//string key = "";
	public float inputTimer = 10f;

	StringBuilder spellRunes = new StringBuilder(10);
	bool fire = false;
	bool correctSpell = true;

	TreeNode spellBook = new TreeNode("Root", "Book"){
		new TreeNode("x", "x"){
			new TreeNode("x", "xx"){
				new TreeNode("x", "xxx"),
				new TreeNode("c", "xxc"),
				new TreeNode("v", "xxv"),
			},		
			new TreeNode("c", "xc"){
				new TreeNode("x", "xcx"),
				new TreeNode("c", "xcc"),
				new TreeNode("v", "xcv"),
			},
			new TreeNode("v", "xv"){
				new TreeNode("x", "xvx"),
				new TreeNode("c", "xvc"),
				new TreeNode("v", "xvv"),
			}
		},
		new TreeNode("c", "c"){
			new TreeNode("x", "cx"){
				new TreeNode("x", "cxx"),
				new TreeNode("c", "cxc"),
				new TreeNode("v", "cxv"),
			},		
			new TreeNode("c", "cc"){
				new TreeNode("x", "ccx"),
				new TreeNode("c", "ccc"),
				new TreeNode("v", "ccv"),
			},
			new TreeNode("v", "cv"){
				new TreeNode("x", "cvx"),
				new TreeNode("c", "cvc"),
				new TreeNode("v", "cvv"),
			}
		}
	};

	TreeNode currentRune = new TreeNode();
	//currentRune = SpellBook.GetChild("x").Parent;
	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate(){

	}
	// Update is called once per frame
	void Update () {
		//Spell Creation
		if(currentRune.Name == "Book"){
			correctSpell = false;
		}
		if(Input.GetKeyDown("q")){
			StopCoroutine("spellTimer");
			currentRune = spellBook;
			correctSpell = false;
		}
	 	if(currentRune.Count == 0 && fire == false){
			currentRune = spellBook;
			correctSpell = false;
			fire = false;
	 	}
		if(Input.GetKeyDown("z") || Input.GetKeyDown("x") || Input.GetKeyDown("c")
		 || Input.GetKeyDown("v") || Input.GetKeyDown("b")){
			if(currentRune.ID == "Root"){
				StartCoroutine("spellTimer");
			}
			if(Input.GetKeyDown("z")){
				if(currentRune.isChild("z")){
					currentRune = currentRune.GetChild("z");
					correctSpell = true;
				}
				else{
					correctSpell = false;
				}
			}
			else if(Input.GetKeyDown("x")){
				if(currentRune.isChild("x")){
					currentRune = currentRune.GetChild("x");
					correctSpell = true;
				}
				else{
					correctSpell = false;
				}
			}
			else if(Input.GetKeyDown("c")){
				if(currentRune.isChild("c")){
					currentRune = currentRune.GetChild("c");
					correctSpell = true;
				}
				else{
					correctSpell = false;
				}
			}			
			else if(Input.GetKeyDown("v")){
				if(currentRune.isChild("v")){
					currentRune = currentRune.GetChild("v");
					correctSpell = true;
				}
				else{
					correctSpell = false;
				}
			}			
			else{
				if(currentRune.isChild("b")){
					currentRune = currentRune.GetChild("b");
					correctSpell = true;
				}
				else{
					correctSpell = false;
				}
			}

			//Debug Stuff
			//Debug.Log(currentRune.Name);


			//player.spellString.push(key);
			//player.restartTimer(spellExhaustTimer);
		}

		if(Input.GetButtonDown("Fire1")){
			fire  = true;
			StopCoroutine("spellTimer");

			if(currentRune.Name == "Book"){
				//Debug.Log("No Spell Selected");
			}
			if(correctSpell){
				//Debug.Log("Firing Spell " + currentRune.Name);
				currentRune = spellBook;
			}
			else{
				//Debug.Log("Incorrect Spell");
				currentRune = spellBook;
			}
		}
	}

	IEnumerator spellTimer(){
		yield return new WaitForSeconds(inputTimer);
		//Debug.Log("Runes Reset");
		spellRunes.Length = 0;
	}
}
