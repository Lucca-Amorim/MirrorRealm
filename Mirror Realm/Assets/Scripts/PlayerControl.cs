using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PlayerMovement))]
public class PlayerControl : MonoBehaviour{

	[SerializeField] public float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	public float velQueda = 2.5f;
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;							// A position marking where to check if the player is grounded.

	Animator anim;
	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }


	private void Awake(){
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		if(OnLandEvent == null){
			OnLandEvent = new UnityEvent();
        }
	}

	void Update(){
		if(m_Rigidbody2D.velocity.y <0){
			m_Rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (velQueda - 1) * Time.deltaTime;
		}
	}
	private void FixedUpdate(){
		bool wasGrounded = m_Grounded;
		m_Grounded = false;

		Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
		for (int i = 0; i < colliders.Length; i++){
			if (colliders[i].gameObject != gameObject){
				m_Grounded = true;
				anim.SetBool("Jump", false);
				if (!wasGrounded)
					OnLandEvent.Invoke();
			}
		}
	}


	public void Move(float move, bool crouch, bool jump){
		if(m_Grounded || m_AirControl){
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
			if(move > 0 && !m_FacingRight){
				Flip();
			}
			else if(move < 0 && m_FacingRight){
				Flip();
			}
		}
		if (m_Grounded && jump){
			m_Grounded = false;
			//m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
			m_Rigidbody2D.AddRelativeForce(new Vector2(0f, m_JumpForce));
			
		}
	}


	private void Flip(){
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}