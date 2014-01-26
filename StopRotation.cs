using UnityEngine;
using System.Collections;

public class StopRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.transform.rotation = Quaternion.identity;
	}
}
