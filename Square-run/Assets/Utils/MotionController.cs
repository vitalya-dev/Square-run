using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {

	public LayerMask collisionMask;

	public bool is_grounded = false;

	public bool collisionLeft = true;

	public bool collisionRight = true;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		Debug.DrawRay(transform.position, Vector2.down, Color.red);
		Debug.DrawRay(transform.position, Vector2.left, Color.red);
		Debug.DrawRay(transform.position, Vector2.right, Color.red);

		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, collisionMask);
		if (hit.collider)
			is_grounded = true;
		else
			is_grounded = false;

		hit = Physics2D.Raycast(transform.position, Vector2.left, 1, collisionMask);
		if (hit.collider)
			collisionLeft = true;
		else
			collisionLeft = false;

		hit = Physics2D.Raycast(transform.position, Vector2.right, 1, collisionMask);
		if (hit.collider)
			collisionRight = true;
		else
			collisionRight = false;
	}

	public void Move(Vector3 velocity) {
		transform.position += velocity;
	}
}