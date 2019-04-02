using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTower : MonoBehaviour
{
    //This will be used by each creep to know what slow effect it is under
    public float slowPercentage,Range;
    GameObject[] EnemyTable;

    void Update()
    {
        UpdateEnemyTable_WithinRange();
    }




    void UpdateEnemyTable_WithinRange()
    {
        EnemyTable = GameObject.FindGameObjectsWithTag("Enemy");
        float distance;
        foreach (GameObject enemy in EnemyTable)
        {
            if (enemy.GetComponent<CreepControls>().isDead) continue;


            distance = Vector3.Distance(this.transform.position, enemy.transform.position);
            if (distance <= Range)
            {
                enemy.GetComponent<CreepControls>().Slow(slowPercentage);
            }
            else
            {
                enemy.GetComponent<CreepControls>().ReleaseSlow();
            }
        }
    }

    //Foreach enemy , release its slow.
    public void DropAllSlows()
    {
        foreach (GameObject enemy in EnemyTable)
        {
            enemy.GetComponent<CreepControls>().ReleaseSlow();
        }
    }

}
