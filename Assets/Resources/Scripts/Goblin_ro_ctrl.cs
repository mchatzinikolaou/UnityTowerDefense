using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Goblin_ro_ctrl : MonoBehaviour {
	
	
	Animator animator;
	

	void Start () {
        animator = GetComponent<Animator>();
	}

    
    void LateUpdate () 
	{
        AnimationControls(); 	
	}
    
    void AnimationControls()
    {
        animator.SetFloat("Speed", GetComponent<CreepControls>().getSpeedPercentage());
    }



}

