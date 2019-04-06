using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : Tower_Economy
{
    //This will be used by each creep to know what slow effect it is under
    public float BasicSlow, MaxSlow, BasicRange, MaxRange;
    float slowPercentage,currentRange ;
    GameObject[] EnemyTable;

    protected override void Start()
    {
        base.Start();
        if (BasicSlow == 0.0f) BasicSlow = 0.2f;
        if (BasicRange == 0.0f) BasicRange = 20;
        if (MaxSlow==0.0f) MaxSlow = 0.8f;
        if(MaxRange==0.0f) MaxRange = 100;

        GoldAndStuff = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
        slowPercentage = BasicSlow;
        currentRange = BasicRange;
    }

    void Update()
    {
        SlowEnemies();
    }
    
    void SlowEnemies()
    {
        EnemyTable = GameObject.FindGameObjectsWithTag("Enemy");
        float distance;
        foreach (GameObject enemy in EnemyTable)
        {
            if (enemy.GetComponent<CreepControls>().isDead) continue;


            distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distance <= currentRange)
            {
                enemy.GetComponent<CreepControls>().Slow(slowPercentage);
            }
            else
            {
                enemy.GetComponent<CreepControls>().ReleaseSlow();
            }
        }
    }
    
    public void DropAllSlows()
    {
        foreach (GameObject enemy in EnemyTable)
        {
            enemy.GetComponent<CreepControls>().ReleaseSlow();
        }
    }

    public float getSlowPercentage()
    {
        return slowPercentage;
    }

    public float getRange()
    {
        return currentRange;
    }


    /*
        * The parent method checks if enough gold is available and levels 
        * the turret up.
        * 
        * This method will linearly interpolate (somehow) the current slow value
        * and range towards the maximum.
        * 
        */
    public override void  Upgrade()
    {
        int GoldCost= getUpgradeCost();
        if (GoldAndStuff.PlayerGold < GoldCost)
        {
            Debug.Log("Not enough money");
            return ;
        }
        if (CurrentLevel == maxLevel)
        {
            Debug.Log("Max level already reached!");
            return ;
        }

        CurrentLevel++;
        slowPercentage=BasicSlow + (MaxSlow - BasicSlow)* ((float)CurrentLevel / (float) maxLevel);
        currentRange = BasicRange + (MaxRange - BasicRange) * ((float)CurrentLevel / (float)maxLevel);
        Debug.Log("New Slow : "+slowPercentage + "\nNew Range: "+ currentRange);
        GoldAndStuff.PlayerGold-=GoldCost;
    }


    


}
