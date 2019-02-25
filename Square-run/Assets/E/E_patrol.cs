using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_patrol : StateMachineBehaviour {
	private MotionController m_controller;
	private E e;

	private Vector2 target_r;
	private Vector2 target_l;
	private Vector2 target_c;

	// OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		m_controller = animator.transform.parent.GetComponent<MotionController>();
		e = animator.GetComponent<E>();

		target_r = m_controller.transform.position + new Vector3(e.rad, 0, 0);
		target_l = m_controller.transform.position + new Vector3(-e.rad, 0, 0);
		target_c = target_l;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		float dir = Mathf.Sign(target_c.x - m_controller.transform.position.x);
		Vector2 velocity = e.velocity;
		velocity.y = 0;

		if (Vector2.Distance(m_controller.transform.position, target_c) > 0.5) {
			m_controller.Move(velocity * dir * Time.deltaTime);
		} else {
			m_controller.transform.position = target_c;
			if (target_c == target_l)
				target_c = target_r;
			else if (target_c == target_r)
				target_c = target_l;
		}
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