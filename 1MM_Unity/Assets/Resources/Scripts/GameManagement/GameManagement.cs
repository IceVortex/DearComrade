using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab, foodTerritoryPrefab, materialsTerritoryPrefab, citizensTerritoryPrefab;
    private GameObject obj;
    public testBuildingGeneration gen;
    public loggingFrontend loggingFrontEnd;
    public date d;
    private int randNr;

    void Awake()
    {
        GameResources.instance.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/Buildings/Executive Building"), new Vector3(0, 0, 0));
        gen.hub = GameObject.FindGameObjectWithTag("Executive");
    }

	void Start () 
    {

    }

    void Update()
    {
        if (GameResources.instance.approval >= 100f && GameResources.instance.troops >= 3000)
            Debug.Log("Win");
        if (GameResources.instance.approval <= -100)
            Debug.Log("Lose");
    }

    public void nextTurn()
    {
        LoggingSystem.Instance.reset();
        GetComponent<Test>().getRandomEvent();
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

        if (GetComponent<Test>().thisEvent.type == "stalemate" && GetComponent<Test>().thisEvent.resource == "food")
        {
            GameResources.instance.food -= LoggingSystem.Instance.foodGained;
            LoggingSystem.Instance.foodGained = 0;
        }

        if (GetComponent<Test>().thisEvent.type == "stalemate" && GetComponent<Test>().thisEvent.resource == "all")
        {
            GameResources.instance.food -= LoggingSystem.Instance.foodGained;
            GameResources.instance.buildingMaterials -= LoggingSystem.Instance.materialsGained;
            GameResources.instance.money -= LoggingSystem.Instance.moneyGained;
            LoggingSystem.Instance.foodGained = 0;
            LoggingSystem.Instance.materialsGained = 0;
            LoggingSystem.Instance.moneyGained = 0;
        }

        if (GetComponent<Test>().thisEvent.type == "halved")
        {
            GameResources.instance.food -= LoggingSystem.Instance.foodGained/2;
            LoggingSystem.Instance.foodGained = LoggingSystem.Instance.foodGained/2;
        }

        loggingFrontEnd.updateValues();

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
                GameResources.instance.createBuilding<FoodTerritory>(foodTerritoryPrefab, gen.generate());
            else if (randNr <= 66)
                GameResources.instance.createBuilding<MaterialsTerritory>(materialsTerritoryPrefab, gen.generate());
            else if (randNr <= 100)
                GameResources.instance.createBuilding<CitizensTerritory>(citizensTerritoryPrefab, gen.generate());
        }
    }

}
