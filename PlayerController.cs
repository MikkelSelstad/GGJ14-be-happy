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
	private float tid = 0;
    private float fullSpeed;
    public float tiden = 0f;

    public Level level;

    public GameObject newsBulletin;


	
	void Start()
	{
		animator = GetComponent<Animator>();
        fullSpeed = speed;
	}

    void OnEnable()
    {
        DepressionManager.OnDepressionChange += OnDepressionChange;
        DepressionManager.OnNewsPaperGet += OnNewsPaperGet;
    }

    void OnDisable()
    {
        DepressionManager.OnDepressionChange -= OnDepressionChange;
        DepressionManager.OnNewsPaperGet -= OnNewsPaperGet;
    }

    private void OnNewsPaperGet(bool get)
    {
        newsBulletin.SetActive(true);
    }

    private void OnDepressionChange(int happyLevel)
    {
        speed = fullSpeed * (happyLevel * 0.10f);
        speed = Mathf.Clamp(speed, 1, fullSpeed);
    }
	
	void Update()
	{
		tid -= Time.deltaTime;
		if (magnitude < 0.1f) {
			transform.rotation =  Quaternion.Euler(currentDir);
				} else if (magnitude != 0.0f) {
						transform.forward = Vector3.Normalize (new Vector3 (Input.GetAxis ("Horizontal"), 0f, Input.GetAxis ("Vertical")));
				}

		
		vertical = Input.GetAxis("Vertical");
		horizontal = Input.GetAxis("Horizontal");
		jumpButton = Input.GetButtonDown("Jump");

		Vector3 movement = new Vector3(horizontal, 0f, vertical);
		
		magnitude = Vector3.Magnitude(movement);
		
		animator.SetFloat("Speed", Mathf.Abs(magnitude));

		if (jumpButton && tid <= 0)
		{
			rigidbody.AddForce(new Vector3(0f, jumpSpeed, 0f));
			tid = tiden;
		}
			currentDir = transform.rotation.eulerAngles;

            if (transform.position.x >= level.LastObjectLoadedAt.x - 16)
            {
                level.AddPiece();
                level.RemovePiece();
            }
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NewsPaper")
        {
            DepressionManager.GetPaper(true);
        }
    }

	void FixedUpdate()
	{
		
		rigidbody.velocity = new Vector3(horizontal * speed, rigidbody.velocity.y, vertical * speed);
		
	}
	
}
