using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {

    public int turnIndex = 0;
    public List<ABuilding> buildings = new List<ABuilding>();


	void Start () 
    {
        buildings.Add(new ExecutiveBuilding());
        buildings[0].Initialize();
        buildings.Add(new Farm());
        buildings[1].Initialize();
        buildings.Add(new Laboratory());
        buildings[2].Initialize();
        
	}
	

	void Update () 
    {   
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ((Laboratory)buildings[2]).researchFertility();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            buildings.Add(new Farm());
            buildings[3].Initialize();
        }
	}

    public void nextTurn()
    {
        turnIndex++;
        foreach (ABuilding building in buildings)
        {
            building.Effect();
        }


    }

}
