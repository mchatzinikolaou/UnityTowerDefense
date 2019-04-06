using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour {

    GameObject SelectedTile;


    void Start()
    { 
        Cursor.visible = true;
    }



    void Update()
    {
    }

    void Selections()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {

                GameObject HitObject = hitInfo.transform.gameObject;
                //If you hit the previous object, do nothing.
                if (HitObject == SelectedTile)
                {
                    return;
                }
                else
                {
                    //Else, close the previous window.
                    if (SelectedTile != null)
                    {
                        //Debug.Log("Selected "+SelectedTile.transform);
                        //For all it's children components Taged as GUI , close them.
                        foreach (Transform child in SelectedTile.transform)
                        {
                            Debug.Log("Child tag: " + child.tag);
                            if (child.tag == "GUI")
                            {
                                Debug.Log("Deactivating Child tag: " + child.tag);
                                child.gameObject.SetActive(false);
                            }
                        }
                    }
                }


                //Now we program the new selected tile's GUI.
                SelectedTile = HitObject;

                if (SelectedTile.tag == "BuildingBase")
                {
                    buildControls slotInfo = SelectedTile.GetComponent<buildControls>();

                    //If there is a turret on this building tile...
                    if (slotInfo.isBuiltOn)
                    {
                        Debug.Log("it is built");
                        GameObject TowerGUI = slotInfo.transform.GetChild(1).gameObject;
                        TowerGUI.SetActive(true);
                        if (!TowerGUI.name.Equals("TowerGUI")) Debug.Log("Name does not equal TowerGUI!");

                    }
                    else
                    {

                        Debug.Log("NOT built");
                        GameObject BuildingGUI = slotInfo.transform.GetChild(0).gameObject;
                        BuildingGUI.SetActive(true);
                        if (!BuildingGUI.name.Equals("BuildingGUI")) Debug.Log("Name does not equal BuildingGUI!");

                    }
                }

            }
        }
    }
}

