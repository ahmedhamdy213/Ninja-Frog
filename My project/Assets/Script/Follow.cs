using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : StateMachineBehaviour
{
    private Transform PlayerPos;
    public float speed;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,PlayerPos.position,speed*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsFollowing", false);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
