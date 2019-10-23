using UnityEngine;
using UnityEngine.UI;
public class NukeEMUP : MonoBehaviour {

    string code;
	public GameObject Nuke;
    public GameObject InputField;
    InputField InputText;


    void Start()
    {
        InputText = InputField.GetComponent<InputField>();
    }

	public void Nukethe_s_outofthem()
    {
        code = InputText.text;
        Debug.Log(code);
        if (code.Equals("daffy")|| code.Equals("Daffy"))
        {
            if(Nuke!=null)
                Instantiate(Nuke).SetActive(true);
                
        }
        code=null;
    }
    
}
