using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_GUI : MonoBehaviour {

    GameObject BuildingTile;

	public void ChangeReferencedTile(GameObject Tile)
    {
        BuildingTile= Tile;

        //Change the reference of the onClick events in the children.



    }
}
