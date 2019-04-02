//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;



///*
// * 
// * 
// *  Here I create, maintain and edit a map that's used to generate the stage.
// *  
// *
// * 
// * The map format should be something like a grid with characters as this:
// * *******************
// * N M
// * 
// * B B B B B B 
// * H R B B B B
// * B R R B B B
// * B B R S B B
// * *********************
// * 
// * That must produce a stage as this, after checking if there is a path from S (source) to H (home).
// *
// * 
// */
 
//public class Map : MonoBehaviour {

//    //the map as it is loaded on the memory.
//    char[][] map;

//    //Typedef Path Stack<int x, int y>
//    //Path cripPath;

//	// Use this for initialization
//	void Start () {
//		//map=LoadMapFromFile();
//	}
	
//	// Update is called once per frame
//	void Update () {
		
//	}


//    //Load the map from the file.
//    /*LoadMapFromFile(File){
//     *      
//            open file to read
//            int rows = read number
//            int columns = read number
//            char[][] tempMap;
//                for (rows)
//                    for (columns)
//                        tempMap[row][column]=read in char[row][column];
//            close file
//            checkRoadToHomebase(map);
    
//    }
//    */








//    //Path checkRoadToHomebase(Map) Check if the map contains a path from the spawn to the home, and no dead-ends preferably.
//    //This will create a stack from positions the cripps must follow to get to the end. This serves as an optimizer since each cripp must not calculate the path to the base,
//    // but instead just follow a pre-calculated set of instructions.
//    /*

//    //->List of gameobject blocks.
//    //type here.


//    CreateMap(map Bitmap)
//    {
//    for (x, y) in bitmap
//    {
//        read Bitmap(x,y) 
//        SpawnBlock(new Vector3(x*sizeofBlock,y*sizeofBlock,0),decodedBlock(x,y))
//    }
//    }

//    SpawnBlock(location,type)
//    */




//    //This is the current map. could be only one sole map, or more in a list.
//    char[][] getMap()
//    {
//        return map;
//    }




//}
