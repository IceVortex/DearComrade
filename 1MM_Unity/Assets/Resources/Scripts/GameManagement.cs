using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManagement : MonoBehaviour {
    
    public GameObject prefab;
    private GameObject obj;
    public testBuildingGeneration gen;
    public loggingFrontend loggingFrontEnd;

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


    public void nextTurn()
    {
        GetComponent<Test>().getRandomEvent();
        LoggingSystem.Instance.reset();
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

        Debug.Log("====================================================");
        Debug.Log("Current Approval: " + GameResources.instance.approval);
        Debug.Log("Food Gained: " + LoggingSystem.Instance.foodGained);
        Debug.Log("Materials Gained: " + LoggingSystem.Instance.materialsGained);
        Debug.Log("Money Gained: " + LoggingSystem.Instance.moneyGained);
        Debug.Log("Base Approval Lost: " + LoggingSystem.Instance.baseApprovalLost);
        Debug.Log("Citizens Gained: " + LoggingSystem.Instance.citizensGained);
    }

}
