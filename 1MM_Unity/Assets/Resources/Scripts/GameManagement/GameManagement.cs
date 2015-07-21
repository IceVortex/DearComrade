using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab, foodTerritoryPrefab, materialsTerritoryPrefab, citizensTerritoryPrefab;
    private GameObject obj;
    public AIManagement ai;
    public BuildingGeneration gen;
    public loggingFrontend loggingFrontEnd;
    public date d;
    public AResources res;
    public statistics stats;

    public fadeToEndScreen lose, win;

    private int randNr;

    void Awake()
    {
        res.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/Buildings/Executive Building"), new Vector3(0, 0, 0));
        gen.hub = GameObject.FindGameObjectWithTag("Executive");
    }

    void Update()
    {
        if (res.approval >= 100f && res.troops >= 3000 && !win.fadeTo1)
        {
            win.startFadeTo1();

        }
        if (res.approval <= -100 && !lose.fadeTo1)
        {
            lose.startFadeTo1();
        }
    }

    public void nextTurn()
    {
        LoggingSystem.Instance.reset();
        GetComponent<eventsRead>().getRandomEvent();
        d.updateDate();
        res.turnIndex++;

        ai.nextTurn();

        foreach (ABuilding building in res.buildings)
        {
            building.Effect();
        }

        foreach(var entry in res.links)
        {
            res.linkEffectTurn(entry.Key, entry.Value);
        }

        GetComponent<eventsRead>().eventEffect();

        if (res.food < 0)
            res.food = 0;

        if (res.money < 0)
            res.money = 0;

        if (res.buildingMaterials < 0)
            res.buildingMaterials = 0;

        if (res.citizens < 0)
            res.citizens = 0;

        if((int)Random.Range(0f,101f) < res.territoryConquerRate)
        {
            randNr = (int)Random.Range(0, 101);
            if (randNr <= 33)
            {
                res.createBuilding<FoodTerritory>(foodTerritoryPrefab, gen.generate());
                LoggingSystem.Instance.territoryRecieved = 1;
            }
            else if (randNr <= 66)
            {
                res.createBuilding<MaterialsTerritory>(materialsTerritoryPrefab, gen.generate());
                LoggingSystem.Instance.territoryRecieved = 2;
            }
            else if (randNr <= 100)
            {
                res.createBuilding<CitizensTerritory>(citizensTerritoryPrefab, gen.generate());
                LoggingSystem.Instance.territoryRecieved = 3;
            }
        }


        loggingFrontEnd.updateValues();
        stats.updateStatistics();
    }

}
