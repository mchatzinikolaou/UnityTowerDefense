using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buildControls : MonoBehaviour {
    
        Building[] PossibleTurrets;
        public Transform TurretParentObject;
        public bool isBuiltOn;
        GameObject newBuilding;
        GameManagement GoldAndStuff;

        void Start()
        {
            GoldAndStuff = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
            Object[] prefabs = Resources.LoadAll("Prefabs/Buildings");
        
            isBuiltOn =false;

            PossibleTurrets=new Building[prefabs.Length];

            for (int i=0;i<prefabs.Length;i++)
            {
                PossibleTurrets[i]=new Building(prefabs[i].name,prefabs[i],true);
            }
        }
	
        public void BuildingCreate(string BuildingName)
        {
            if (!isBuiltOn)
            {
                for (int i = 0; i < PossibleTurrets.Length; i++)
                {
                    //When the right building is matched.
                    if (PossibleTurrets[i].name.Equals(BuildingName)) { 
                        GameObject Building= PossibleTurrets[i].prefab as GameObject;
                        int Gold= GoldAndStuff.PlayerGold;
                        int TowerCost= Building.GetComponent<Tower_Economy>().TowerCost;

                        if (TowerCost > Gold)
                        {
                            Debug.Log("Not enough gold!");
                            return;
                        }

                        else
                        {
                            newBuilding = Instantiate(Building, transform.position, Quaternion.identity);
                            newBuilding.transform.SetParent(TurretParentObject);
                            PossibleTurrets[i].isAvailable = false;
                            isBuiltOn = true;
                            GoldAndStuff.PlayerGold-= TowerCost;
                        }
                    break;
                    }
                }
            }
        }

        public void DeleteBuilding()
        {

            if (isBuiltOn)
            {
                for (int i = 0; i < PossibleTurrets.Length; i++)
                {

                    if (PossibleTurrets[i].isAvailable == false)
                    {
                    
                    /*
                     * Use delegates later
                     */
                     if (newBuilding.CompareTag("Slowing Turret"))
                        {
                            newBuilding.GetComponent<SlowTower>().DropAllSlows();
                        }

                        GoldAndStuff.PlayerGold += newBuilding.GetComponent<Tower_Economy>().SellValue();
                        Destroy(newBuilding);
                        PossibleTurrets[i].isAvailable = true;
                        isBuiltOn = false;
                    


                        break;
                    }
                }
            }
        }
}
