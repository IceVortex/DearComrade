using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AResources : MonoBehaviour 
{

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

    //Variables used for statistics
    public int researchesMade;

    //The list of buildings, links and the index
    public List<ABuilding> buildings = new List<ABuilding>();
    public Dictionary<int, int> links = new Dictionary<int, int>();
    public int currentIndex = 0;

    private GameObject obj;

    public bool canBuy<building>() where building : ABuilding, new()
    {
        building x = new building();
        if (food >= x.foodCost * (buildingCostRate / 100) &&
            money >= x.moneyCost * (buildingCostRate / 100) &&
            buildingMaterials >= x.buildingMaterialsCost * (buildingCostRate / 100))
            return true;
        else
            return false;
    }

    public void createBuilding<building>(GameObject buildingPrefab, Vector3 position) where building : ABuilding, new()
    {
        //Adding the buildings to the list
        buildings.Add(new building());
        buildings[currentIndex].Initialize(currentIndex, this);

        //Creating the game object in the scene, for the visual representation
        obj = (GameObject)GameObject.Instantiate(buildingPrefab, position, Quaternion.identity);
        obj.name = buildings[currentIndex].name;
        obj.GetComponent<IdManager>().buildingIndex = currentIndex;
<<<<<<< HEAD
        obj.GetComponent<IdManager>().res = this;
=======

>>>>>>> ec989fa3015c1464b4c4233a8463427e115437ed
        currentIndex++;
    }

    public Vector3 cost<building>() where building : ABuilding, new()
    {
        Vector3 cost;
        building x = new building();
        cost.x = x.foodCost * (buildingCostRate / 100);
        cost.y = x.buildingMaterialsCost * (buildingCostRate / 100);
        cost.z = x.moneyCost * (buildingCostRate / 100);
        return cost;
    }

    public void linkBuildings(int indexStart, int indexDestination)
    {
        buildings[indexStart].comradeIndex = buildings[indexDestination].listIndex;
        links.Add(indexStart, indexDestination);
        linkInitialize(indexStart, indexDestination);
    }

    public bool isLinkable(int index)
    {
        if (buildings[index].comradeIndex != 0)
            return false;
        else
            return true;
    }

    public bool canLink(int indexStart, int indexDestination)
    {
        string typeStart = buildings[indexStart].GetType().ToString();
        string typeDestination = buildings[indexDestination].GetType().ToString();
        
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
        string typeStart = buildings[indexStart].GetType().ToString();
        string typeDestination = buildings[indexDestination].GetType().ToString();

        if (typeStart == "House" && typeDestination == "House")
            maximumCitizens += 150;
        else if (typeStart == "House" && typeDestination == "WTC")
            sellRate += 2;
        else if (typeStart == "Farm" && typeDestination == "WTC")
            buyRate += 2;
        else if (typeStart == "House" && typeDestination == "Hospital")
            maxHomelessCitizens += 50;
        else if (typeStart == "House" && typeDestination == "EducationalBuilding")
            buildingCostRate -= 2;
        else if (typeStart == "House" && typeDestination == "PoliceStation")
            approvalDecayRate -= 1;
        else if (typeStart == "House" && typeDestination == "Workplace")
            goldPerTurn += 0.001f;
        else if (typeStart == "House" && typeDestination == "PublicSpace")
            approval += 0.5f;
        else if (typeStart == "House" && typeDestination == "MilitaryOutpost")
            {
                maximumCitizens -= houseCitizensT;
                maximumTroops += houseCitizensT;
                territoryConquerRate += 8;

                if (citizens >= houseCitizensT)
                {
                    citizens -= houseCitizensT;
                    troops += houseCitizensT;
                }
                else
                {
                    troops += citizens;
                    citizens = 0;
                }
            }
    }

    public void linkEffectTurn(int indexStart, int indexDestination)
    {
        string typeStart = buildings[indexStart].GetType().ToString();
        string typeDestination = buildings[indexDestination].GetType().ToString();

        if ((typeStart == "House" && typeDestination == "Farm") ||
            (typeStart == "Farm" && typeDestination == "House"))
        {
            food += 5;
        }
        if ((typeStart == "House" && typeDestination == "Factory") ||
            (typeStart == "Factory" && typeDestination == "House"))
        {
            buildingMaterials += 5;
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

    public int numberOfBuildings(string building)
    {
        int x = 0;
        foreach (ABuilding b in buildings)
        {
            if (b.name == building)
                x++;
        }
        return x;
    }

    public float resourcePerTurn(string res)
    {
        float value = 0;
        if (res == "food")
        {
            foreach (ABuilding b in buildings)
            {
                if (b.name == "Farm")
                {
                    value += farmFoodT;
                }
            }
            foreach (var entry in links)
            {
                if (buildings[entry.Key].GetType().ToString() == "Farm" ||
                    buildings[entry.Value].GetType().ToString() == "Farm")
                    value += 5;
            }

        }
        if (res == "materials")
        {
            foreach (ABuilding b in buildings)
            {
                if (b.name == "Factory")
                {
                    value += factoryMaterialsT;
                }
            }
            foreach (var entry in links)
            {
                if (buildings[entry.Key].GetType().ToString() == "Factory" ||
                    buildings[entry.Value].GetType().ToString() == "Factory")
                    value += 5;
            }
        }
        if (res == "money")
        {
            value = goldPerTurn * citizens * (taxRate / 100);
        }

        return value;
    }

}
