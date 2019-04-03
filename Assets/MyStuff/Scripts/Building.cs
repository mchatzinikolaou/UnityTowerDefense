using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Building
{
        public string name;
        public Object prefab;
        public bool isAvailable;




    public Building(string name,Object prefab,bool isAvailable)
    {
        this.name= name;
        this.prefab= prefab;
        this.isAvailable= isAvailable;
    }


 }




