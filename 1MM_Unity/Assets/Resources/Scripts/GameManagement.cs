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
        
	}
	

	void Update () 
    {   

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
