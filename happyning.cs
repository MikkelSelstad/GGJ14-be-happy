using UnityEngine;
using System.Collections;


public class Happyning : MonoBehaviour 
{

	// Use this for initialization
	public bool randomhappy = false;
	public int happyval = 1;
	public int randval = 2;
	
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.R))
		{
			randval = randval +Random.Range(0, 10);
			print(randval);
		}
	}

}