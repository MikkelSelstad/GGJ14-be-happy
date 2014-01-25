using UnityEngine;
using System.Collections;

public class DepressionSwitcher : MonoBehaviour {

    public int LevelActive = 50;

    void OnEnable()
    {
        DepressionManager.OnDepressionChange += OnDepressionChange;
    }

    void OnDisable()
    {
        DepressionManager.OnDepressionChange -= OnDepressionChange;
    }

    void HideObject()
    {
        this.collider.enabled = false;
        this.renderer.enabled = false;
    }

    void ShowObject()
    {
        this.collider.enabled = true;
        this.renderer.enabled = true;
    }

    void OnDepressionChange(int happyLevel)
    {
        if (happyLevel < LevelActive)
        {
            HideObject();
        }

        else if (happyLevel > LevelActive)
        {
            ShowObject();
        }
    }
}
