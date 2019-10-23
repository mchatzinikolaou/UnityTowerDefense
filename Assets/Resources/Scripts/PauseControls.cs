using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControls : MonoBehaviour {
    bool Paused;
    // Use this for initialization
    void Start () {
        Paused=false;

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseUnpause();
    }


    public void PauseUnpause()
    {
        Paused = !Paused;
        Time.timeScale = (Paused) ? 0.00f : 1.00f;
        gameObject.SetActive(Paused);
    }
}