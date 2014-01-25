using UnityEngine;
using System.Collections;

public class Happiness : MonoBehaviour {

	public int maxhappy = 100; 
	public int minhappy = 0; 
	public int happylvl = 10;
	float tick = 1;
//	int i = 4;

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
			tick = 1;
			if(happylvl > minhappy)
				happylvl --;
		}	


		if (happylvl == minhappy) 
		{
			Time.timeScale = 0.2f;
			print("time slow");
		}

		if (happylvl >= maxhappy)
		{
			happylvl = 100;
		}

		if (happylvl < minhappy) 
		{
			happylvl = 0;
		}

		if (Input.GetKeyDown (KeyCode.Space))
		{
			if (happylvl <= maxhappy--)
			{
				happylvl = happylvl +20;			
			}
		}



	}
	
}