using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System;

public class SpellObject {
	public string Name;
	public float ManaCost;
	public float Damage;
	//Spell Type
	//TODO: Spell Type class inherit from this class
	//ie. AoE, Direct Damage, Buff/DeBuff, DoT etc.

	public SpellObject(){}
	public SpellObject(string name, float mana, float damage){
		this.Name = name;
		this.ManaCost = mana;
		this.Damage = damage;
	}
}