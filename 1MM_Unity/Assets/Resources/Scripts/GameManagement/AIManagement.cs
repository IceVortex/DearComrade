using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AIManagement : MonoBehaviour {
    
    public BuildingGeneration gen;
    public AResources res;

    public fadeToEndScreen lose, win;

    private int randNr;

    void Awake()
    {
        res.createBuilding<ExecutiveBuilding>((GameObject)Resources.Load("Prefabs/AI Buildings/Executive Building"), new Vector3(50, 50, 0));
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
        foreach (ABuilding building in res.buildings)
            building.Effect();

        foreach (var entry in res.links)
        {
            res.linkEffectTurn(entry.Key, entry.Value);
        }

        if (res.canBuy<Factory>())
            res.createBuilding<Factory>((GameObject)Resources.Load("Prefabs/AI Buildings/Factory"), gen.generate());
    }

}
