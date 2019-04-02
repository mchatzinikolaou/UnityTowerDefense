using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehaviour : MonoBehaviour {

    public float flatDamage;
    public float projectileSpeed;
    public GameObject Target;
   
    
    // Update is called once per frame
    void FixedUpdate()
    {
        SeekTarget();
    }

    void SeekTarget()
    {
        //If the creep dies , destroy this bullet.
        if (Target == null){ Destroy(this.gameObject); } //Maybe also play a fade-out animation /effect

        //Seek the target and go towards it.
        Vector3 targetPosition=Target.transform.position;
        this.transform.LookAt(targetPosition);
        this.transform.position=Vector3.MoveTowards(this.transform.position,targetPosition,projectileSpeed*Time.deltaTime);
        
    }

   
    //When it collides with a creep it deals damage. 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Play animation
            DealDamage(other.gameObject);
        }
    }


    //Deal flat(for the time being) damage to the creep).
    void DealDamage(GameObject creep)
    {
        creep.GetComponent<CreepControls>().TakeDamage(flatDamage);
        Destroy(this.gameObject);
    }

   

    public void SetTarget(GameObject target)
    {
        Target = target;
    }

    public void setDamage(float newDamage)
    {
        flatDamage = newDamage;
    }


    public float getDamage()
    {
        return flatDamage;
    }

    public GameObject getTarget()
    {
        return Target;
    }

    public float getSpeed()
    {
        return projectileSpeed;
    }

    public void setSpeed(float newSpeed)
    {
        projectileSpeed = newSpeed;
    }
}
