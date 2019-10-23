using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class WaveLogic : MonoBehaviour {

    public int WaveCountdown;
    int Timer;
    public Text TimerText;
    public int TotalWaves;
    GameObject[] SpawnPoints;
    int CurrentWave;
    GameObject[] CreepPool;
    public GameObject SkipButton;
    GameObject GameManager;


    /*
     * This function takes a target difficulty and calculates how many
     * creeps can "fit" in it.
     * 
     * It works by having the Creep description as an argument,
     * sorted by descending difficulty. Then it simply a knapsack problem.
     */

    void GenerateNextWave()
    {
        int TargetDifficulty=CalculateWaveDifficulty();

        int currentDifficulty=0;
        GameObject nextCreep;
        
            //While the hardest creep so far fits in the wave...
            while(currentDifficulty < TargetDifficulty)
            {
                nextCreep=CreepPool[(int) Random.Range(0.0f,CreepPool.Length)];
                //Spawn the creep
                foreach (GameObject Spawner in SpawnPoints)
                {
                    Spawner.GetComponent<Spawner>().spawnCreep(nextCreep);
                }
                //Add it's difficulty to the wave.
                currentDifficulty += nextCreep.GetComponent<CreepControls>().Strength;
            }
        
    }

    //Return the target difficulty of the wave.
    int CalculateWaveDifficulty()
    {
        return CurrentWave * 3;
    }

    void LoadCreeps()
    {
        Object[] LoadedAgents = Resources.LoadAll("Prefabs/Agents");
        Debug.Log(LoadedAgents.Length);
        List<GameObject> Enemies= new List<GameObject>();;
        foreach(GameObject enemy in LoadedAgents)
        {
            if (enemy.tag == "Enemy")
            {
                Debug.Log(enemy + enemy.tag);
                Enemies.Add(enemy);
            }
        }
        CreepPool =Enemies.ToArray();
        Debug.Log("Total different enemies: "+CreepPool.Length);
    }
    

    void Start()
    {
        GameManager=GameObject.FindWithTag("GameController");
        LoadCreeps();
        SpawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        Timer = WaveCountdown;
        StartCoroutine("Countdown");
    }
    
    void LateUpdate()
    {
        
        //Whenever the wave is cleared, spawn the next one.
        if (CheckWaveClear()){
            if(isLastWave()){
                EndGame();
            }
            else { 
                SkipWave();
            }
        }

        TimerGUI_Handler();
    }

    void TimerGUI_Handler()
    {
        if(CurrentWave < TotalWaves) { 
            TimerText.text = Timer.ToString();
        }
        else
        {
            TimerText.text="";
        }
    }
    
    //Count down to 0 and reset.
    IEnumerator Countdown()
    {
        Timer--;
        Debug.Log("Timer is " + Timer);
        if (Timer == 0)
        {
            SpawnNextWave();
            ResetTimer();
        }
        yield return  new WaitForSeconds(1.0f);
        StartCoroutine("Countdown");
    }

    //Fetch next wave description and send it to the spawners to be spawned.
    void SpawnNextWave()
    {
        CurrentWave++;
        if (isLastWave())
        {
            Debug.Log("No more waves to spawn");
            TimerText.text="";
            //Here print endgame info.
            SkipButton.SetActive(false);
            this.gameObject.SetActive(false);
        }
        else
        {
            GenerateNextWave();
        }
    }

    bool CheckWaveClear()
    {
        return GameObject.FindGameObjectsWithTag("Enemy").Length==0 ? true :false;
    }

    public void SkipWave()
    {
        ResetTimer();
        SpawnNextWave();
    }

    void EndGame()
    {
        Time.timeScale=0.0f;
        Debug.Log("Game ended");
        Destroy(this);
    }


    void ResetTimer()
    {
        Timer=WaveCountdown;
    }

    public bool isLastWave()
    {
        return CurrentWave==TotalWaves-1 ? true:false;
    }
}
