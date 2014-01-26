using UnityEngine;
using System.Collections;

public class Happiness : MonoBehaviour {


	public	Happyning happyning;

	public static int maxhappy = 100; 
	public static int minhappy = 0; 
	public int happylvl = 10;
	float tick = 1;

	

	void Update () 
	{
		tick -= Time.deltaTime;
		if(tick <= 0)
		{
			tick = 1;
            if (happylvl > minhappy)
            {
                happylvl--;
                DepressionManager.Depress(happylvl);
            }
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

    /*

	void OnTriggerEnter(Collider other)
	{
		if(happyning)
		{
			happyning = other.GetComponent<Happyning>();


            if (other.GetComponent<happyning.randomhappy> == true) 
			{


				if (happyning.randval > 5) 
				{
					happylvl = other.GetComponent<Happyning.happyval> - happylvl;
			
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
     */

}