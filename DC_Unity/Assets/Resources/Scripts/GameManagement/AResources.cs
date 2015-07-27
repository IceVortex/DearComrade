using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AResources : MonoBehaviour 
{

    // Main Resources
    public float food, money, buildingMaterials;
    public float approval;
    public float citizens, maximumCitizens;
    public float troops, maximumTroops, attackingTroops;
    public float researchPoints;

    // Tax Rate
    public float taxRate = 100;

    // Maximum number of homeless citizens you can have.
    public float maxHomelessCitizens = 200;

    // Number of resources gained per turn or at initialization for farm, house and factories.
    public float farmFoodT = 10, houseCitizensT = 300, factoryMaterialsT = 10;

    // Rates of building cost, buy/sell rate, gold gain and approval decay.
    public float buildingCostRate = 100, buyRate = 100, sellRate = 50;
    public float approvalDecayRate = 100, goldPerTurn = 0.01f;
    public float flatApproval = 1f;
    public float flatApprovalDecayIncreasePerTurn = 0.1f;
    public float territoryConquerRate = 0f;

    // Rate of triggered event cost.
    public float triggeredEventCostRate = 100;

    // Approval gained from publich speech and festival.
    public float publichSpeechApproval = 25, festivalApproval = 25;

    // Approval gained from trading food at exec. building
    public float foodRatioApproval = 0.1f;

    // The current turn index
    public int turnIndex = 0;

    // Variables used for statistics
    public int researchesMade;

    // Troops training cost
    public int troopsFoodCost = 30, troopsMaterialsCost = 30, troopsMoneyCost = 30;

    // The list of buildings, links and the index
    public List<ABuilding> buildings = new List<ABuilding>();
    public Dictionary<int, int> links = new Dictionary<int, int>();
    public Dictionary<string, int> nrOfLinkedBuildings;
    public int currentIndex = 0;

    private GameObject obj;
    public GameObject manager;

    #region Can Buy - Functions for checking if a building is available for buy
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

    public bool canBuyMore<building>(int numberOfBuildings) where building : ABuilding, new()
    {
        building x = new building();
        if (food >= x.foodCost * (buildingCostRate / 100) * numberOfBuildings &&
            money >= x.moneyCost * (buildingCostRate / 100) * numberOfBuildings &&
            buildingMaterials >= x.buildingMaterialsCost * (buildingCostRate / 100) * numberOfBuildings)
            return true;
        else
            return false;
    }

    public int howManyCanBuy<building>() where building : ABuilding, new()
    {
        // Returns maximum number of buildings you can make of "building" type
        building x = new building();
        return (int)System.Math.Min(food / x.foodCost, System.Math.Min(money / x.moneyCost, buildingMaterials / x.buildingMaterialsCost));
    }
    #endregion

    #region Functions for counting and finding buildings
    public int findBuilding<building>() where building : ABuilding, new()
    {
        building x = new building();
        foreach (ABuilding b in buildings)
            if (b.name == x.name)
                return b.listIndex;
        return 0;
    }

    public bool buildingConstructedCheck(string building)
    {
        foreach (ABuilding b in buildings)
        {
            if (b.name == building)
                return true;
        }
        return false;
    }

    public int numberOfBuildings<building>() where building : ABuilding
    {
        int x = 0;
        foreach (ABuilding b in buildings)
        {
            if (b is building)
                x++;
        }
        return x;
    }

    public int numberOfBuildingsLinkedTo<building>() where building : ABuilding
    {
        int x = 0;
        foreach (ABuilding b in buildings)
        {
            if (buildings[b.comradeIndex] is building)
                x++;
        }
        return x;
    }

    #endregion

    #region Cost and Resources per turn functions
    public Vector3 cost<building>() where building : ABuilding, new()
    {
        Vector3 cost;
        building x = new building();
        cost.x = x.foodCost * (buildingCostRate / 100);
        cost.y = x.buildingMaterialsCost * (buildingCostRate / 100);
        cost.z = x.moneyCost * (buildingCostRate / 100);
        return cost;
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
    #endregion

    #region Linking functions
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
        else if (typeStart == "House" && typeDestination == "WTC" && numberOfBuildingsLinkedTo<WTC>() < 2)
            return true;
        else if (typeStart == "House" && typeDestination == "Hospital" && numberOfBuildingsLinkedTo<Hospital>() < 2)
            return true;
        else if (typeStart == "House" && typeDestination == "EducationalBuilding" && numberOfBuildingsLinkedTo<EducationalBuilding>() < 2)
            return true;
        else if (typeStart == "House" && typeDestination == "PoliceStation" && numberOfBuildingsLinkedTo<PoliceStation>() < 2)
            return true;
        else if (typeStart == "House" && typeDestination == "Workplace" && numberOfBuildingsLinkedTo<Workplace>() < 2)
            return true;
        else if (typeStart == "House" && typeDestination == "PublicSpace" && numberOfBuildingsLinkedTo<PoliceStation>() < 2)
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
            sellRate += 15;
        else if (typeStart == "House" && typeDestination == "Hospital")
            flatApproval -= 1;
        else if (typeStart == "House" && typeDestination == "EducationalBuilding")
            buildingCostRate -= 15;
        else if (typeStart == "House" && typeDestination == "PoliceStation")
            approvalDecayRate -= 5;
        else if (typeStart == "House" && typeDestination == "Workplace")
            goldPerTurn += 0.005f;
        else if (typeStart == "House" && typeDestination == "PublicSpace")
            approval += 10f;
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

    #endregion

    #region Automated Linking
    public void automateLinkingFarmAndFactory()
    {
        int i, rand;

        if (numberOfBuildings<House>() != 0)
        {
            foreach (ABuilding b in buildings)
            {
                if ((b is Factory || b is Farm) && isLinkable(b.listIndex))
                {
                    i = 1;
                    rand = (int)Random.Range(1, numberOfBuildings<House>() + 1);
                    foreach (ABuilding h in buildings)
                    {
                        if (h is House)
                        {
                            if (i == rand)
                            {
                                linkBuildings(b.listIndex, h.listIndex);
                                b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(h.sceneBuilding);
                                break;
                            }
                            else
                                i++;
                        }
                    }
                }
            }
        }
    }

    public void automateLinkingHouse(GameObject building)
    {
        int targetIndex = building.GetComponent<IdManager>().buildingIndex;
        foreach(ABuilding b in buildings)
        {
            if(b is House && isLinkable(b.listIndex) && canLink(b.listIndex, targetIndex))
            {
                linkBuildings(b.listIndex, targetIndex);
                b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(building);
            }
        }
    }
    #endregion

    public void createBuilding<building>(GameObject buildingPrefab, Vector3 position) where building : ABuilding, new()
    {
        //Adding the buildings to the list
        buildings.Add(new building());
        buildings[currentIndex].Initialize(currentIndex, this);

        //Creating the game object in the scene, for the visual representation
        obj = (GameObject)GameObject.Instantiate(buildingPrefab, position, Quaternion.identity);
        obj.name = buildings[currentIndex].name;
        obj.GetComponent<IdManager>().buildingIndex = currentIndex;
        obj.GetComponent<IdManager>().res = this;

        //Adding the object in scene to the buildings list
        buildings[currentIndex].sceneBuilding = (GameObject)obj;

        currentIndex++;
    }

    public void trainTroops()
    {
        if(food >= troopsFoodCost && buildingMaterials >= troopsMaterialsCost && money >= troopsMoneyCost && troops + 100 <= maximumTroops)
        {
            food -= troopsFoodCost;
            buildingMaterials -= troopsMaterialsCost;
            money -= troopsMoneyCost;
            troops += 100;
        }
    }

    public void convertToAttackingTroops(int numberOfTroopsToConvert)
    {
        if(numberOfTroopsToConvert <= troops && numberOfTroopsToConvert>0)
        {
            troops -= numberOfTroopsToConvert;
            attackingTroops += numberOfTroopsToConvert;
        }
        else if(-numberOfTroopsToConvert <=attackingTroops && numberOfTroopsToConvert < 0)
        {
            troops -= numberOfTroopsToConvert;
            attackingTroops += numberOfTroopsToConvert;
        }
    }
}
