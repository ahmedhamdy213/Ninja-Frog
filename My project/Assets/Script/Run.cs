using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : StateMachineBehaviour
{
    public float Timer;
    public float MinTime;
    public float MaxTime;
    
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Timer=Random.Range(MinTime, MaxTime);
        
    }

    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (Timer<=0)
        {
            animator.SetTrigger("Kick");
        }
        else
        {
            Timer-=Time.deltaTime; 
        }
        
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    
}
