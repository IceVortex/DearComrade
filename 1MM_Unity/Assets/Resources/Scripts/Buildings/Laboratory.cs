using UnityEngine;
using System.Collections;

public class Laboratory : ABuilding
{
    public GameManagement gameManager;

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

    public Laboratory()
    {
        name = "Laboratories";
        description = "mutherfuckin' lab";
        foodCost = 0;
        moneyCost = 75;
        buildingMaterialsCost = 150;
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagement>();
    }

    public override void Effect()
    {
    }

    private void substractResources(float food, float money, float materials)
    {
        GameResources.instance.food -= food;
        GameResources.instance.money -= money;
        GameResources.instance.buildingMaterials -= materials;
    }

    public void researchFertility()
    {
        substractResources(fertilityFoodCost, fertilityMoneyCost, fertilityMaterialsCost);
        foreach(ABuilding building in gameManager.buildings)
        {
            if (building.GetType().ToString() == "Farm")
                ((Farm)building).farmPower += 5;
            
        }
        GameResources.instance.farmFoodT += 5;
    }

    public void researchIndustrialRevolution()
    {
        substractResources(industrialRevolutionFoodCost, industrialRevolutionMoneyCost, industrialRevolutionMaterialsCost);
        foreach (ABuilding building in gameManager.buildings)
        {
            if (building.GetType().ToString() == "Factory")
                ((Factory)building).factoryPower += 5;

        }
        GameResources.instance.factoryMaterialsT += 5;
    }

    public void researchSpaceConservation()
    {
        substractResources(spaceConservationFoodCost, spaceConservationMoneyCost, spaceConservationMaterialsCost);
        foreach (ABuilding building in gameManager.buildings)
        {
            if (building.GetType().ToString() == "House")
                GameResources.instance.maximumCitizens += 50;

        }
        GameResources.instance.houseCitizensT += 50;
    }

    public void researchTheProletariat()
    {
        substractResources(theProletariatFoodCost, theProletariatMoneyCost, theProletariatMaterialsCost);
        ((ExecutiveBuilding)(gameManager.buildings[0])).goldPerTurn += 0.01f;
    }

    public void researchNanocarbonMaterials()
    {
        substractResources(nanocarbonMaterialsFoodCost, nanocarbonMaterialsMoneyCost, 
                            nanocarbonMaterialsMaterialsCost);
        //To Add Effect
        //The resources cost of buildings is reduced by 20%.
    }

    public void researchBargaining()
    {
        substractResources(bargainingFoodCost, bargainingMoneyCost, bargainingMaterialsCost);
        //To Add Effect
        //Cost of buying resources at market is reduced by 30% and the number of resources gained from buying is also increased by 30%. 

    }

    public void researchShelters()
    {
        substractResources(spaceConservationFoodCost, spaceConservationMoneyCost, spaceConservationMaterialsCost);
        //To Add Effect
        //The maximum number of homeless citizens is increased to 300.
    }

    public void researchSocialGatherings()
    {
        substractResources(socialGatheringsFoodCost, socialGatheringsMoneyCost, socialGatheringsMaterialsCost);
        //To Add Effect
        //The cost of triggered events is reduced by 20%.
    }

    public void researchOratory()
    {
        substractResources(oratoryFoodCost, oratoryMoneyCost, oratoryMaterialsCost);
        //To Add Effect
        //The maximum approval gained from triggered events (Public speech and Festival) is increased by 1.

    }

    public void researchFoodFeast()
    {
        substractResources(foodFeastFoodCost, foodFeastMoneyCost, foodFeastMaterialsCost);
        //To Add Effect
        //The approval gained from the “Increased food ratio” is increased by 0.01 per food exchanged.
    }
}
