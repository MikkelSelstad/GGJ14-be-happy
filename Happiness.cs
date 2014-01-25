using UnityEngine;
using System.Collections;

public class Happiness : MonoBehaviour {


	public	Happyning happyning;

	public static int maxhappy = 100; 
	public static int minhappy = 0; 
	public int happylvl = 10;
	float tick = 1;
	//int x;


	// Use this for initialization
	void Start () 
	{


	}
	
	// Update is called once per frame
	void Update () 
	{

	//	print (tick);

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
			if (happylvl <= maxhappy)
			{
				happylvl = happylvl +20;			
			}
		}


		
	}



	void OnTriggerEnter(Collider other)
	{
		if(Happyning)
		{
			happyning = other.GetComponent<Happyning>();


			if (other.GetComponent(Happyning.randomhappy) == true) 
			{


				if (Happyning.randval > 5) 
				{
					happylvl = other.GetComponent(Happyning.happyval) - happylvl;
			
				} 
				else  
				{
					happylvl = other.GetComponent(Happyning.happyval) + happylvl;
				}

			}
			else 
			{
				happylvl = other.GetComponent(Happyning.happyval) + happylvl;
			}

		}
		else
		{

		}
	}

}