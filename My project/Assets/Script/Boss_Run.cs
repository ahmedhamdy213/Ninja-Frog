using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Run : StateMachineBehaviour
{
    public float RunRange = 100f;
    public float attackRange = 3f;
    public float speed = 2.5f;
    Transform Player;
    Rigidbody2D rb;
    Boss boss;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator .GetComponent<Boss>();
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.LookAtPlayer();
        Vector2 target = new Vector2(Player.position.x, rb.position.y);
        Vector2 newPos =Vector2.MoveTowards(rb.position, target, speed*Time.deltaTime);
        rb.MovePosition (newPos);
        if(Vector2.Distance(Player.position,rb.position) <= attackRange)
        {
            animator.SetTrigger("attack");
        }
        
    }

     
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }

    
}
