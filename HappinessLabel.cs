using UnityEngine;
using System.Collections;

public class HappinessLabel : MonoBehaviour {

    UILabel label;

    void Awake()
    {
        label = GetComponent<UILabel>();
    }

    void OnEnable()
    {
        DepressionManager.OnDepressionChange += OnDepressionChange;
    }


    void OnDisable()
    {
        DepressionManager.OnDepressionChange -= OnDepressionChange;
    }

    private void OnDepressionChange(int happyLevel)
    {
        label.text = "Happiness: " + happyLevel;
    }

    

}
