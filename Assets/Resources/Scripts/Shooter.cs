using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : Tower_Economy {

    public float MaxRange;
    GameObject Target;
    GameObject[] EnemyTable;
    public GameObject Projectile;
    public float ShotsPerSecond;
    AudioSource shootingFX;

    // Use this for initialization
    protected override void Start () {
        base.Start();
        StartCoroutine("Shooting");
        shootingFX=gameObject.GetComponent<AudioSource>();
    }
	
    IEnumerator Shooting()
    {
        while (true) {
            //If there are enemies within range...
            if(FindNextTarget()){
                ShootAtTarget();
            }
            yield return new WaitForSeconds(1.0f/ShotsPerSecond);
        }
    }

    IEnumerator PlayAudioClip()
    { 
        shootingFX.Play();
        yield return null;
    }

    void ShootAtTarget()
    {
        if(Vector3.Distance(transform.position,Target.transform.position)> MaxRange) return;

        GameObject newBullet=Instantiate(Projectile, transform.position, Quaternion.Euler(-90, 0, 0));
        newBullet.GetComponent<FireballBehaviour>().Target=Target;
        newBullet.transform.SetParent(transform);
        newBullet.SetActive(true);
        StartCoroutine("PlayAudioClip");
    }
    

    //Find all enemies, check who are in range and return the next.
    bool FindNextTarget()
    {

        UpdateEnemyTable();

        //If we couldn't find an enemy to target...
        if (EnemyTable.Length==0)
        { 
            return false;
        }



        float min_distance=Mathf.Infinity;
        GameObject closestEnemy=null;
        float distanceToEnemy=0.0f;

        foreach(GameObject enemy in EnemyTable)
        {
            if (enemy.GetComponent<CreepControls>().isDead) continue;
            
            /*
             * Here we can introduce the competition function, which chooses the fittest enemy as its target.
             */
            distanceToEnemy = calculateDistanceTo(enemy);
            if (distanceToEnemy < min_distance )
            {

                closestEnemy=enemy;
                min_distance=distanceToEnemy;
            }
        }
        Target=closestEnemy;
        return true;
    }
    

    void UpdateEnemyTable()
    {
        EnemyTable = GameObject.FindGameObjectsWithTag("Enemy");

    }

    //Calculate the distance between this turret and the closest enemy.
    float calculateDistanceTo(GameObject other)
    {
       return Vector3.Distance(this.transform.position,other.transform.position);
    }

    public override void Upgrade()
    {
        int GoldCost = getUpgradeCost();
        if (GoldAndStuff.PlayerGold < GoldCost * CurrentLevel)
        {
            Debug.Log("Not enough money");
            return;
        }
        if (CurrentLevel == maxLevel)
        {
            Debug.Log("Max level already reached!");
            return;
        }

        
        ShotsPerSecond+=1;
        MaxRange+= (1/2)*MaxRange;
        GoldAndStuff.PlayerGold -= GoldCost*CurrentLevel;
        CurrentLevel++;
    }

    public override void Sell()
    {
        base.Sell();
        Destroy(this.gameObject);
    }



}
