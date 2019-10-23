
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFunctions : MonoBehaviour {


    Scene loadedLevel;
    GameObject PauseMenu;
    bool Paused;
    string MainMenuScene;
    // Use this for initialization
    void Start () {
        //Initial level;
        loadedLevel = SceneManager.GetActiveScene();
        PauseMenu = GameObject.FindWithTag("PauseMenu");
        Unpause();
        MainMenuScene= "Resources/Scenes/MainMenu";

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
            
    }

    public void PauseUnpause()
    {
        Paused = !Paused;
        Time.timeScale = (Paused) ? 0.00f : 1.00f;
        PauseMenu.SetActive(Paused);
    }

    public void RestartScene() { 
        SceneManager.LoadScene(loadedLevel.buildIndex);
        Unpause();
    }

    void Unpause()
    {
        PauseMenu.SetActive(false);
        Paused = false;
        Time.timeScale=1.00f;
    }

    public void ExitGame()
    {
        Debug.Log("Exiting...");
        SceneManager.LoadScene(MainMenuScene);
    }
}
