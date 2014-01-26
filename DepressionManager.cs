using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DepressionManager : MonoBehaviour {
    
    public delegate void DepressionChange(int happyLevel);
    public static event DepressionChange OnDepressionChange;

    public delegate void GetNewsPaper(bool get);
    public static event GetNewsPaper OnNewsPaperGet;

    public static void Depress(int happyLevel)
    {
        if(OnDepressionChange != null)
        OnDepressionChange(happyLevel);

    }



    public static void GetPaper(bool get)
    {
        if (OnNewsPaperGet != null)
        {

        }
    }

    void OnEnable()
    {
        
    }

    void OnDisable()
    {

    }
}
