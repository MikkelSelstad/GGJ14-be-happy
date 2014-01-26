using UnityEngine;
using System.Collections;

public class ColorTuner : MonoBehaviour {
    ColorCorrectionCurves ccurve;

	// Use this for initialization
	void Start () {
        ccurve = GetComponent<ColorCorrectionCurves>();
	}

    void OnEnable()
    {
        DepressionManager.OnDepressionChange += TuneColor;
    }

    void OnDisable()
    {
        DepressionManager.OnDepressionChange -= TuneColor;

    }

    private void TuneColor(int happyLevel)
    {
        ccurve.saturation -= 0.01f;
        //ccurve.saturation = Mathf.Clamp(ccurve.saturation, 0f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
