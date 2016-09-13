using UnityEngine;
using System.Collections;
using System.IO;
using System.Text;
using System;


public class SpellBook{
	public static TreeNode GenerateSpellbook(){
		FileStream fs = new FileStream("spellBook.bin", FileMode.Open);
		BinaryReader  br = new BinaryReader(fs);

		string[] runes = new string[] {"x","c","v"};
		//TreeNode spellBook = new TreeNode("Root", "Book", false);
		
		StringBuilder treeString = new StringBuilder();

		while (br.BaseStream.Position != br.BaseStream.Length){
			string tempr = br.ReadString();
			string temps = br.ReadString();
			bool tempb = br.ReadBoolean();
			for(int i = 0; i < temps.Length - 1; i++){
				treeString.Append("\t");
			}
			if(tempb)
				treeString.Append(tempr + "," + temps + "," + "true\n");
			else
				treeString.Append(tempr + "," + temps + "," + "false\n");

		}
		var spellBook = TreeNode.BuildTree(treeString.ToString());
		return spellBook;	
	}
	public static void FillSpellbookFile(){
		FileStream fs = new FileStream("spellBook.bin", FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fs);
		string[] runes = new string[] {"x","c","v"};
		string[] spells1 = new string[] {"x","xx","xxx","xxc","xxv","xc","xcx","xcc","xcv","xv","xvx","xvc","xvv"};
		string[] spells2 = new string[] {"c","cx","cxx","cxc","cxv","cc","ccx","ccc","ccv","cv","cvx","cvc","cvv"};
		string[] spells3 = new string[] {"v","vx","vxx","vxc","vxv","vc","vcx","vcc","vcv","vv","vvx","vvc","vvv"};
		foreach(string spell in spells1){
			bw.Write(runes[0]);
			bw.Write(spell);
			bw.Write(true);
		}
		foreach(string spell in spells2){
			bw.Write(runes[1]);
			bw.Write(spell);
			bw.Write(true);
		}
		foreach(string spell in spells3){
			bw.Write(runes[2]);
			bw.Write(spell);
			bw.Write(true);
		}
		//bw.Close();
		//bw.Dispose();
	}
}
