using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaveLogic : MonoBehaviour {

    int WaveCountdown;
    int Timer;
    public Text TimerText;
    public int TotalWaves;
    GameObject[] SpawnPoints;
    int currentWave;

    

    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
        WaveCountdown=15;
        TotalWaves=3;
        Timer = WaveCountdown;
        StartCoroutine("Countdown");
    }
    
    void LateUpdate()
    {
        if (CheckWaveClear()){
            SkipWave();
        }
        TimerText.text=Timer.ToString();
    }


    //Count down to 0 and reset .
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
        currentWave++;
        if (currentWave == TotalWaves)
        {
            Debug.Log("No more waves to spawn");
            TimerText.text="";
            this.gameObject.SetActive(false);
        }
        else
        {
            //Fetch next wave
            //For each creep in the wave , spawn it at each spawner. (here is spawning logic).
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

    void ResetTimer()
    {
        Timer=WaveCountdown;
    }
}
