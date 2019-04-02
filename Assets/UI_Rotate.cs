using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Rotate : MonoBehaviour {

    public float rotationSpeed;
	
	RectTransform rt;

    void Start()
    {
        rt= GetComponent<RectTransform>();

    }

	// Update is called once per frame
	void LateUpdate () {
		rt.RotateAround(rt.position,Vector3.up,rotationSpeed*Time.deltaTime);
	}
}
