using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameResources : MonoBehaviour 
{
    //Here is a private reference only this class can access
    private static GameResources _instance;

    //Main Resources
    public float food, money, buildingMaterials, approval, citizens, maximumCitizens;

    //Maximum number of homeless citizens you can have.
    public float maxHomelessCitizens = 200;

    //Number of resources gained per turn or at initialization for farm, house and factories.
    public float farmFoodT = 10, houseCitizensT = 300, factoryMaterialsT = 10;

    //Rates of building cost and buy/sell rate.
    public float buildingCostRate = 100, buyRate = 100, sellRate = 50;

    //Rate of triggered event cost.
    public float triggeredEventCostRate = 100;

    //Approval gained from publich speech and festival.
    public float publichSpeechApproval = 2, festivalApproval = 3;

    //Approval gained from trading food at exec. building
    public float foodRatioApproval = 0.01f;


    //The list of buildings, links and the index
    public List<ABuilding> buildings = new List<ABuilding>();
    public Dictionary<int, int> links = new Dictionary<int, int>();
    public int currentIndex = 0;

    public GameObject obj;
 
    //This is the public reference that other classes will use
    public static GameResources instance
    {
        get
        {
            //If _instance hasn't been set yet, we grab it from the scene!
            //This will only happen the first time this reference is used.
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameResources>();
            return _instance;
        }
    }

    public bool canBuy<building>() where building : ABuilding, new()
    {
        building x = new building();
        if (GameResources.instance.food >= x.foodCost * (GameResources.instance.buildingCostRate / 100) &&
            GameResources.instance.money >= x.moneyCost * (GameResources.instance.buildingCostRate / 100) &&
            GameResources.instance.buildingMaterials >= x.buildingMaterialsCost * (GameResources.instance.buildingCostRate / 100))
            return true;
        else
            return false;
    }

    public void createBuilding<building>(GameObject buildingPrefab, Vector3 position) where building : ABuilding, new()
    {
        buildings.Add(new building());
        buildings[currentIndex].Initialize(currentIndex);
        obj = (GameObject)GameObject.Instantiate(buildingPrefab, position, Quaternion.identity);
        obj.name = buildings[currentIndex].name;
        obj.GetComponent<IdManager>().buildingIndex = currentIndex;
        currentIndex++;

    }

    public Vector3 cost<building>() where building : ABuilding, new()
    {
        Vector3 cost;
        building x = new building();
        cost.x = x.foodCost;
        cost.y = x.buildingMaterialsCost;
        cost.z = x.moneyCost;
        return cost;
    }

    public void linkBuildings(int indexStart, int indexDestination)
    {
        GameResources.instance.buildings[indexStart].comradeIndex = GameResources.instance.buildings[indexDestination].listIndex;
        links.Add(indexStart, indexDestination);
    }

    public bool isLinkable(int index)
    {
        //To do
        return false;
    }

    public bool canLink(int indexStart, int indexDestination)
    {
        //To Do
        return false;
    }

    public void linkEffect(int indexStart, int indexDestination)
    {
        if (GameResources.instance.buildings[indexStart].GetType().ToString() == "House" &&
            GameResources.instance.buildings[indexDestination].GetType().ToString() == "Farm")
            GameResources.instance.food += 5;
    }
}
