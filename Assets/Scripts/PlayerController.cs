using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float topSpeed = 10.0f;

	private bool facingRight = true;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
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
}
