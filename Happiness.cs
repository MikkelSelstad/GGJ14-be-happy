using UnityEngine;
using System.Collections;

public class Happiness : MonoBehaviour {

	public int maxhappy = 100; 
	public int minhappy = 0; 
	public float happylvl = 10;
	float tick = 10;

	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () {

		print (tick);

		tick -= Time.deltaTime;
		if(tick <= 0)
		{
			tick = 10;
			if(happylvl > minhappy)
				happylvl --;
		}	


		if (Input.GetKey (KeyCode.Space))
			happylvl =+ 20;

	}

}