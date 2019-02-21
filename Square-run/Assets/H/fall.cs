using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fall : StateMachineBehaviour {
	private MotionController m_controller;
	private H h;
	private Vector2 target;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		m_controller = animator.transform.parent.GetComponent<MotionController>();
		h = animator.GetComponent<H>();

		target = m_controller.transform.position + new Vector3(0, -1, 0);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Vector2 velocity = h.velocity;
		velocity.x = 0;

		if (Vector2.Distance(m_controller.transform.position, target) > 0.5) {
			m_controller.Move(velocity * -1 * Time.deltaTime);
		} else {
			m_controller.transform.position = target;
			animator.SetTrigger("Idle");
		}
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

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