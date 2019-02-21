using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionController : MonoBehaviour {

	public LayerMask collisionMask;

	public bool is_grounded = false;

	// Use this for initialization
	void Start() {

	}

	// Update is called once per frame
	void Update() {
		Debug.DrawRay(transform.position, Vector2.down, Color.red);
		RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1, collisionMask);
		if (hit.collider)
			is_grounded = true;
		else
			is_grounded = false;
	}

	public void Move(Vector3 velocity) {
		transform.position += velocity;
	}
}