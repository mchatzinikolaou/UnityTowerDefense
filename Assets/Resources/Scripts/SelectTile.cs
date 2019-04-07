using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour {

    GameObject SelectedBuilding;


    void Start()
    {
        SelectedBuilding = null;
        Cursor.visible = true;
    }



    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectBuilding();
        }
    }


    //Select a new Building.
    void SelectBuilding()
    {
        
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {

                GameObject NewBuilding = hitInfo.transform.gameObject;
                //Now we program the new selected tile's GUI.
                if (NewBuilding.layer == 10) {

                    if (SelectedBuilding != null) { 
                        SelectedBuilding.GetComponent<Tower_Economy>().ToggleGUI(false);
                    }

                    SelectedBuilding = NewBuilding;
                    SelectedBuilding.GetComponent<Tower_Economy>().ToggleGUI(true);
                }

            }
    }

}

