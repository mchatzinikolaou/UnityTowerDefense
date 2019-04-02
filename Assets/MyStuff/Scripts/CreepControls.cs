using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CreepControls : MonoBehaviour
{

    NavMeshAgent agent;
    GameObject Destination;
    GameObject slowEffects;
    float curr_SlowPercentage;
    float baseSpeed;
    float maxHP;
    float currentHP;
    GameObject AnimationEffects;
    public bool isDead;
    public int goldDrop;
    int damage;
    bool isSlowed;





    // Use this for initialization
    void Start()
    {
        isDead=false;
        isSlowed = false;
        //AnimationEffects=GameObject.GetComponent<>();
        InitiateAgent();
        InitiateSpeedSettings();
        Initiate_VFX();
        maxHP = 100;
        currentHP=maxHP;
        damage=1;
    }

    void FixedUpdate()
    {
        if (!isDead){ 
            CheckIfDead();
        }
    }

    void CheckIfDead()
    {
        
        if (currentHP <= 0) {

            //AnimationEffects.PlayDeathAnimation();
            //StartCoroutine("WaitAndDestroy"); 
            isDead=true;
            Destroy(gameObject);
        }
    }



    //Get the biggest slow value from the turrets around you and get slowed by it.
    public void Slow(float percentage)
    {
        
        if (percentage > curr_SlowPercentage)
        {
            curr_SlowPercentage = percentage;
            agent.speed = baseSpeed * (1 - percentage / 100);
            //Begin the particle effects
            slow_VFX(true);

        }
    }

    public void ReleaseSlow()
    {
        agent.speed = baseSpeed;
        curr_SlowPercentage = 0.0f;
        //StopParticle effects.
        slow_VFX(false);
    }



    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Slowing Turret"))
    //    {
    //        Slow(other.gameObject.GetComponent<SlowTower>().slowPercentage);

    //    }
    //}


    ///*
    // * Whenever a creep escapes a slow AoE , the effect is released.
    // */

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Slowing Turret"))
        {
            ReleaseSlow();
        }
    }


    public float getHealthPercentage()
    {
        return currentHP/maxHP;
    }

    public void TakeDamage(float indamage)

    {
        currentHP -= indamage;
        Debug.Log("New Hp: "+currentHP);
    }

    
    void Initiate_VFX()
    {
        //CHANGE THIS HERE TO FIND PARTICULAR CHILD
        slowEffects = this.transform.GetChild(0).gameObject;
        //CHANGE THIS HERE TO FIND PARTICULAR CHILD
        slow_VFX(false);
    }

    void slow_VFX(bool show)
    {
        slowEffects.SetActive(show);
    }

    void InitiateAgent()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        setAgentDestination();
    }

    //Set the destination to the homebase.
    void setAgentDestination()
    {
        Destination = GameObject.FindWithTag("Finish");
        agent.SetDestination(Destination.transform.position);
    }

    void InitiateSpeedSettings()
    {
        curr_SlowPercentage = 0.0f;
        baseSpeed = agent.speed;
    }

    public float getSpeedPercentage()
    {
        return agent.speed/baseSpeed;
    }

    public int getDamage()
    {
        return damage;
    }
}
