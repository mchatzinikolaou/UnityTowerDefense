using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruction : MonoBehaviour {

	// Use this for initialization
	void Start () {

        DestroyAllWithTag("Enemy");
        DestroyAllWithTag("Tower");

    }
	


    void DestroyAllWithTag(string tag)
    {
        GameObject[] ToBeDestroyed = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject Object in ToBeDestroyed)
        {
            Destroy(Object);
        }
    }
}
