using UnityEngine;

public class CharacterController2D : MonoBehaviour
{					
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;					
	[SerializeField] private Transform m_CeilingCheck;							

	const float k_GroundedRadius = .2f;
	public bool m_Grounded;           
	const float k_CeilingRadius = .2f; 
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 velocity = Vector3.zero;

	public float fallMultiplier = 400;
	public float lowJumpMultiplier = 200;

	public int extraJump = 2;

	public int dashCount = 1;

	private float jumpCorrection = 0.5f;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	public void AddJump()
	{
		extraJump++;
	}

	private void FixedUpdate()
	{
		m_Grounded = false;
		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++)
		{
			if (colliders[i].gameObject != gameObject)
				m_Grounded = true;
			if (m_Grounded){
				extraJump = 2;
				dashCount = 1;
			}

		}
	}

	public void Impulse(float x,float y){
		m_Rigidbody2D.velocity= new Vector2(x, y);
	}

	private void OnTriggerEnter2D(Collider2D other) {
    	if (other.tag == "deadzone")
    	{
        	transform.position = new Vector3(-14.19f,0f,0f);
    	}
	}

	public void Move(float move, bool jump, bool dash)
	{
		if (m_Grounded || m_AirControl)
		{
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
		}

		if (dash && dashCount > 0 && !m_FacingRight){
			m_Rigidbody2D.velocity= new Vector2(-60f, 0f);
			dashCount--;
		}

		if (dash && dashCount > 0 && m_FacingRight){
			m_Rigidbody2D.velocity= new Vector2(60f, 0f);
			dashCount--;
		}

		if (jump && extraJump > 0)
		{
			m_Grounded = false;
			if (!Input.GetButton("Jump")){
				m_Rigidbody2D.velocity= new Vector2(0f,jumpCorrection);
				m_Rigidbody2D.AddForce(new Vector2(0f, lowJumpMultiplier));
			} else{
				m_Rigidbody2D.velocity= new Vector2(0f, jumpCorrection);
				m_Rigidbody2D.AddForce(new Vector2(0f, fallMultiplier));
			}
			extraJump--;
		}
	}


	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		jumpCorrection= jumpCorrection * -1;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

