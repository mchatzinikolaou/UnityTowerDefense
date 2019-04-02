using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

	public float AngularMomentum;
   
    void LateUpdate()
    {

        transform.Rotate(Vector3.up, AngularMomentum * Time.deltaTime);
    }
}
