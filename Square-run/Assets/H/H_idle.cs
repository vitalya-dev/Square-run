using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H_idle : StateMachineBehaviour {
	private MotionController m_controller;
	private H h;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetFloat("Direction", 0.0f);
		m_controller = animator.transform.parent.GetComponent<MotionController>();
		h = animator.GetComponent<H>();
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		animator.SetFloat("Direction", 0.0f);
		if (!m_controller.is_grounded) {
			animator.SetTrigger("fall");
			return;
		}

		float input = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs(input) > 0) {
			float dir = Mathf.Sign(input);
			animator.SetFloat("Direction", dir);
			if ((dir > 0 && !m_controller.collisionRight) ||
				(dir < 0 && !m_controller.collisionLeft)) {
				animator.SetTrigger("Rolling");
			}
		}
		if (Input.GetKeyDown(KeyCode.Space))
			animator.SetTrigger("Jump");
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}