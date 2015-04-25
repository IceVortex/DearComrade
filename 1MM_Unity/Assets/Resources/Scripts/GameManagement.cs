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
        Debug.Log("Current Approval: " + GameResources.instance.approval);
        Debug.Log("Current Food: " + GameResources.instance.food);
        Debug.Log("Current Materials: " + GameResources.instance.buildingMaterials);
        Debug.Log("Current Money: " + GameResources.instance.money);
        Debug.Log("Current Citizens: " + GameResources.instance.citizens + " / " + GameResources.instance.maximumCitizens);
	}


    public void nextTurn()
    {

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

        Debug.Log("====================================================");
        Debug.Log("Current Approval: " + GameResources.instance.approval);
        Debug.Log("Food Gained: " + LoggingSystem.Instance.foodGained);
        Debug.Log("Materials Gained: " + LoggingSystem.Instance.materialsGained);
        Debug.Log("Money Gained: " + LoggingSystem.Instance.moneyGained);
        Debug.Log("Base Approval Lost: " + LoggingSystem.Instance.baseApprovalLost);
        Debug.Log("Citizens Gained: " + LoggingSystem.Instance.citizensGained);
    }

}
