using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviourRhino : StateMachineBehaviour
{
    Transform player;
    float timer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator.SetBool("isChasing", false);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        timer += Time.deltaTime;
        if (timer > 0.5f)
            animator.SetBool("isAttacking", false);

        /*if (timer > 15)
            animator.SetBool("isChasing", false);*/
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
