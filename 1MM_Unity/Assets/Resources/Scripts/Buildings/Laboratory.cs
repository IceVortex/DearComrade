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

    public string[] titles = {"Fertility", "Industrial Revolution", "Space Conservation", "The Proletariat",
                             "Nanocarbon Materials", "Bargaining", "Shelters", "Social Gatherings",
                             "Oratory", "Food Feast"};

    public string[] descriptions = {"Every turn you gain 5 more food for each farm you have.",
                                   "Every turn, you gain a bonus of 5 building materials for each factory built.",
                                    "Houses increase the maximum citizen count by an additional 50 villagers.",
                                    "Each turn you receive a bonus of 0.01 gold per villager.",
                                    "The resources cost of buildings is reduced by 20%.",
                                    "The selling rate of resources at the World Trade Center is increased by 20%.", 
                                    "The maximum number of homeless citizens is increased to 300.",
                                    "The cost of organised events is reduced by 20%.",
                                    "The maximum approval gained from triggered events (Public speech and Festival) is increased by 7.",
                                    "The approval gained from the “Increased food ratio” is increased by 0.025 per food exchanged."};

    public Vector3[] costs;

    public Laboratory()
    {
        name = "Laboratory";
        shortDescription = "Laboratories let you make researches. They provide points which you can assign to a particular research.";
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

    public override void Initialize(int index, AResources resource)
    {
        base.Initialize(index, resource);
        res.researchPoints++;
    }

    public override void Effect()
    {
        researchPointCount++;
        if (researchPointCount % researchPointInterval == 0)
            res.researchPoints++;
    }

    private void substractResources(float food, float money, float materials)
    {
        res.food -= food;
        res.money -= money;
        res.buildingMaterials -= materials;
    }

    public void researchFertility()
    {
        res.researchPoints--;
        foreach (ABuilding building in res.buildings)
        {
            if (building.GetType().ToString() == "Farm")
                ((Farm)building).farmPower += 5;
            
        }
        res.farmFoodT += 5;
        res.researchesMade++;
    }

    public void researchIndustrialRevolution()
    {
        res.researchPoints--;
        foreach (ABuilding building in res.buildings)
        {
            if (building.GetType().ToString() == "Factory")
                ((Factory)building).factoryPower += 5;

        }
        res.factoryMaterialsT += 5;
        res.researchesMade++;
    }

    public void researchSpaceConservation()
    {
        res.researchPoints--;
        foreach (ABuilding building in res.buildings)
        {
            if (building.GetType().ToString() == "House")
                res.maximumCitizens += 50;

        }
        res.houseCitizensT += 50;
        res.researchesMade++;
    }

    public void researchTheProletariat()
    {
        res.researchPoints--;
        res.goldPerTurn += 0.01f;
        res.researchesMade++;
    }

    public void researchNanocarbonMaterials()
    {
        res.researchPoints--;
        res.buildingCostRate -= 20;
        res.researchesMade++;
    }

    public void researchBargaining()
    {
        res.researchPoints--;
        res.sellRate += 20;
        res.researchesMade++;
    }

    public void researchShelters()
    {
        res.researchPoints--;
        res.maxHomelessCitizens += 200;
        res.researchesMade++;
    }

    public void researchSocialGatherings()
    {
        res.researchPoints--;
        res.triggeredEventCostRate -= 20;
        res.researchesMade++;
    }

    public void researchOratory()
    {
        res.researchPoints--;
        res.festivalApproval += 7;
        res.publichSpeechApproval += 7;
        res.researchesMade++;
    }

    public void researchFoodFeast()
    {
        res.researchPoints--;
        res.foodRatioApproval += 0.025f;
        res.researchesMade++;
    }
}
