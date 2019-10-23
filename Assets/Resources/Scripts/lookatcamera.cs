using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookatcamera : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        transform.LookAt(GameObject.FindWithTag("MainCamera").transform);
    }
}
