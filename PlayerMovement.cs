using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float speed = 10.0f;
	public float xSpeed = 5.0f;

	float rotateSpeed = 3.0f;
	
	// Update is called once per frame
	void Update () {
		//if(Input.GetKey(KeyCode.D))
		//	transform.Translate(Vector3.right * speed * Time.deltaTime);

		//if(Input.GetKey(KeyCode.A))
		//	transform.Translate(Vector3.left * speed * Time.deltaTime);

		transform.Rotate(0, Input.GetAxis ("Horizontal") * rotateSpeed, 0);

		if(Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.forward * xSpeed * Time.deltaTime);

		if(Input.GetKey(KeyCode.S))
			transform.Translate(Vector3.back * xSpeed * Time.deltaTime);
	}
}
