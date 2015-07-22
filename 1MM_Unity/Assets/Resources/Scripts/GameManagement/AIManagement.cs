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
        // If the number of farms is less then 2/3 of the nr. of factories, I'm adding some farms
        if (res.numberOfBuildings("Farm") <= (int)((float)res.numberOfBuildings("Factory") * 2 / 3))
            buildingsList.Enqueue(new Farm());
        else
            buildingsList.Enqueue(new Factory());

        // If I'm low on citizens, I need 'em
        if (res.maximumCitizens - res.citizens <= 200)
            buildingsList.Enqueue(new House());

        if (buildingsList.Count >= 1)
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
                    res.createBuilding<WTC>((GameObject)Resources.Load("Prefabs/AI Buildings/WTC"), gen.generate());
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
}
