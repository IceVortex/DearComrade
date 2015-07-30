using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AIManagement : MonoBehaviour {
    
    public BuildingGeneration gen;
    public AResources res;
    public GameManagement player;
    public fadeToEndScreen lose, win;
    public eventsRead aiEvents;
    private Stack<ABuilding> buildingsList = new Stack<ABuilding>();
    private ABuilding nextBuilding;
    private bool building;
    private int i, savingUpCD, savingUpCD_Constant = 2;
    private int rand, researchCount = 1;
    private bool savingUp = false, linkedToUnique, linkToMilitaryOutpost;
    private int wtcIndex, laboratoryIndex, educationalBuildingIndex, workplaceIndex, militaryIndex;
    private int playerTroopsLost, aiTroopsLost, resourcesAftermath, approvalAftermath;
    private int attackingCD;
    private int numberOfTroopsToConvert;

    void Awake()
    {
        res.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/AI Buildings/Executive Building"), new Vector3(20, 20, 0));
        gen.hub = GameObject.FindGameObjectWithTag("AIExecutive");
        aiEvents = GetComponent<eventsRead>();
    }

    void Update()
    {
        if (res.approval >= 100f && res.troops >= 3000 && !win.fadeTo1)
        {
            lose.startFadeTo1();

        }
        if (res.approval <= -100 && !lose.fadeTo1)
        {
            win.startFadeTo1();
        }
    }

    public void nextTurn()
    {

        // Getting a random event and using it
        aiEvents.getRandomEvent();
        aiEvents.eventEffect();

        // If I am not saving up, I will look for something to save up for, therefore, I will check dem thresholds
        if (!savingUp && savingUpCD == 0)
            checkAndAddThresholds();

        // Decreasing the savingUp Cooldown
        if (savingUpCD > 0)
            savingUpCD--;

        // Checking if a WTC or Lab has been built
        if (wtcIndex == 0)
            wtcIndex = res.findBuilding<WTC>();

        if (laboratoryIndex == 0)
            laboratoryIndex = res.findBuilding<Laboratory>();

        // Checking for researches
        if(res.researchPoints == 1)
        {
            buyResearch();
        }

        if (res.currentIndex == 1) // First turn
        {
            // It's the first turn (no buildings yet) => Add first 2 buildings for the beginning configuration
            rand = (int)UnityEngine.Random.Range(1, 3);
            if (rand == 1)
            {
                buildingsList.Push(new Factory());
                buildingsList.Push(new Factory());
            }
            else if (rand == 2)
            {
                buildingsList.Push(new Farm());
                buildingsList.Push(new Farm());
            }
        }
        else // Other turns
        {
            // If the number of farms is less then 2/3 of the nr. of factories, I'm adding some farms
            if (res.numberOfBuildings<Farm>() <= (int)((float)res.numberOfBuildings<Factory>() * 2 / 3) && !savingUp)
                for (i = 1; i <= res.howManyCanBuy<Farm>(); i++)
                    buildingsList.Push(new Farm());

            else if (res.numberOfBuildings<Farm>() > (int)((float)res.numberOfBuildings<Factory>() * 2 / 3) && !savingUp)
                for (i = 1; i <= res.howManyCanBuy<Factory>(); i++)
                    buildingsList.Push(new Factory());

            // If I'm low on citizens, I need to catch 'em all
            if (res.maximumCitizens - res.citizens <= 200 && !savingUp)
                buildingsList.Push(new House());
        }

        if(savingUp) // If I need resources, I try trading for them
        {
            if(wtcIndex != 0)
            {
                while (res.buildingMaterials - 100 >= buildingsList.Peek().buildingMaterialsCost &&
                    res.money <= buildingsList.Peek().moneyCost)
                
                while (res.food - 100 >= buildingsList.Peek().foodCost &&
                    res.money <= buildingsList.Peek().moneyCost)
                    ((WTC)res.buildings[wtcIndex]).sellFood(100);
                
                while (res.money - 100 >= buildingsList.Peek().moneyCost &&
                    res.buildingMaterials <= buildingsList.Peek().buildingMaterialsCost)
                    ((WTC)res.buildings[wtcIndex]).buyMaterials(100);
                
                while (res.money - 100 >= buildingsList.Peek().moneyCost &&
                    res.food <= buildingsList.Peek().foodCost)
                    ((WTC)res.buildings[wtcIndex]).buyFood(100);
                
            }
            // If I can build the highest priority building, I am not saving up anymore
            if (canBuild(buildingsList.Peek(), 1)) 
            { 
                savingUp = false;
                savingUpCD = savingUpCD_Constant;
            }
        }

        // If I am not saving up, I am building stuff
        if (buildingsList.Count >= 1 && !savingUp)
        {
            building = true;
            while (building && buildingsList.Count >= 1)
            {
                nextBuilding = buildingsList.Peek();
                if (canBuild(nextBuilding, 1))
                {
                    build(nextBuilding, 1);
                    buildingsList.Pop();
                }
                else
                    building = false;
            }
        }

        // Linking buildings
        foreach (ABuilding b in res.buildings)
        {
            // Linking Farms and Factories to Houses.
            if ((b is Farm || b is Factory) && res.isLinkable(b.listIndex))
            {
                rand = UnityEngine.Random.Range(1, res.numberOfBuildings<House>() + 1);
                i = 1;

                foreach (ABuilding build in res.buildings)
                    if(build is House && i == rand)
                    {
                        res.linkBuildings(b.listIndex, build.listIndex);
                        b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(build.sceneBuilding);
                        break;
                    }
                    else if (build is House && i != rand)
                    {
                        i++;
                    }
            }
                // Linking Houses.
            else if (b is House && res.isLinkable(b.listIndex))
            {
                // Randomizing the building I will link the house to.
                rand = UnityEngine.Random.Range(1, res.numberOfBuildings<Farm>() + res.numberOfBuildings<Factory>() + 1);
                i = 1;

                // Looking for WTC, Educational Building, and Workplace
                if (wtcIndex == 0)
                    wtcIndex = res.findBuilding<WTC>();

                if (educationalBuildingIndex == 0)
                    educationalBuildingIndex = res.findBuilding<EducationalBuilding>();

                if (workplaceIndex == 0)
                    workplaceIndex = res.findBuilding<Workplace>();

                if (militaryIndex == 0)
                    militaryIndex = res.findBuilding<MilitaryOutpost>();

                // Ideally, number of max troops should be (turnIndex * 100) - 1000 
                // If this is not true and I can't link the house to an unique building
                // I will link it to the military outpost, if available
                linkToMilitaryOutpost = false;
                if (res.maximumTroops <= (res.turnIndex * 100) - 1000 && militaryIndex != 0)
                    linkToMilitaryOutpost = true;

                // When I link a house to an unique building, this gets set to true.
                linkedToUnique = false;

                // If there's any, I try to link to it first.
                if (wtcIndex != 0 && res.numberOfBuildingsLinkedTo<WTC>() < 2)
                {
                    linkedToUnique = true;
                    res.linkBuildings(b.listIndex, wtcIndex);
                    b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(res.buildings[wtcIndex].sceneBuilding);
                }
                else if (educationalBuildingIndex != 0 && res.numberOfBuildingsLinkedTo<EducationalBuilding>() < 2)
                {
                    linkedToUnique = true;
                    res.linkBuildings(b.listIndex, educationalBuildingIndex);
                    b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(res.buildings[educationalBuildingIndex].sceneBuilding);
                }
                else if (workplaceIndex != 0 && res.numberOfBuildingsLinkedTo<Workplace>() < 2)
                {
                    linkedToUnique = true;
                    res.linkBuildings(b.listIndex, workplaceIndex);
                    b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(res.buildings[workplaceIndex].sceneBuilding);
                }
                else if(!linkedToUnique && linkToMilitaryOutpost)
                {
                    res.linkBuildings(b.listIndex, militaryIndex);
                    b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(res.buildings[militaryIndex].sceneBuilding);
                }
                else if(!linkedToUnique && !linkToMilitaryOutpost)
                    foreach (ABuilding build in res.buildings)
                    {
                        if ((build is Farm || build is Factory) && i == rand)
                        {
                            res.linkBuildings(b.listIndex, build.listIndex);
                            b.sceneBuilding.GetComponent<lineRendererFunctionality>().updateTarget(build.sceneBuilding);
                            break;
                        }
                        else if ((build is Farm || build is Factory) && i != rand)
                        {
                            i++;
                        }
                    }

            }
        }

        // Buying Troops
        res.trainTroops();

        // Attacking
        if (attackingCD == 0 && res.troops > 100)
        {
            numberOfTroopsToConvert = (int)(res.troops / 200) * 100;
            res.convertToAttackingTroops(numberOfTroopsToConvert);
            attack(); 
        }
        else if(attackingCD > 0)
            attackingCD--;

        // End Turn - Carpe diem
        foreach (ABuilding building in res.buildings)
            building.Effect();

        foreach (var entry in res.links)
            res.linkEffectTurn(entry.Key, entry.Value);
    }

    #region canBuild - Checks if AI has resources for a particular number of buildings of a type
    private bool canBuild(ABuilding building, int numberOfBuildings)
    {
        if (building is House)
        {
            if (res.canBuyMore<House>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is Farm)
        {
            if (res.canBuyMore<Farm>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is Factory)
        {
            if (res.canBuyMore<Factory>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is Laboratory)
        {
            if (res.canBuyMore<Laboratory>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is WTC)
        {
            if (res.canBuyMore<WTC>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is MilitaryOutpost)
        {
            if (res.canBuyMore<MilitaryOutpost>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is PublicSpace)
        {
            if (res.canBuyMore<PublicSpace>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is EducationalBuilding)
        {
            if (res.canBuyMore<EducationalBuilding>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is PoliceStation)
        {
            if (res.canBuyMore<PoliceStation>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is Workplace)
        {
            if (res.canBuyMore<Workplace>(numberOfBuildings))
            {
                return true;
            }
        }

        else if (building is Hospital)
        {
            if (res.canBuyMore<Hospital>(numberOfBuildings))
            {
                return true;
            }
        }

        return false;
    }
    #endregion

    #region Build- Buys a number of buildings for the AI
    private bool build(ABuilding building, int numberOfBuildings)
    {
        int i = 1;

        if (building is House)
        {
            if (res.canBuyMore<House>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<House>((GameObject)Resources.Load("Prefabs/AI Buildings/House"), gen.generate());
                return true;
            }
        }

        else if (building is Farm)
        {
            if (res.canBuyMore<Farm>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<Farm>((GameObject)Resources.Load("Prefabs/AI Buildings/Farm"), gen.generate());
                return true;
            }
        }

        else if (building is Factory)
        {
            if (res.canBuyMore<Factory>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<Factory>((GameObject)Resources.Load("Prefabs/AI Buildings/Factory"), gen.generate());
                return true;
            }
        }

        else if (building is Laboratory)
        {
            if (res.canBuyMore<Laboratory>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<Laboratory>((GameObject)Resources.Load("Prefabs/AI Buildings/Laboratory"), gen.generate());
                return true;
            }
        }

        else if (building is WTC)
        {
            if (res.canBuyMore<WTC>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<WTC>((GameObject)Resources.Load("Prefabs/AI Buildings/World Trade Center"), gen.generate());
                return true;
            }
        }

        else if (building is MilitaryOutpost)
        {
            if (res.canBuyMore<MilitaryOutpost>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<MilitaryOutpost>((GameObject)Resources.Load("Prefabs/AI Buildings/Military Outpost"), gen.generate());
                return true;
            }
        }

        else if (building is PublicSpace)
        {
            if (res.canBuyMore<PublicSpace>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<PublicSpace>((GameObject)Resources.Load("Prefabs/AI Buildings/Public Space"), gen.generate());
                return true;
            }
        }

        else if (building is EducationalBuilding)
        {
            if (res.canBuyMore<EducationalBuilding>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<EducationalBuilding>((GameObject)Resources.Load("Prefabs/AI Buildings/Educational Building"), gen.generate());
                return true;
            }
        }

        else if (building is PoliceStation)
        {
            if (res.canBuyMore<PoliceStation>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<PoliceStation>((GameObject)Resources.Load("Prefabs/AI Buildings/Police Station"), gen.generate());
                return true;
            }
        }

        else if (building is Workplace)
        {
            if (res.canBuyMore<Workplace>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<Workplace>((GameObject)Resources.Load("Prefabs/AI Buildings/Workplace"), gen.generate());
                return true;
            }
        }

        else if (building is Hospital)
        {
            if (res.canBuyMore<Hospital>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<Hospital>((GameObject)Resources.Load("Prefabs/AI Buildings/Hospital"), gen.generate());
                return true;
            }
        }

        return false;
    }
    #endregion

    #region Threshold Reached - Returns true if the resource generation threshold is reached
    private bool thresholdReached<building>() where building : ABuilding, new()
    {
        building x = new building();

        if (x is Laboratory || x is WTC)
        {
            if ((res.resourcePerTurn("food") >= x.foodCost / 3 &&
                   res.resourcePerTurn("materials") >= x.buildingMaterialsCost / 3) ||
                (res.food >= x.foodCost && res.buildingMaterials >= x.buildingMaterialsCost))
                return true;
        }
        
        else if (x is MilitaryOutpost || x is PublicSpace || x is EducationalBuilding ||
                x is PoliceStation || x is Workplace || x is Hospital)
        {
            if (res.resourcePerTurn("food") >= x.foodCost / 2 &&
                   res.resourcePerTurn("materials") >= x.buildingMaterialsCost / 2)
                return true;
        }

        return false;
    }
    #endregion

    #region Check for thresholds
    private void checkAndAddThresholds()
    {

        if (thresholdReached<WTC>() && !res.buildingConstructedCheck("World Trade Center"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new WTC());
        }
        else if (thresholdReached<Laboratory>() && !res.buildingConstructedCheck("Laboratory"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new Laboratory());
        }
        else if (thresholdReached<MilitaryOutpost>() && !res.buildingConstructedCheck("Military Outpost"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new MilitaryOutpost());
        }
        else if (thresholdReached<PublicSpace>() && !res.buildingConstructedCheck("Public Space"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new PublicSpace());
        }
        else if (thresholdReached<EducationalBuilding>() && !res.buildingConstructedCheck("Educational Building"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new EducationalBuilding());
        }
        else if (thresholdReached<PoliceStation>() && !res.buildingConstructedCheck("Police Station"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new PoliceStation());
        }
        else if (thresholdReached<Workplace>() && !res.buildingConstructedCheck("Workplace"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new Workplace());
        }
        else if (thresholdReached<Hospital>() && !res.buildingConstructedCheck("Hospital"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Push(new Hospital());
        }

    }
    #endregion

    #region BuyResearch - If a research point is available, buy a research
    private void buyResearch()
    {
        if (researchCount == 1)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchNanocarbonMaterials();
            researchCount++;
            return;
        }

        if (researchCount == 2)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchBargaining();
            researchCount++;
            return;
        }

        if (researchCount == 3)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchTheProletariat();
            researchCount++;
            return;
        }

        if (researchCount == 4)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchShelters();
            researchCount++;
            return;
        }

        if (researchCount == 5)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchSpaceConservation();
            researchCount++;
            return;
        }

        if (researchCount == 6)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchFertility();
            researchCount++;
            return;
        }

        if (researchCount == 7)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchIndustrialRevolution();
            researchCount++;
            return;
        }

        if (researchCount == 8)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchSocialGatherings();
            researchCount++;
            return;
        }

        if (researchCount == 9)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchOratory();
            researchCount++;
            return;
        }

        if (researchCount == 10)
        {
            ((Laboratory)res.buildings[laboratoryIndex]).researchFoodFeast();
            researchCount++;
            return;
        }

        return;
    }
    #endregion

    #region Attack

    public void attack()
    {
        // More than 0 troops => I am attacking
        if (res.attackingTroops > 0)
        {
            attackingCD = (int)UnityEngine.Random.Range(3, 6);  
            
            // I haz more troops
            if (res.attackingTroops >= player.res.troops)
            {
                rand = UnityEngine.Random.Range(1, 101);

                // Troops lost for both players
                aiTroopsLost = (int)((res.attackingTroops / 4) * UnityEngine.Random.Range(50, 151) / 100);
                playerTroopsLost = (int)((player.res.troops / 4) * UnityEngine.Random.Range(100, 151) / 100);

                if (rand <= 80 || player.res.troops == 0) // I win
                {
                    // Approval gained or lost for both players
                    approvalAftermath = (int)((res.attackingTroops - player.res.troops) / 50);

                    // Resources gained or lost for both players
                    resourcesAftermath = (int)(res.attackingTroops - player.res.troops) / 5;
                }

                else // If I lose
                {
                    // Approval gained or lost for both players
                    approvalAftermath = -1 * (int)((res.attackingTroops - player.res.troops) / 100);

                    // No resources lost / gained :(
                    resourcesAftermath = 0;
                }

                // Updating the resources
                #region ...
                if (player.res.food >= resourcesAftermath)
                {
                    player.res.food -= resourcesAftermath;
                    res.food += resourcesAftermath;
                }
                else
                {
                    res.food += player.res.food;
                    player.res.food = 0;
                }

                if (player.res.buildingMaterials >= resourcesAftermath)
                {
                    player.res.buildingMaterials -= resourcesAftermath;
                    res.buildingMaterials += resourcesAftermath;
                }
                else
                {
                    res.buildingMaterials += player.res.buildingMaterials;
                    player.res.buildingMaterials = 0;
                }

                if (player.res.money >= resourcesAftermath)
                {
                    player.res.money -= resourcesAftermath;
                    res.money += resourcesAftermath;
                }
                else
                {
                    res.food += player.res.food;
                    player.res.food = 0;
                }
                #endregion

                // Updating the approval
                res.approval = res.approval + approvalAftermath;
                player.res.approval = player.res.approval - approvalAftermath;

                // Updating the troops
                res.troops = res.troops + res.attackingTroops - aiTroopsLost;
                player.res.troops = player.res.troops - playerTroopsLost;
                res.attackingTroops = 0;
            }
            else // He haz moar troops
            {
                rand = UnityEngine.Random.Range(1, 101);

                // Troops lost for both players
                aiTroopsLost = (int)((res.troops / 4) * UnityEngine.Random.Range(50, 151) / 100);
                playerTroopsLost = (int)((player.res.attackingTroops / 4) * UnityEngine.Random.Range(100, 151) / 100);
                
                if (rand <= 20) // I win
                {
                    // Approval gained or lost for both players
                    approvalAftermath = (int)((player.res.troops - res.attackingTroops) / 100);

                    // Resources gained or lost for both players
                    resourcesAftermath = (int)(player.res.troops - res.attackingTroops) / 10;
                }
                else // If I lose
                {
                    // Approval gained or lost for both players
                    approvalAftermath = -1 * (int)((player.res.troops - res.attackingTroops) / 100);

                    // No resources lost / gained :(
                    resourcesAftermath = 0;
                }

                // Updating the resources
                #region ...
                if (player.res.food >= resourcesAftermath)
                {
                    player.res.food -= resourcesAftermath;
                    res.food += resourcesAftermath;
                }
                else
                {
                    res.food += player.res.food;
                    player.res.food = 0;
                }

                if (player.res.buildingMaterials >= resourcesAftermath)
                {
                    player.res.buildingMaterials -= resourcesAftermath;
                    res.buildingMaterials += resourcesAftermath;
                }
                else
                {
                    res.buildingMaterials += player.res.buildingMaterials;
                    player.res.buildingMaterials = 0;
                }

                if (player.res.money >= resourcesAftermath)
                {
                    player.res.money -= resourcesAftermath;
                    res.money += resourcesAftermath;
                }
                else
                {
                    res.food += player.res.food;
                    player.res.food = 0;
                }
                #endregion

                // Updating the approval
                res.approval = res.approval + approvalAftermath;
                player.res.approval = player.res.approval - approvalAftermath;

                // Updating the troops
                res.troops = res.troops + res.attackingTroops - playerTroopsLost;
                player.res.troops = player.res.troops - aiTroopsLost;
                res.attackingTroops = 0;

            }
        }
    }

    #endregion
}
