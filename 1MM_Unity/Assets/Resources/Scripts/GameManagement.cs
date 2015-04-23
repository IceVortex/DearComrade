using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab;
    private GameObject obj;
    public testBuildingGeneration gen;

    void Awake()
    {
        GameResources.instance.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/Buildings/Executive Building"), new Vector3(0, 0, 0));
        gen.hub = GameObject.FindGameObjectWithTag("Executive");
    }

	void Start () 
    {
        //GameResources.instance.createBuilding<House>((GameObject)Resources.Load("Prefabs/Buildings/House"), gen.generate());
        //GameResources.instance.createBuilding<Farm>((GameObject)Resources.Load("Prefabs/Buildings/Farm"), gen.generate());
        //GameResources.instance.createBuilding<Factory>((GameObject)Resources.Load("Prefabs/Buildings/Factory"), gen.generate());

        //GameResources.instance.linkBuildings(1, 2);
	}



    public void nextTurn()
    {
        GameResources.instance.turnIndex++;
        foreach (ABuilding building in GameResources.instance.buildings)
        {
            building.Effect();
        }

        foreach(var entry in GameResources.instance.links)
        {
            GameResources.instance.linkEffectTurn(entry.Key, entry.Value);
        }


    }

}
