using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewsPaper : MonoBehaviour {

    public int badStoriesToGenerate = 8;
    public int goodStoriesToGenerate = 8;

    public UILabel mainHeadline;
    public UILabel mainStory;

    public UILabel subHeadline01;
    public UILabel subStory01;

    public UILabel subHeadline02;
    public UILabel subStory02;

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

    public List<string> goodStories = new List<string>();
    public List<string> badStories = new List<string>();


    void ParseTextSimple(TextAsset text, List<string> list)
    {
        string t = text.text;
        string[] lines = t.Split('\n');

        foreach (string line in lines)
        {
            line.Trim();
            list.Add(line);
        }
    }

    void GenerateStory(bool bad)
    {
            List<string> tempTitles = new List<string>();

            foreach (string title in Titles)
            {
                tempTitles.Add(title);
            }
            
            string story = "";
            string individualOne = "";
            string individualTwo = "";
            string obj1 = "";
            string obj2 = "";

            for (int y = 0; y < tempTitles.Count; y++)
                {
                    if (tempTitles[y].Contains("%"))
                    {
                        if (individualOne == "")
                        {
                            int r = Random.Range(0, 2);

                            if (r == 0)
                            {
                                individualOne = GrabAnimal();
                            }

                            else if (r == 1)
                            {
                                individualOne = GrabPerson();
                            }
                        }

                        tempTitles[y] = tempTitles[y].Replace("%", individualOne);

                    }

                    if (tempTitles[y].Contains("_"))
                    {
                        if (individualTwo == "")
                        {
                            int r = Random.Range(0, 2);

                            if (r == 0)
                            {
                                individualTwo = GrabAnimal();
                            }

                            else if (r == 1)
                            {
                                individualTwo = GrabPerson();
                            }
                        }

                        tempTitles[y] = tempTitles[y].Replace("_", individualTwo);

                    }

                    if (tempTitles[y].Contains("~"))
                    {
                        if (obj1 == "")
                        {
                            obj1 = GrabObject(bad);
                        }

                        tempTitles[y] = tempTitles[y].Replace("~", obj1);

                    }

                    if (tempTitles[y].Contains("*"))
                    {
                        if (obj2 == "")
                        {
                            obj2 = GrabObject(bad);
                        }

                        tempTitles[y] = tempTitles[y].Replace("*", obj2);
                    }

                    story = tempTitles[y];

                    if (bad)
                    {
                        badStories.Add(story);
                    }

                    else if (!bad)
                    {
                        goodStories.Add(story);
                    }
                }

            }
     

    string GrabAnimal()
    {
        int r = Random.Range(0, Animals.Count);
        string animal = Animals[r];

        return animal;
    }

    string GrabPerson()
    {
        int r = Random.Range(0, People.Count);
        string person = People[r];

        return person;
    }

    string GrabObject(bool bad)
    {
        if(bad)
        {
            int r = Random.Range(0, BadObjects.Count);
            string badObject = BadObjects[r];

            return badObject;
        }

        else if (!bad)
        {
            int r = Random.Range(0, GoodObjects.Count);
            string goodObject = GoodObjects[r];

            return goodObject;
        }
        
        return null;
    }

    string GetHeadLine(string story)
    {
        string Story = story;
        string[] Splat = Story.Split('@');

        string headline = Splat[0];
        headline.TrimEnd();

        return headline;
    }

    string GetStoryBody(string story)
    {
        string Story = story;
        string[] Splat = Story.Split('@');

        string body = Splat[1];
        body.TrimEnd();

        return body;

    }


	// Use this for initialization
	void Start () 
    {
        ParseTextSimple(TxtAnimals, Animals);
        ParseTextSimple(TxtPeople, People);
        ParseTextSimple(TxtBadObjects, BadObjects);
        ParseTextSimple(TxtGoodObjects, GoodObjects);
        ParseTextSimple(TxtTitles, Titles);


        for (int i = 0; i < badStoriesToGenerate; i++)
        {
            GenerateStory(true);
            GenerateStory(false);
        }

        GetStoryForUI(mainHeadline, mainStory, false);
        GetStoryForUI(subHeadline01, subStory01, true);
        GetStoryForUI(subHeadline02, subStory02, false);

	}

    private void GetStoryForUI(UILabel Head, UILabel Body, bool bad)
    {
        

        if (bad)
        {
            int ra = Random.Range(0, badStories.Count);

            string ha = GetHeadLine(badStories[ra]).ToUpper();
            string bo = GetStoryBody(badStories[ra]);
            Head.text = ha;
            Body.text = bo;
        }

        else if (!bad)
        {
            int ra = Random.Range(0, goodStories.Count);

            string ha = GetHeadLine(goodStories[ra]).ToUpper();
            string bo = GetStoryBody(goodStories[ra]);
            Head.text = ha;
            Body.text = bo;
        }

        
    }

    // Update is called once per frame
    void Update() 
    {
	    
	}
}
