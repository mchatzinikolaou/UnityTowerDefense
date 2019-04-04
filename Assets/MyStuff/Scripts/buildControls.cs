using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class buildControls : MonoBehaviour {

    GameObject[] AvailableTurrets;
    GameObject BuiltTurret;
    
    public Transform TurretParentObject;
    public bool isBuiltOn;
    GameManagement GoldAndStuff;

    void Start()
    {
        GoldAndStuff = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
                 
        isBuiltOn =false;
    }
	
    public void BuildingCreate(string BuildingName)
    {
        if (!isBuiltOn)
        {
            for (int i = 0; i < AvailableTurrets.Length; i++)
            {
                //When the right building is matched.
                if (AvailableTurrets[i].name.Equals(BuildingName)) { 
                    int Gold= GoldAndStuff.PlayerGold;
                    int TowerCost= AvailableTurrets[i].GetComponent<Tower_Economy>().TowerCost;

                    if (TowerCost > Gold)
                    {
                        Debug.Log("Not enough gold!");
                        return;
                    }

                    else
                    {
                        BuiltTurret = Instantiate(AvailableTurrets[i], transform.position, Quaternion.identity);
                        BuiltTurret.transform.SetParent(TurretParentObject);
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
                
                    if (BuiltTurret.CompareTag("Slowing Turret"))
                    {
                        BuiltTurret.GetComponent<SlowTower>().DropAllSlows();
                    }
                    GoldAndStuff.PlayerGold += BuiltTurret.GetComponent<Tower_Economy>().SellValue();
                    Destroy(BuiltTurret);
                    isBuiltOn = false;
        }
    }


    //Gets called from the game manager and loads every turret in the
    //available list.
    public void SetAvailableTurrets(Object[] Turrets)
    {
        AvailableTurrets=new GameObject[Turrets.Length];
        for (int i=0;i< Turrets.Length;i++)
        {
            AvailableTurrets[i] = Turrets[i] as GameObject;
                
        }
    }

    public void UpgradeTurret()
    {
        if (BuiltTurret == null){
            Debug.Log("Trying to upgrade a non-existing turret!!");
            return;
        }
        BuiltTurret.GetComponent<Tower_Economy>().Upgrade();
    }
}
