using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System;

public class TreeNode : IEnumerable<TreeNode>{
    private readonly Dictionary<string, TreeNode> _children =
                                        new Dictionary<string, TreeNode>();

    public readonly string ID;
    public readonly string Name;
    public readonly bool Correct;
    //TODO: Spell Class that conatins information about spell
    public TreeNode Parent { get; private set; }

    public TreeNode(){}
    public TreeNode(string id, string name, bool correct){
        this.ID = id;
        this.Name = name;
        this.Correct = correct;
    }

    public TreeNode GetChild(string id){
        return this._children[id];
    }

    public bool isChild(string id){
    	return this._children.ContainsKey(id);
    }
    public void Add(TreeNode item){

        if (item.Parent != null){
            item.Parent._children.Remove(item.ID);
        }

        item.Parent = this;
        this._children.Add(item.ID, item);
    }

    public IEnumerator<TreeNode> GetEnumerator(){
        return this._children.Values.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator(){
        return this.GetEnumerator();
    }

    public int Count{
        get { return this._children.Count; }
    }
    public static TreeNode BuildTree(string tree)
    {
        var lines = tree.Split('\n');

        var result = new TreeNode("Root", "Book", false);
        var list = new List<TreeNode> { result };

        foreach (var line in lines)
        {
            var trimmedLine = line.Trim();
            var splitLine = trimmedLine.Split(',');

            var indent = line.Length - trimmedLine.Length;
            var child = new TreeNode();

            if(trimmedLine.Length <= 0)
                break;

            if(splitLine[2] == "true")
                child = new TreeNode(splitLine[0], splitLine[1], true);
            else
                child = new TreeNode(splitLine[0], splitLine[1], false);
            Debug.Log(trimmedLine);
            list[indent].Add(child);

            if (indent + 1 < list.Count)
            {
                list[indent + 1] = child;
            }
            else
            {
                list.Add(child);
            }
        }

        return result;
    }

    public static string BuildString(TreeNode tree)
    {
        var sb = new StringBuilder();

        BuildString(sb, tree, 0);

        return sb.ToString();
    }
    private static void BuildString(StringBuilder sb, TreeNode node, int depth)
    {
        sb.AppendLine(node.ID.PadLeft(node.ID.Length + depth));

        foreach (var child in node)
        {
            BuildString(sb, child, depth + 1);
        }
    }
}

