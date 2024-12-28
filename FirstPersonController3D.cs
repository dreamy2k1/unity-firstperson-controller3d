using UnityEngine;


public class BewegeSpieler : MonoBehaviour
{
	public float speed;
	
	public float jumpForce;
	
	public Transform orientation;
	
	private float horizontalInput;
	
	private float vertikalInput;
	
	private Rigidbody rb;
	
	private bool grounded;
	
	private Vector3 way;
	
	
	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	
	void Update()
	{
		MaxSpeed();
		Application.targetFrameRate = 120;
	}
	
	
	void FixedUpdate()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		vertikalInput = Input.GetAxisRaw("Vertical");
		
		if (Input.GetKeyDown(KeyCode.Space) && grounded)
		{
			rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
		}
		PlayerMovemend();
	}
	
	
	void PlayerMovemend()
	{
		way = orientation.forward * vertikalInput + orientation.right * horizontalInput;
		rb.AddForce(way * speed * 10f, ForceMode.Force);
	}
	
	
	void MaxSpeed()
	{
		Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
		
		if (flatVelocity.magnitude > speed)
		{
			Vector3 maxVelocity = flatVelocity.normolized * speed;
			rb.velocity = new Vector3(maxVelocity.x, rb.velocity.y, maxVelocity.z);
		}
	}
	
	
	void OnCollisionEnter()
	{
		grounded = true;
	}
	
	void OnCollisionStay()
	{
		grounded = true;
	}
	
	void OnCollisionExit()
	{
		grounded = false;
	}
})
