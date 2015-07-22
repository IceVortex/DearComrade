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
                if (tryBuild(nextBuilding))
                    buildingsList.Dequeue();
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

    #region tryBuild - Checks if AI can construct a particular building
    private bool tryBuild(ABuilding building)
    {
        if (building is House)
        {
            if (res.canBuy<House>())
            {
                res.createBuilding<House>((GameObject)Resources.Load("Prefabs/AI Buildings/House"), gen.generate());
                return true;
            }
        }

        else if (building is Farm)
        {
            if (res.canBuy<Farm>())
            {
                res.createBuilding<Farm>((GameObject)Resources.Load("Prefabs/AI Buildings/Farm"), gen.generate());
                return true;
            }
        }

        else if (building is Factory)
        {
            if (res.canBuy<Factory>())
            {
                res.createBuilding<Factory>((GameObject)Resources.Load("Prefabs/AI Buildings/Factory"), gen.generate());
                return true;
            }
        }

        else if (building is Laboratory)
        {
            if (res.canBuy<Laboratory>())
            {
                res.createBuilding<Laboratory>((GameObject)Resources.Load("Prefabs/AI Buildings/Laboratory"), gen.generate());
                return true;
            }
        }

        else if (building is WTC)
        {
            if (res.canBuy<WTC>())
            {
                res.createBuilding<WTC>((GameObject)Resources.Load("Prefabs/AI Buildings/WTC"), gen.generate());
                return true;
            }
        }

        else if (building is PublicSpace)
        {
            if (res.canBuy<PublicSpace>())
            {
                res.createBuilding<PublicSpace>((GameObject)Resources.Load("Prefabs/AI Buildings/PublicSpace"), gen.generate());
                return true;
            }
        }

        else if (building is EducationalBuilding)
        {
            if (res.canBuy<EducationalBuilding>())
            {
                res.createBuilding<EducationalBuilding>((GameObject)Resources.Load("Prefabs/AI Buildings/EducationalBuilding"), gen.generate());
                return true;
            }
        }

        else if (building is PoliceStation)
        {
            if (res.canBuy<PoliceStation>())
            {
                res.createBuilding<PoliceStation>((GameObject)Resources.Load("Prefabs/AI Buildings/PoliceStation"), gen.generate());
                return true;
            }
        }

        else if (building is Workplace)
        {
            if (res.canBuy<Workplace>())
            {
                res.createBuilding<Workplace>((GameObject)Resources.Load("Prefabs/AI Buildings/Workplace"), gen.generate());
                return true;
            }
        }

        else if (building is Hospital)
        {
            if (res.canBuy<Hospital>())
            {
                res.createBuilding<Hospital>((GameObject)Resources.Load("Prefabs/AI Buildings/Hospital"), gen.generate());
                return true;
            }
        }

        return false;
    }
    #endregion
}
