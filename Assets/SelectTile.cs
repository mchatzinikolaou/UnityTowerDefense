using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTile : MonoBehaviour {
    GameObject SelectedTile;

    

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Close the previous window.
            //if (SelectedTile != null) { 
            //    SelectedTile.transform.GetChild(0).gameObject.SetActive(false);
            //}

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);

            if (hit)
            {
                //If you hit the same object, do nothing.
                if (hitInfo.transform.gameObject==SelectedTile)
                {
                    return;
                }
                else
                {
                    //Else, close the previous window.
                    if (SelectedTile != null) {

                        Transform oldCanvas= SelectedTile.transform.Find("Canvas");

                        if (oldCanvas != null) { 
                           oldCanvas.gameObject.SetActive(false);
                        }
                    }
                }
                
                SelectedTile =hitInfo.transform.gameObject;
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);

                if (SelectedTile.tag == "BuildingBase")
                {
                    //This here fetches the UI panel;

                    //This is the canvas
                    SelectedTile.transform.Find("Canvas").gameObject.SetActive(true);
                }
                else
                {
                    //Put the rest of the tiles here, if any...
                }
            }
            else
            {
            }
        }
    }
}
