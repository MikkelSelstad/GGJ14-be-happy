using UnityEngine;
using System.Collections;

public class Happiness : MonoBehaviour {


	public	Happyning happyning;

	public static int maxhappy = 300; 
	public static int minhappy = 0; 
	public int happylvl = 100;
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

        happylvl = Mathf.Clamp(happylvl, minhappy, maxhappy);

	}

    

}