﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {

    public int turnIndex = 0;
    public List<ABuilding> buildings = new List<ABuilding>();


	void Start () 
    {
        buildings.Add(new ExecutiveBuilding());
        ((ExecutiveBuilding)buildings[0]).buyFestival();
        
	}
	

	void Update () 
    {   
        if (Input.GetKeyDown(KeyBindingManager.Instance.endTurn))
        {
            nextTurn();
            turnIndex++;
            foreach(ABuilding building in buildings)
            {
                building.Effect();
            }
            Debug.Log(turnIndex);
        }
	}

    public void nextTurn()
    {
        turnIndex++;
        foreach (ABuilding building in buildings)
        {
            building.Effect();
        }
        Debug.Log(turnIndex);
        Debug.Log(GameResources.instance.food + " " + GameResources.instance.money + " " + GameResources.instance.buildingMaterials);


    }

}
