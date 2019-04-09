using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;








public class Spawner : MonoBehaviour {

  
    //The area which we will spawn the monsters in.
        public BoxCollider spawnArea;
        public GameObject creep;
        //IList<GameObject> wave1;


    // Use this for initialization
        
            
        //Spawn a creep Wave desctibed in "creeps" list.
        void spawnCreepWave(IList<GameObject> creeps)
        {
                foreach (var creep in creeps)
                {
                    Instantiate(creep, getRandomSpawnPoint(), Quaternion.identity);
                }
        }

       

        public void spawnCreep(GameObject creep)
        {
            Instantiate(creep, getRandomSpawnPoint(), Quaternion.identity).SetActive(true);
        }

        //Return a random spawn point in the spawining area, which must be cubic.
    Vector3 getRandomSpawnPoint()
        {
                //Generate the position
                float x_center = spawnArea.transform.position.x;
                float y_center = spawnArea.transform.position.y;
                float z_center = spawnArea.transform.position.z;


                float x_size=spawnArea.bounds.size.x;
                float z_size=spawnArea.bounds.size.z;
            
                float x_position=UnityEngine.Random.Range(x_center- x_size/2, x_center + x_size /2);
                float y_position=y_center;
                float z_position= UnityEngine.Random.Range(z_center -z_size/2, z_center + z_size/2);


                //Return the random point.
                return new Vector3(x_position,y_position,z_position);
        }
       }

    