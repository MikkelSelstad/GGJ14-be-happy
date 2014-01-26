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

    public float timeToLive = 20f;
	private Ray rayOne;
	private Ray rayTwo;
	private bool objectInTheWay = false;

    public bool happy = false;
    public bool neutral = false;
    public bool depressed = false;

    public GameObject thoughtBubble;
    public GameObject smileFace;
    public GameObject neutralFace;
    public GameObject sadFace;

    private int playerHappiness = 0;

    Animator animator;

    void Start()
    {
        thoughtBubble.SetActive(false);
        target = null;
        animator = GetComponent<Animator>();

        int state = Random.Range(0, 4);

        switch (state)
        {
            case 1: {
                happy = true;
                thoughtBubble.SetActive(true);
                smileFace.SetActive(true);
                neutralFace.SetActive(false);
                sadFace.SetActive(false);
                break;
               }

            case 2:
                {
                    neutral = true;
                    thoughtBubble.SetActive(true);
                    smileFace.SetActive(false);
                    neutralFace.SetActive(true);
                    sadFace.SetActive(false);
                    break;
                }

            case 3:
                {
                    depressed = true;
                    thoughtBubble.SetActive(true);
                    smileFace.SetActive(false);
                    neutralFace.SetActive(false);
                    sadFace.SetActive(true);
                    break;
                }

                

        }
    }

    void OnEnable()
    {
        DepressionManager.OnDepressionChange += GetDepression;
    }

    void OnDisable()
    {
        DepressionManager.OnDepressionChange -= GetDepression;
    }

    private void GetDepression(int happyLevel)
    {
        playerHappiness = happyLevel;
    }

    void FixedUpdate()
	{
		FindObjectInFront();

        if (this.transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }
	}

    void EvaluateChase()
    {
        if (depressed && playerHappiness < Happiness.maxhappy / 2)
                {
                    target = null;
                }

        else if (depressed && playerHappiness > Happiness.maxhappy / 2)
        {
            if (target == null)
            {
                target = GameObject.Find("Player").transform;
            }
        }

        if (happy && playerHappiness < Happiness.maxhappy / 2)
        {
            if (target == null)
            {
                target = GameObject.Find("Player").transform;
            }
        }

        else if (happy && playerHappiness > Happiness.maxhappy / 2)
        {
            target = null;
        }

        if (neutral)
        {
            target = null;
        }
    }

    void Update()
    {
        timeToLive -= Time.deltaTime;

        if (timeToLive <= 0f)
        {
            Destroy(this.gameObject);
        }

        if (rigidbody.velocity.magnitude > 0)
        {
            animator.SetFloat("Speed", rigidbody.velocity.magnitude);
        }

        EvaluateChase();
    }

	void FindObjectInFront()
	{
        if (target != null)
        {
		Vector3 rayOneOrigin = rayOneTarget.position;
		Vector3 rayTwoOrigin = rayTwoTarget.position;


		Vector3 rayDirection = transform.TransformDirection(Vector3.forward);

		rayOne = new Ray(rayOneOrigin, rayDirection);
		rayTwo = new Ray(rayTwoOrigin, rayDirection);

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

		if(Vector3.Distance(target.position, transform.position) <= detectDistance)
		{
            
                transform.LookAt(target);
                rigidbody.velocity = transform.forward * followSpeed;
            }
		}

		if(Vector3.Distance(target.position, transform.position) <= attackDistance)
		{
			rigidbody.velocity = transform.forward * 0;
		}
	}
}

