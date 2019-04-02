using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Goblin_ro_ctrl : MonoBehaviour {
	
	
	Animator animator;
    NavMeshAgent creepMovementAgent;
	
	
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        creepMovementAgent=GetComponent<NavMeshAgent>();
	}

    
    void LateUpdate () 
	{
        AnimationControls(); 	
	}
    
    void AnimationControls()
    {
        animator.SetFloat("Speed", GetComponent<CreepControls>().getSpeedPercentage());
        //If it is dead, play death animation.
        //If it is moving, play running animation.
    }



}

