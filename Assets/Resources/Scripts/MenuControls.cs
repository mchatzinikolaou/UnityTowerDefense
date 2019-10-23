
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControls : MonoBehaviour {

    string FirstStage;
    // Use this for initialization
    void Start () {
		FirstStage="Resources/Scenes/SampleScene/SampleScene";
	}


    public void StartFirstScene()
    {
        SceneManager.LoadScene(FirstStage);
    }

    public void ExitToDesktop()
    {
        Application.Quit();
    }
}
