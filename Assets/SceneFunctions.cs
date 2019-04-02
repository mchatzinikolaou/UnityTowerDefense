using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFunctions : MonoBehaviour {


    Scene loadedLevel;


    // Use this for initialization
    void Start () {
        //Initial level;
        loadedLevel = SceneManager.GetActiveScene();

    }

    // Update is called once per frame
    void Update () {
		
	}


    public void RestartScene() { 
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }
}
