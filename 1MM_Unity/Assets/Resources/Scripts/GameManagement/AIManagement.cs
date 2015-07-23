using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AIManagement : MonoBehaviour {
    
    public BuildingGeneration gen;
    public AResources res;
    public fadeToEndScreen lose, win;
    private Queue<ABuilding> buildingsList = new Queue<ABuilding>();
    private ABuilding nextBuilding;
    private bool building;
    private int i;
    private bool savingUp = false;
    private int wtcIndex;

    void Awake()
    {
        res.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/AI Buildings/Executive Building"), new Vector3(20, 20, 0));
        gen.hub = GameObject.FindGameObjectWithTag("AIExecutive");
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

        // If I am not saving up, I will look for something to save up for, therefore, I will check dem thresholds
        if (!savingUp)
            checkAndAddThresholds();

        if (res.findBuilding<WTC>() != 0)
            wtcIndex = res.findBuilding<WTC>();

        // If the number of farms is less then 2/3 of the nr. of factories, I'm adding some farms
        if (res.numberOfBuildings("Farm") <= (int)((float)res.numberOfBuildings("Factory") * 2 / 3) && !savingUp)
            for (i = 1; i <= res.howManyCanBuy<Farm>(); i++)
                buildingsList.Enqueue(new Farm());

        else if (res.numberOfBuildings("Farm") > (int)((float)res.numberOfBuildings("Factory") * 2 / 3) && !savingUp)
            for (i = 1; i <= res.howManyCanBuy<Factory>(); i++ )
                buildingsList.Enqueue(new Factory());

        // If I'm low on citizens, I need to catch 'em all
        if (res.maximumCitizens - res.citizens <= 200 && !savingUp)
            buildingsList.Enqueue(new House());

        if(savingUp)
        {
            if(wtcIndex != 0)
            {
                while (res.buildingMaterials - 100 >= buildingsList.Peek().buildingMaterialsCost &&
                    res.money <= buildingsList.Peek().moneyCost)
                    ((WTC)res.buildings[wtcIndex]).sellMaterials(100);

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

            if (canBuild(buildingsList.Peek(), 1))
                savingUp = false;
        }

        if (buildingsList.Count >= 1 && !savingUp)
        {
            building = true;
            while (building && buildingsList.Count >= 1)
            {
                nextBuilding = buildingsList.Peek();
                if (canBuild(nextBuilding, 1))
                {
                    build(nextBuilding, 1);
                    buildingsList.Dequeue();
                }
                else
                    building = false;
            }
        }

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

        else if (building is PublicSpace)
        {
            if (res.canBuyMore<PublicSpace>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<PublicSpace>((GameObject)Resources.Load("Prefabs/AI Buildings/PublicSpace"), gen.generate());
                return true;
            }
        }

        else if (building is EducationalBuilding)
        {
            if (res.canBuyMore<EducationalBuilding>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<EducationalBuilding>((GameObject)Resources.Load("Prefabs/AI Buildings/EducationalBuilding"), gen.generate());
                return true;
            }
        }

        else if (building is PoliceStation)
        {
            if (res.canBuyMore<PoliceStation>(numberOfBuildings))
            {
                for (i = 1; i <= numberOfBuildings; i++)
                    res.createBuilding<PoliceStation>((GameObject)Resources.Load("Prefabs/AI Buildings/PoliceStation"), gen.generate());
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
            if (res.resourcePerTurn("food") >= x.foodCost / 3 &&
                   res.resourcePerTurn("materials") >= x.buildingMaterialsCost / 3)
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

        if (thresholdReached<WTC>() && !res.buildingConsutructedCheck("World Trade Center"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new WTC());
        }
        else if (thresholdReached<Laboratory>() && !res.buildingConsutructedCheck("Laboratory"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new Laboratory());
        }
        else if (thresholdReached<MilitaryOutpost>() && !res.buildingConsutructedCheck("Military Outpost"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new MilitaryOutpost());
        }
        else if (thresholdReached<PublicSpace>() && !res.buildingConsutructedCheck("Public Space"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new PublicSpace());
        }
        else if (thresholdReached<EducationalBuilding>() && !res.buildingConsutructedCheck("Educational Building"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new EducationalBuilding());
        }
        else if (thresholdReached<PoliceStation>() && !res.buildingConsutructedCheck("Police Station"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new PoliceStation());
        }
        else if (thresholdReached<Workplace>() && !res.buildingConsutructedCheck("Workplace"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new Workplace());
        }
        else if (thresholdReached<Hospital>() && !res.buildingConsutructedCheck("Hospital"))
        {
            savingUp = true;
            buildingsList.Clear();
            buildingsList.Enqueue(new Hospital());
        }
    }
    #endregion
}
