using UnityEngine;
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
            turnIndex++;
            foreach(ABuilding building in buildings)
            {
                building.Effect();
            }
            Debug.Log(turnIndex);
        }
	}
}
