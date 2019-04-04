using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

    int PlayerHP;
    public int PlayerGold;
    int GoldOverTime;
    Object[] PossibleTurrets;
    public Text goldText , DamageTakenText;
    public static int GameSpeed;


    // Use this for initialization
    void Start () {
        LoadAndSetAvailableTurrets();

        PlayerHP=100;
        GameSpeed =1;
        PlayerGold=0;
        GoldOverTime=1;
        StartCoroutine("GiveGoldOverTime");
        ModifyDamageText();
    }
	
    //Locate all building tiles in the game and pass the Turrets
    //as possible prefabs to be loaded.
    void LoadAndSetAvailableTurrets()
    {
        PossibleTurrets=Resources.LoadAll("Prefabs/Buildings");
        GameObject[] BuildingBases = GameObject.FindGameObjectsWithTag("BuildingBase");
        foreach(GameObject Base in BuildingBases){
            Base.GetComponent<buildControls>().SetAvailableTurrets(PossibleTurrets);
        }
    }

    IEnumerator GiveGoldOverTime()
    {
        //if( round is running)...
        while (true) { 
            PlayerGold+=GoldOverTime;
            yield return new WaitForSeconds(1.5f);
        }
    }


	// Update is called once per frame
	void Update () {
		PrintGold();
	}
    
    
    void PrintGold()
    {
        goldText.text=PlayerGold.ToString();
    }

    public void gainGold(int amount)
    {
        PlayerGold+=amount;
    }

    bool spendGold(int amount)
    {
        if (PlayerGold - amount < 0)
        {
            //Print this to ui.
            Debug.Log("not enough gold!");
            return false;
        }
        else { 
            PlayerGold-=amount;
            return true;
        }
    }

    void setGameSpeed(int times)
    {
        GameSpeed=times;
    }

  

    //When the creep reaches the base, it takes damage.
    public void PlayerModifyDamage(GameObject Creep)
    {
        PlayerHP -= Creep.GetComponent<CreepControls>().getDamage();
        ModifyDamageText();
    }

    public void ModifyDamageText()
    {
        DamageTakenText.text= PlayerHP.ToString();
    }
    
}

