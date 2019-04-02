using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buildControls : MonoBehaviour {
    
        Building[] PossibleTurrets;
        Object[] prefabs;
        public Transform TurretParent;
        public bool isBuiltOn;
        GameObject newBuilding;

        void Start()
        {
            prefabs = Resources.LoadAll("Prefabs/Buildings");
        
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
                    if (PossibleTurrets[i].name.Equals(BuildingName)) { 
                        newBuilding = Instantiate(PossibleTurrets[i].prefab as GameObject, transform.position, Quaternion.identity);
                        newBuilding.transform.SetParent(TurretParent);
                        PossibleTurrets[i].isAvailable = false;
                        isBuiltOn = true;
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

                        Destroy(newBuilding);
                        PossibleTurrets[i].isAvailable = true;
                        isBuiltOn = false;
                        break;
                    }
                }
            }
        }
}
