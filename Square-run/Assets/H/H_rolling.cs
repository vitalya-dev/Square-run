using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_rolling : StateMachineBehaviour {
	private MotionController m_controller;
	private H h;
	private int dir;
	private Vector2 target;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		m_controller = animator.transform.parent.GetComponent<MotionController>();
		h = animator.GetComponent<H>();

		dir = (int)animator.GetFloat("Direction");
		target = m_controller.transform.position + new Vector3(dir, 0, 0);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if (Vector2.Distance(m_controller.transform.position, target) > 0.1) {
			m_controller.Move(h.velocity * dir * Time.deltaTime);
		} else {
			m_controller.transform.position = target;
			animator.SetTrigger("Idle");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		h.sprite_index += dir;
		if (h.sprite_index < 0)
			h.sprite_index = h.sprites.Length - 1;
		if (h.sprite_index >= h.sprites.Length)
			h.sprite_index = 0;

		h.GetComponent<SpriteRenderer>().sprite = h.sprites[h.sprite_index];
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}