using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Building
{
        public string name;
        public Object prefab;
        public bool isAvailable;



    

    public Building(string Name,Object Prefab,bool IsAvailable)
    {
        this.name=Name;
        this.prefab=Prefab;
        this.isAvailable=IsAvailable;
    }


 }




