using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    /*
     *  This class controls some basic Turret economy operations.
     * 
     * It is inherited by all Turret objects.
     * 
     * 
     */

    public class Tower_Economy : MonoBehaviour {


        public int TowerCost;
        //made this protected to be accessible by other turrets
        protected int maxLevel,CurrentLevel;

        protected GameManagement GoldAndStuff;

        protected virtual void Start()
        {
            CurrentLevel = 1;
            maxLevel = 3;
        }
    

        /*
         * Upgrade the turret.
         * 
         * If we have enough gold and the level is not maxed,
         * we can upgrade.
         */

        public virtual void Upgrade() {
        }




        
        /*
         * Returns a function that calculates the
         * upgrade cost per turret level.
         */
        public int getUpgradeCost()
        {
            if (CurrentLevel != maxLevel) { 
                return (int) (TowerCost * ((float) CurrentLevel)/2.0f);
            }else return 0;
        }

    
        public int SellValue()
        {
            Debug.Log("Tower cost: "+TowerCost);
            Debug.Log("Level: "+ CurrentLevel);
            return (int) ( TowerCost* (1 + ((float)CurrentLevel-1)/3.0f));
        }
    }
