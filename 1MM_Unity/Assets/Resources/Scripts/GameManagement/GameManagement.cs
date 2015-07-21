using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab, foodTerritoryPrefab, materialsTerritoryPrefab, citizensTerritoryPrefab;
    private GameObject obj;
    public BuildingGeneration gen;
    public loggingFrontend loggingFrontEnd;
    public date d;

    public fadeToEndScreen lose, win;

    private int randNr;

    void Awake()
    {
        GameResources.instance.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/Buildings/Executive Building"), new Vector3(0, 0, 0));
        gen.hub = GameObject.FindGameObjectWithTag("Executive");
    }

    void Update()
    {
        if (GameResources.instance.approval >= 100f && GameResources.instance.troops >= 3000 && !win.fadeTo1)
        {
            win.startFadeTo1();

        }
        if (GameResources.instance.approval <= -100 && !lose.fadeTo1)
        {
            lose.startFadeTo1();
        }
    }

    public void nextTurn()
    {
        LoggingSystem.Instance.reset();
        GetComponent<eventsRead>().getRandomEvent();
        d.updateDate();
        GameResources.instance.turnIndex++;

        foreach (ABuilding building in GameResources.instance.buildings)
        {
            building.Effect();
        }

        foreach(var entry in GameResources.instance.links)
        {
            GameResources.instance.linkEffectTurn(entry.Key, entry.Value);
        }

        if (GetComponent<eventsRead>().thisEvent.type == "stalemate" && GetComponent<eventsRead>().thisEvent.resource == "food")
        {
            GameResources.instance.food -= LoggingSystem.Instance.foodGained;
            LoggingSystem.Instance.foodGained = 0;
        }

        if (GetComponent<eventsRead>().thisEvent.type == "stalemate" && GetComponent<eventsRead>().thisEvent.resource == "all")
        {
            GameResources.instance.food -= LoggingSystem.Instance.foodGained;
            GameResources.instance.buildingMaterials -= LoggingSystem.Instance.materialsGained;
            GameResources.instance.money -= LoggingSystem.Instance.moneyGained;
            LoggingSystem.Instance.foodGained = 0;
            LoggingSystem.Instance.materialsGained = 0;
            LoggingSystem.Instance.moneyGained = 0;
        }

        if (GetComponent<eventsRead>().thisEvent.type == "halved")
        {
            GameResources.instance.food -= LoggingSystem.Instance.foodGained/2;
            LoggingSystem.Instance.foodGained = LoggingSystem.Instance.foodGained/2;
        }

        

        if (GameResources.instance.food < 0)
            GameResources.instance.food = 0;

        if (GameResources.instance.money < 0)
            GameResources.instance.money = 0;

        if (GameResources.instance.buildingMaterials < 0)
            GameResources.instance.buildingMaterials = 0;

        if (GameResources.instance.citizens < 0)
            GameResources.instance.citizens = 0;

        if((int)Random.Range(0f,101f) < GameResources.instance.territoryConquerRate)
        {
            randNr = (int)Random.Range(0, 101);
            if (randNr <= 33)
            {
                GameResources.instance.createBuilding<FoodTerritory>(foodTerritoryPrefab, gen.generate());
                LoggingSystem.Instance.territoryRecieved = 1;
            }
            else if (randNr <= 66)
            {
                GameResources.instance.createBuilding<MaterialsTerritory>(materialsTerritoryPrefab, gen.generate());
                LoggingSystem.Instance.territoryRecieved = 2;
            }
            else if (randNr <= 100)
            {
                GameResources.instance.createBuilding<CitizensTerritory>(citizensTerritoryPrefab, gen.generate());
                LoggingSystem.Instance.territoryRecieved = 3;
            }
        }


        loggingFrontEnd.updateValues();

    }

}
