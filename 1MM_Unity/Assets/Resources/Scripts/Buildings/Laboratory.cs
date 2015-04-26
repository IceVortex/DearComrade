using UnityEngine;
using System.Collections;

public class Laboratory : ABuilding
{
    public GameManagement gameManager;

    public int researchPointCount;
    public int researchPointInterval = 7;

    public bool fertility, industrialRevolution, spaceConservation,
        theProletariat, nanocarbonMaterials, bargaining, improvedShelters,
        socialGatherings, oratory, foodFeast;

    public int fertilityFoodCost = 150, fertilityMoneyCost = 0, fertilityMaterialsCost = 0;
    public int industrialRevolutionFoodCost = 0, industrialRevolutionMoneyCost = 0, industrialRevolutionMaterialsCost = 150;
    public int spaceConservationFoodCost = 0, spaceConservationMoneyCost = 100, spaceConservationMaterialsCost = 150;
    public int theProletariatFoodCost = 0, theProletariatMoneyCost = 200, theProletariatMaterialsCost = 0;
    public int nanocarbonMaterialsFoodCost = 0, nanocarbonMaterialsMoneyCost = 200, nanocarbonMaterialsMaterialsCost = 300;
    public int bargainingFoodCost = 0, bargainingMoneyCost = 300, bargainingMaterialsCost = 0;
    public int improvedSheltersFoodCost = 0, improvedSheltersMoneyCost = 50, improvedSheltersMaterialsCost = 100;
    public int socialGatheringsFoodCost = 200, socialGatheringsMoneyCost = 200, socialGatheringsMaterialsCost = 200;
    public int oratoryFoodCost = 0, oratoryMoneyCost = 400, oratoryMaterialsCost = 0;
    public int foodFeastFoodCost = 200, foodFeastMoneyCost = 0, foodFeastMaterialsCost = 0;

    public string[] titles = {"Fertility", "Industrial Revolution", "Space Conservation", "The Proletariat",
                             "Nanocarbon Materials", "Bargaining", "Shelters", "Social Gatherings",
                             "Oratory", "Food Feast"};

    public string[] descriptions = {"Every turn you gain 5 more food for each farm you have.",
                                   "Every turn, you gain a bonus of 5 building materials for each factory built.",
                                    "Houses increase the maximum citizen count by an additional 50 villagers.",
                                    "Each turn you receive a bonus of 0.01 gold per villager.",
                                    "The resources cost of buildings is reduced by 20%.",
                                    "Cost of buying resources at market is reduced by 30% and the number of resources gained from buying is also increased by 30%.", 
                                    "The maximum number of homeless citizens is increased to 300.",
                                    "The cost of triggered events is reduced by 20%.",
                                    "The maximum approval gained from triggered events (Public speech and Festival) is increased by 1.",
                                    "The approval gained from the “Increased food ratio” is increased by 0.01 per food exchanged."};

    public Vector3[] costs;

    public Laboratory()
    {
        name = "Laboratory";
        shortDescription = "Laboratories let you make researches. They provide 1 research point every " + researchPointInterval + " months, which you can assign to a particular research.";
        longDescription = "Laboratories let you make researches. They provide 1 research point every " + researchPointInterval + " months, which you can assign to a particular research.";
        flavorText = "Jet fuel can't melt steel beams.";
        foodCost = 0;
        moneyCost = 75;
        buildingMaterialsCost = 150;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagement>();

        costs = new Vector3[10];

        costs[0].Set(150, 0, 0);
        costs[1].Set(0, 0, 150);
        costs[2].Set(0, 100, 150);
        costs[3].Set(0, 200, 0);
        costs[4].Set(0, 200, 300);
        costs[5].Set(0, 300, 0);
        costs[6].Set(0, 50, 100);
        costs[7].Set(200, 200, 200);
        costs[8].Set(0, 400, 0);
        costs[9].Set(200, 0, 0);
        
    }

    public override void Initialize(int index)
    {
        base.Initialize(index);
        GameResources.instance.researchPoints++;
    }

    public override void Effect()
    {
        researchPointCount++;
        if (researchPointCount % researchPointInterval == 0)
            GameResources.instance.researchPoints++;
    }

    private void substractResources(float food, float money, float materials)
    {
        GameResources.instance.food -= food;
        GameResources.instance.money -= money;
        GameResources.instance.buildingMaterials -= materials;
    }

    public void researchFertility()
    {
        GameResources.instance.researchPoints--;
        foreach(ABuilding building in GameResources.instance.buildings)
        {
            if (building.GetType().ToString() == "Farm")
                ((Farm)building).farmPower += 5;
            
        }
        GameResources.instance.farmFoodT += 5;
    }

    public void researchIndustrialRevolution()
    {
        GameResources.instance.researchPoints--;
        foreach (ABuilding building in GameResources.instance.buildings)
        {
            if (building.GetType().ToString() == "Factory")
                ((Factory)building).factoryPower += 5;

        }
        GameResources.instance.factoryMaterialsT += 5;
    }

    public void researchSpaceConservation()
    {
        GameResources.instance.researchPoints--;
        foreach (ABuilding building in GameResources.instance.buildings)
        {
            if (building.GetType().ToString() == "House")
                GameResources.instance.maximumCitizens += 50;

        }
        GameResources.instance.houseCitizensT += 50;
    }

    public void researchTheProletariat()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.goldPerTurn += 0.01f;
    }

    public void researchNanocarbonMaterials()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.buildingCostRate -= 20;
        Debug.Log("researched + " + GameResources.instance.buildingCostRate);
    }

    public void researchBargaining()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.buyRate += 30;
        GameResources.instance.sellRate -= GameResources.instance.sellRate * (30 / 100);
    }

    public void researchShelters()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.maxHomelessCitizens += 200;
    }

    public void researchSocialGatherings()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.triggeredEventCostRate -= 20;
    }

    public void researchOratory()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.festivalApproval += 1;
        GameResources.instance.publichSpeechApproval += 1;

    }

    public void researchFoodFeast()
    {
        GameResources.instance.researchPoints--;
        GameResources.instance.foodRatioApproval += 0.01f;
    }
}
