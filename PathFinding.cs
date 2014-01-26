using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {
	
    public Transform target;
	public Transform rayOneTarget;
	public Transform rayTwoTarget;
	public int followSpeed = 4;
	public Vector3 avoidObjectSpeed = new Vector3(0, 0, 4);
	public int detectDistance = 10;
	public float attackDistance = 2.4f;
	public float colliderDetectDistance = 3.5f;
	private Ray rayOne;
	private Ray rayTwo;
	private bool objectInTheWay = false;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void FixedUpdate()
	{
		FindObjectInFront();
	}

	void FindObjectInFront()
	{
		Vector3 rayOneOrigin = rayOneTarget.position;
		Vector3 rayTwoOrigin = rayTwoTarget.position;


		Vector3 rayDirection = transform.TransformDirection(Vector3.forward);

		rayOne = new Ray(rayOneOrigin, rayDirection);
		rayTwo = new Ray(rayTwoOrigin, rayDirection);

		Debug.DrawRay(rayOneOrigin, rayDirection, Color.green);
		Debug.DrawRay(rayTwoOrigin, rayDirection, Color.green);

		if(Physics.Raycast(rayOne, colliderDetectDistance))
		{
			rigidbody.MovePosition(rigidbody.position + avoidObjectSpeed * Time.deltaTime);
		}

		if(Physics.Raycast(rayTwo, colliderDetectDistance))
		{
			objectInTheWay = true;
			rigidbody.MovePosition(rigidbody.position + avoidObjectSpeed * -Time.deltaTime);
		}

		if(Vector3.Distance(target.position, transform.position) > detectDistance)
		{
			rigidbody.velocity = transform.forward * 0;
		}

		Debug.Log(objectInTheWay + "2");
		if(Vector3.Distance(target.position, transform.position) <= detectDistance)
		{
			transform.LookAt(target);
			rigidbody.velocity = transform.forward * followSpeed;
		}

		if(Vector3.Distance(target.position, transform.position) <= attackDistance)
		{
			rigidbody.velocity = transform.forward * 0;
		}
	}
}
