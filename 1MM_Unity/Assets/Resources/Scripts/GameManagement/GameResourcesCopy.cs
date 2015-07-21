/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameResourcesC : AResources 
{
    //Here is a private reference only this class can access
    private static GameResources _instance;

    //Main Resources
    public float food, money, buildingMaterials;
    public float approval;
    public float citizens, maximumCitizens;
    public float troops, maximumTroops;
    public float researchPoints;

    //Tax Rate
    public float taxRate = 100;

    //Maximum number of homeless citizens you can have.
    public float maxHomelessCitizens = 200;

    //Number of resources gained per turn or at initialization for farm, house and factories.
    public float farmFoodT = 10, houseCitizensT = 300, factoryMaterialsT = 10;

    //Rates of building cost, buy/sell rate, gold gain and approval decay.
    public float buildingCostRate = 100, buyRate = 100, sellRate = 50;
    public float approvalDecayRate = 100, goldPerTurn = 0.01f;
    public float flatApproval = 1f;
    public float territoryConquerRate = 0f;

    //Rate of triggered event cost.
    public float triggeredEventCostRate = 100;

    //Approval gained from publich speech and festival.
    public float publichSpeechApproval = 25, festivalApproval = 25;

    //Approval gained from trading food at exec. building
    public float foodRatioApproval = 0.1f;

    //The current turn index
    public int turnIndex = 0;


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
        //buildings[currentIndex].Initialize(currentIndex, resource);
        obj = (GameObject)GameObject.Instantiate(buildingPrefab, position, Quaternion.identity);
        obj.name = buildings[currentIndex].name;
        obj.GetComponent<IdManager>().buildingIndex = currentIndex;
        currentIndex++;

    }

    public Vector3 cost<building>() where building : ABuilding, new()
    {
        Vector3 cost;
        building x = new building();
        cost.x = x.foodCost * (GameResources.instance.buildingCostRate / 100);
        cost.y = x.buildingMaterialsCost * (GameResources.instance.buildingCostRate / 100);
        cost.z = x.moneyCost * (GameResources.instance.buildingCostRate / 100);
        return cost;
    }

    public void linkBuildings(int indexStart, int indexDestination)
    {
        GameResources.instance.buildings[indexStart].comradeIndex = GameResources.instance.buildings[indexDestination].listIndex;
        links.Add(indexStart, indexDestination);
        linkInitialize(indexStart, indexDestination);
    }

    public bool isLinkable(int index)
    {
        if (GameResources.instance.buildings[index].comradeIndex != 0)
            return false;
        else
            return true;
    }

    public bool canLink(int indexStart, int indexDestination)
    {
        string typeStart = GameResources.instance.buildings[indexStart].GetType().ToString();
        string typeDestination = GameResources.instance.buildings[indexDestination].GetType().ToString();
        
        if (typeStart == "House" && typeDestination == "House" && indexStart != indexDestination)
            return true;
        else if (typeStart == "House" && typeDestination == "WTC")
            return true;
        else if (typeStart == "Farm" && typeDestination == "WTC")
            return true;
        else if (typeStart == "House" && typeDestination == "Hospital")
            return true;
        else if (typeStart == "House" && typeDestination == "EducationalBuilding")
            return true;
        else if (typeStart == "House" && typeDestination == "PoliceStation")
            return true;
        else if (typeStart == "House" && typeDestination == "Workplace")
            return true;
        else if (typeStart == "House" && typeDestination == "PublicSpace")
            return true;
        else if (typeStart == "House" && typeDestination == "MilitaryOutpost")
            return true;
        else if ((typeStart == "House" && typeDestination == "Farm") ||
            (typeStart == "Farm" && typeDestination == "House"))
            return true;
        else if ((typeStart == "House" && typeDestination == "Factory") ||
            (typeStart == "Factory" && typeDestination == "House"))
            return true;
        else
            return false;
    }

    public void linkInitialize(int indexStart, int indexDestination)
    {
        string typeStart = GameResources.instance.buildings[indexStart].GetType().ToString();
        string typeDestination = GameResources.instance.buildings[indexDestination].GetType().ToString();

        if (typeStart == "House" && typeDestination == "House")
            GameResources.instance.maximumCitizens += 150;
        else if (typeStart == "House" && typeDestination == "WTC")
            GameResources.instance.sellRate += 2;
        else if (typeStart == "Farm" && typeDestination == "WTC")
            GameResources.instance.buyRate += 2;
        else if (typeStart == "House" && typeDestination == "Hospital")
            GameResources.instance.maxHomelessCitizens += 50;
        else if (typeStart == "House" && typeDestination == "EducationalBuilding")
            GameResources.instance.buildingCostRate -= 2;
        else if (typeStart == "House" && typeDestination == "PoliceStation")
            GameResources.instance.approvalDecayRate -= 1;
        else if (typeStart == "House" && typeDestination == "Workplace")
            GameResources.instance.goldPerTurn += 0.001f;
        else if (typeStart == "House" && typeDestination == "PublicSpace")
            GameResources.instance.approval += 0.5f;
        else if (typeStart == "House" && typeDestination == "MilitaryOutpost")
            {
                GameResources.instance.maximumCitizens -= houseCitizensT;
                GameResources.instance.maximumTroops += houseCitizensT;
                GameResources.instance.territoryConquerRate += 8;

                if (GameResources.instance.citizens >= houseCitizensT)
                {
                    GameResources.instance.citizens -= houseCitizensT;
                    GameResources.instance.troops += houseCitizensT;
                }
                else
                {
                    GameResources.instance.troops += GameResources.instance.citizens;
                    GameResources.instance.citizens = 0;
                }
            }
    }

    public void linkEffectTurn(int indexStart, int indexDestination)
    {
        string typeStart = GameResources.instance.buildings[indexStart].GetType().ToString();
        string typeDestination = GameResources.instance.buildings[indexDestination].GetType().ToString();

        if ((typeStart == "House" && typeDestination == "Farm") ||
            (typeStart == "Farm" && typeDestination == "House"))
        { 
            GameResources.instance.food += 5;
            LoggingSystem.Instance.foodGained += 5;
        }
        if ((typeStart == "House" && typeDestination == "Factory") ||
            (typeStart == "Factory" && typeDestination == "House"))
        { 
            GameResources.instance.buildingMaterials += 5;
            LoggingSystem.Instance.materialsGained += 5;
        }
    }

    public bool buildingConsutructedCheck(string building)
    {
        foreach (ABuilding b in buildings)
        {
            if (b.name == building)
                return true;
        }
        return false;
    }

}
*/