using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDestroyer : MonoBehaviour {
	private E e;
	private MotionController e_controller;

	// Use this for initialization
	void Start() {
		e = GetComponent<E>();
		e_controller = transform.parent.GetComponent<MotionController>();
	}

	// Update is called once per frame
	void Update() {
		if (e_controller.collisionLeft || e_controller.collisionRight || e_controller.collisionAbove) {
			// for (int i = 0; i < 200; i++) {
			// 	GameObject o = Instantiate(e.plump, e.transform.position, Quaternion.identity);
			// 	o.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)) * Random.Range(200, 1000));
			// }
			// GameObject.Destroy(gameObject);
			GetComponent<Animator>().SetTrigger("Explode");
		}
	}
}