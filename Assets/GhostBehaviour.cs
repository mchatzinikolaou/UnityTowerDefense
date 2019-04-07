using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    //It can be built in the present location.
    bool ConstructionAvailable;
    //The turret that will replace this ghost.
    public GameObject ReplacementTurret;

    public Material AvailableColour,UnavailableColour;
    Material CurrentColour;

    //When the ghost is spawned, Subtract the cost from the player's available gold.
    void Start()
    {
        ConstructionAvailable=false;
    }

    //Destroy the ghost and give the player the money back.
    void CancelBuild()
    {
        GameManagement PlayerEconomy = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
        PlayerEconomy.PlayerGold += ReplacementTurret.GetComponent<Tower_Economy>().TowerCost;
        Destroy(this.gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Delete) || Input.GetMouseButtonDown(1))
        {
            CancelBuild();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Build();
        }

        FollowCursor();

    }

    void LateUpdate()
    {
        UpdateColour();
    }

    //Updates the ghost's colour accordingly.
    void UpdateColour()
    {
            GetComponent<Renderer>().material= ConstructionAvailable? AvailableColour : UnavailableColour;
    }

    void CanBuild(RaycastHit hit)
    {
        ConstructionAvailable = hit.transform.gameObject.CompareTag("Terrain") ?  true :  false;
        
    }

    void FollowCursor()
    {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            { 
                    transform.position = SnapToSurface(hit);
                    CanBuild(hit);
            }
            
    }

    //Make the turret show over the terrain and not trees etc.
    Vector3 SnapToSurface(RaycastHit hit)
    {
        return new Vector3(hit.point.x, 0, hit.point.z);
    }

    //Rotate around the y axis with middle button scroll.
    void Rotate()
    {
       
    }

    void Build()
    {
            if(ConstructionAvailable) { 
                Instantiate(ReplacementTurret,transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
    }

    public void Spawn()
    {

        GameManagement PlayerEconomy = GameObject.FindWithTag("GameController").GetComponent<GameManagement>();
        int Cost= ReplacementTurret.GetComponent<Tower_Economy>().TowerCost;

        if (Cost > PlayerEconomy.PlayerGold) {
            Debug.Log("Not enough money!");
            return;
        }



        PlayerEconomy.PlayerGold -= Cost;
        Instantiate(this, transform.position, transform.rotation).gameObject.SetActive(true);

    }
}
