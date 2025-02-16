﻿using UnityEngine;
using UnityEngine.AI;






public class CreepControls : MonoBehaviour 
{
    

    NavMeshAgent agent;
    GameObject Destination,slowEffects,AnimationEffects;
    GameManagement managerScript;
    
    float curr_SlowPercentage, baseSpeed,currentHP;

    public bool isDead, isSlowed;
    public int goldDrop;
    public int damage, maxHP;
    public int Strength;

    // Use this for initialization
    void Start()
    {
        baseSpeed=gameObject.GetComponent<NavMeshAgent>().speed;
        goldDrop=5;
        isDead=false;
        isSlowed = false;
        InitiateAgent();
        InitiateSpeedSettings();
        Initiate_VFX();
        if(maxHP==0) maxHP=100;
        currentHP=maxHP;
        managerScript=GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
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
            Die();
        }
    }

    void Die()
    {
        managerScript.gainGold(goldDrop);
        isDead = true;
        Destroy(gameObject); 
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
    

    /*GameStats.*/

    public void TakeDamage(float indamage)
    {
        currentHP -= indamage;
    }

    public int getDamage()
    {
        return damage;
    }
    
    /* Agent settings.*/

    void InitiateAgent()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        setAgentDestination();
    }
    
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
        return (agent.speed / baseSpeed);
    }


    /* Animation settings */
         
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


}
