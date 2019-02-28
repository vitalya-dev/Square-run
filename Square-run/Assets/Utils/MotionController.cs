using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {

	public LayerMask collisionMask;

	public bool is_grounded = false;

	public bool collisionLeft = false;

	public bool collisionRight = false;

	public bool collisionAbove = false;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		Debug.DrawRay(transform.position, Vector2.down / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.left / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.right / 2, Color.red);
		Debug.DrawRay(transform.position, Vector2.up / 2, Color.red);

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, collisionMask);
		if (hit.collider)
			is_grounded = true;
		else
			is_grounded = false;

		hit = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, collisionMask);
		if (hit.collider)
			collisionLeft = true;
		else
			collisionLeft = false;

		hit = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, collisionMask);
		if (hit.collider)
			collisionRight = true;
		else
			collisionRight = false;

		hit = Physics2D.Raycast(transform.position, Vector2.up, 0.6f, collisionMask);
		if (hit.collider)
			collisionAbove = true;
		else
			collisionAbove = false;
	}

	public void Move(Vector3 velocity) {
		transform.position += velocity;
	}
}