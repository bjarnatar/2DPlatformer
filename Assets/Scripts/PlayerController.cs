using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float topSpeed = 10.0f;
	public float jumpForce = 10.0f;
	public Transform[] groundChecks;
	public float groundedDistance = 0.05f;

	private bool facingRight = true;

	// Use this for initialization
	void Start ()
	{
	
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			// JUMP!
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
		}
	}

	// FixedUpdate is called once per physics frame
	void FixedUpdate ()
	{
		float speed = Input.GetAxis("Horizontal") * topSpeed;

		// If speed is greater than 0 AND NOT facingRight
		if (speed > 0 && !facingRight)
		{
			Flip();
		}
		else if (speed < 0 && facingRight)
		{
			Flip();
		}


		rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
	}

	void Flip()
	{
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}

	bool IsGrounded()
	{
		foreach (Transform gc in groundChecks)
		{
			Vector2 start = new Vector2(gc.position.x, gc.position.y);
			Vector2 end = start + Vector2.up * -groundedDistance;
			RaycastHit2D rh = Physics2D.Linecast(start, end);

			if (rh.collider)
			{
				return true;
			}
		}
		return false;
	}



}
