using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {

    int PlayerHP;
    int PlayerGold;
    int GoldOverTime;

    public Text goldText , DamageTakenText;

    public static int GameSpeed;

    // Use this for initialization
    void Start () {
        PlayerHP=100;
        GameSpeed =1;
        PlayerGold=0;
        GoldOverTime=1;
        StartCoroutine("GiveGoldOverTime");
        ModifyDamageText();
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
    void gainGold(int amount)
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

    //This will be used to gain gold, check if there are no more creeps alive etc.
    void OnCreepDeath(GameObject Creep)
    {
        PlayerGold+=Creep.GetComponent<CreepControls>().goldDrop;
        
        
        
        
        //Play a little gold sound maybe.
        
        
        
        
        //Check if there are creeps in the stage. Then , if !finalWave end stage, else spawn new wave.





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
