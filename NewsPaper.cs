using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewsPaper : MonoBehaviour {

    public TextAsset TxtTitles;
    public TextAsset TxtBadObjects;
    public TextAsset TxtGoodObjects;
    public TextAsset TxtPeople;
    public TextAsset TxtIngress;
    public TextAsset TxtAnimals;
    

    public List<string> Titles = new List<string>();
    public List<string> BadObjects = new List<string>();
    public List<string> GoodObjects = new List<string>();
    public List<string> People = new List<string>();
    public List<string> Ingress = new List<string>();
    public List<string> Animals = new List<string>();


    void ParseText(TextAsset text, List<string> list)
    {
        string t = text.text;
        string[] lines = t.Split('\n');

        foreach (string line in lines)
        {
            line.Trim();
            list.Add(line);
        }

        Debug.Log(lines.Length);
    }

    void GenerateTitle()
    {

    }

    void GenerateIngress()
    {

    }

    void GenerateStory()
    {

    }

	// Use this for initialization
	void Start () 
    {
        ParseText(TxtAnimals, Animals);
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
