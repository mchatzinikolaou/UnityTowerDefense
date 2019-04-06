using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDamage : MonoBehaviour {

    GameManagement gameManager;

    void Start()
    {
        gameManager= GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
    }
	
	
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameManager.PlayerModifyDamage(other.gameObject);

            Destroy(other.gameObject);
        }
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy"))
    //    {
           //Calculate damage
    //        Destroy(other.gameObject);
    //    }
    //}

    
}
