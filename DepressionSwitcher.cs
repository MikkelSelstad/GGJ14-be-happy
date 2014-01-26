using UnityEngine;
using System.Collections;

public class DepressionSwitcher : MonoBehaviour {

    public int LevelActive = 50;
    public bool happy = false;

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
        if(collider != null)
        this.collider.enabled = false;

        if(renderer != null)
         this.renderer.enabled = false;
    }

    void ShowObject()
    {
        if(collider != null)
        this.collider.enabled = true;

        if(renderer != null)
        this.renderer.enabled = true;
    }

    void OnDepressionChange(int happyLevel)
    {
        if (happyLevel < LevelActive)
        {
            if (happy)
            {
                HideObject();
            }

            if (!happy)
            {
                ShowObject();
            }
        }

        else if (happyLevel > LevelActive)
        {
            if (happy)
            {
                ShowObject();
            }

            if (!happy)
            {
                HideObject();
            }
        }
    }
}
