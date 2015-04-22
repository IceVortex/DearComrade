using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {

    public int turnIndex = 0;
    
    public GameObject prefab;
    private GameObject obj;


	void Start () 
    {

        GameResources.instance.createBuilding<ExecutiveBuilding>(prefab, new Vector3(2, 2, 0));

        Debug.Log(GameResources.instance.cost<House>());

        
	}


	void Update () 
    {   
	}

    public void nextTurn()
    {
        turnIndex++;
        foreach (ABuilding building in GameResources.instance.buildings)
        {
            building.Effect();
        }


    }

}
