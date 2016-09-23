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
			//Debug.Log("testing");
			string tempr = br.ReadString();
			string temps = br.ReadString();
			bool tempb = br.ReadBoolean();
			string tempsn = br.ReadString();
			double tempsmc = (float)br.ReadDouble();
			double tempsd = (float)br.ReadDouble();
			for(int i = 0; i < temps.Length - 1; i++){
				treeString.Append("\t");
			}
			if(tempb)
				treeString.Append(tempr + "," + temps + "," + "true," + Convert.ToString(tempsn) + "," + Convert.ToString(tempsmc) + "," + Convert.ToString(tempsd) + "\n");
			else
				treeString.Append(tempr + "," + temps + "," + "false,");

		}
		var spellBook = TreeNode.BuildTree(treeString.ToString());
		br.Close();
		fs.Close();
		return spellBook;	
	}
	public static void FillSpellbookFile(){
		FileStream fs = new FileStream("spellBook.bin", FileMode.Create);
		BinaryWriter bw = new BinaryWriter(fs);
		string[] runes = new string[] {"x","c","v"};
		string[] spells1 = new string[] {"x","xx","xv","xc"};
		string[] spells2 = new string[] {"c","cx","cc","cv"};
		string[] spells3 = new string[] {"v","vx","vc","vv"};
		string[] spellNames1 = new string[] {"test11","test12","test13","test14"};
		string[] spellNames2 = new string[] {"test21","test22","test23","test24"};
		string[] spellNames3 = new string[] {"test31","test32","test33","test34"};
		int i = 0;
		double temp1 = (double)5.0f;
		double temp2 = (double)20.0f;

		foreach(string spell in spells1){
			if(spell[spell.Length - 1] == 'c')
				bw.Write(runes[1]);
			else if (spell[spell.Length - 1] == 'v')
				bw.Write(runes[2]);
			else
				bw.Write(runes[0]);
			bw.Write(spell);
			bw.Write(true);
			bw.Write(spellNames1[i]);
			bw.Write(temp1);
			bw.Write(temp2);
			i++;
		}
		foreach(string spell in spells2){	
			i = 0;		
			if(spell[spell.Length - 1] == 'x')
				bw.Write(runes[0]);
			else if (spell[spell.Length - 1] == 'v')
				bw.Write(runes[2]);
			else
				bw.Write(runes[1]);
			bw.Write(spell);
			bw.Write(true);
			bw.Write(spellNames2[i]);
			bw.Write(temp1);
			bw.Write(temp2);
			i++;
		}
		foreach(string spell in spells3){
			i = 0;
			if(spell[spell.Length - 1]== 'x')
				bw.Write(runes[0]);
			else if (spell[spell.Length - 1] == 'c')
				bw.Write(runes[1]);
			else
				bw.Write(runes[2]);
			bw.Write(spell);
			bw.Write(true);
			bw.Write(spellNames2[i]);
			bw.Write(temp1);
			bw.Write(temp2);
			i++;
		}
		bw.Close();
		fs.Close();
	}
}
