    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : StateMachineBehaviour
{
    public float attackRange=3f;
    private Transform PlayerPos;
    public float speed;
    Rigidbody2D rb;
    Boss boss;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        boss = animator.GetComponent<Boss>();
    }
    

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(PlayerPos.position.x, PlayerPos.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);
        if(Vector2.Distance( PlayerPos.position,rb.position)<= attackRange)
        {
            animator.SetTrigger("Kick");
        }
        else
        {
            animator.SetTrigger("Idle");
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Kick");
    }
}
