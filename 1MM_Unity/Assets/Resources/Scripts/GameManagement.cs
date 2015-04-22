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

        if (GameResources.instance.canBuy<House>())
            GameResources.instance.createBuilding<House>(prefab, new Vector3(4, 4, 0));
        else
            Debug.Log("can't buy");

        
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
