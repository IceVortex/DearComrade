using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab;
    private GameObject obj;
    public testBuildingGeneration gen;
    public loggingFrontend loggingFrontEnd;
    public date d;

    void Awake()
    {
        GameResources.instance.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/Buildings/Executive Building"), new Vector3(0, 0, 0));
        gen.hub = GameObject.FindGameObjectWithTag("Executive");
    }

	void Start () 
    {
        Debug.Log("Current Approval: " + GameResources.instance.approval);
        Debug.Log("Current Food: " + GameResources.instance.food);
        Debug.Log("Current Materials: " + GameResources.instance.buildingMaterials);
        Debug.Log("Current Money: " + GameResources.instance.money);
        Debug.Log("Current Citizens: " + GameResources.instance.citizens + " / " + GameResources.instance.maximumCitizens);
    }

    void Update()
    {
        if (GameResources.instance.approval >= 100f)
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
    }

}
