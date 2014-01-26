using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 10f;
	public float jumpSpeed = 350f;
	float horizontal = 0f;
	float vertical = 0f;
	bool jumpButton = false;
	Animator animator;
	Vector3 currentDir = Vector3.zero;
	float magnitude;
	float tid = 0;

	
	void Start()
	{
		animator = GetComponent<Animator>();
	}
	
	void Update()
	{
		tid -= Time.deltaTime;
		if (magnitude < 0.1f) {
			transform.rotation =  Quaternion.Euler(currentDir);
				} else if (magnitude != 0.0f) {
						transform.forward = Vector3.Normalize (new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")));
				}
		Debug.Log(Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"))));
		
		vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
		jumpButton = Input.GetButtonDown("Jump");

		Vector3 movement = new Vector3(horizontal, 0f, vertical);
		
		magnitude = Vector3.Magnitude(movement);
		
		animator.SetFloat("Speed", Mathf.Abs(magnitude));

		if (jumpButton && tid <= 0)
		{
			rigidbody.AddForce(new Vector3(0f, jumpSpeed, 0f));
			tid = 1.2f;
		}
			currentDir = transform.rotation.eulerAngles;
	}
	
	void FixedUpdate()
	{
		
		rigidbody.velocity = new Vector3(horizontal * speed, rigidbody.velocity.y, vertical * speed);
		
	}
	
}
